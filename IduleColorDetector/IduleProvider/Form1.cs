///Use the define that is good for your needs:
///IduleCam0 -> Get data from the first (or only) camera that is connected
///IduleCam1 -> Get data from the second camera that is connected. If only one camera is connected, then this will give an error
///IduleStereo -> Get data from two cameras simultaneously


//#define IduleCam0_raw
//#define IduleCam0_processed
//#define IduleCam1_raw
//#define IduleCam1_processed
//#define IduleStereo_raw
#define IduleStereo_processed

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Awaiba.Drivers.Grabbers;
using Awaiba.FrameProcessing;
using System.Runtime.InteropServices;
using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Structure;


namespace IduleProvider {
	public partial class Form1 : Form {
		/// <summary>
		/// Camera Initialization
		/// IduleProviderCsCam(0) -> initialize first camera that is connected
		/// IduleProviderCsCam(1) -> initialize the second camera that is connected (in case you want to see images just from the second camera)
		/// StereoIduleProviderCs -> To see images from two cameras (you need to have two cameras connected)
		/// </summary>

#if(IduleCam0_raw || IduleCam0_processed)
        IduleProviderCsCam provider = new IduleProviderCsCam(0);
#endif

#if(IduleCam1_raw || IduleCam1_processed)
        IduleProviderCsCam provider = new IduleProviderCsCam(1);
#endif

#if(IduleStereo_raw || IduleStereo_processed)
		StereoIduleProviderCs provider = new StereoIduleProviderCs();
#endif

		public Form1() {
			InitializeComponent();

			//Note: To receive the 90 fps that the sensor sends, only the "ImageTransaction" hook needs to be done;
			//The ImageProcessed event does the image processing, and it can only manage around 30 fps;

			provider.Exception += provider_Exception;
			provider.Initialize();

#if(IduleCam0_raw)
            provider.ImageTransaction += provider_ImageTransaction;
#endif
#if(IduleCam0_processed)
            provider.ImageProcessed += provider_ImageProcessed;
#endif
#if(IduleCam1_raw)
            provider.ImageTransaction += provider_ImageTransaction;
#endif
#if(IduleCam1_processed)
            provider.ImageProcessed += provider_ImageProcessed;
#endif
#if(IduleStereo_raw)
            provider.ImageTransaction += provider_ImageTransaction;
#endif
#if(IduleStereo_processed)
			provider.ImageProcessed += provider_ImageProcessed;
			provider.ImageProcessed2 += provider_ImageProcessed;
#endif
			provider.WriteRegister(new NanEyeGSRegisterPayload(false, 0x05, true, 0, 50));
			provider.WriteRegister(new NanEyeGSRegisterPayload(false, 0x06, true, 0, 255));

			provider.Exception += camera_Exception;
			FormClosing += Form1_FormClosing;

			//ProcessingWrapper.pr[0].ReduceProcessingColor = false;
			//ProcessingWrapper.pr[0].skipFrames.FramesNumber = 4;

			/*
			ProcessingWrapper.pr[0].colorReconstruction.Green1Gain = (float) 1.4;
			ProcessingWrapper.pr[0].colorReconstruction.RedGain = (float)2.0;
			ProcessingWrapper.pr[0].colorReconstruction.BlueGain = (float)2.0;
			ProcessingWrapper.pr[0].colorReconstruction.Green2Gain = (float)1.6;
			

			ProcessingWrapper.pr[0].colorReconstruction.SetBayerGrid(1);
			 */
		}

		private void provider_Exception(object sender, OnExceptionEventArgs e) {
			Console.WriteLine("Exception: " + e.ex.Message);
		}

		/// <summary>
		/// Displays the image after the image processing
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void provider_ImageProcessed(object sender, OnImageReceivedBitmapEventArgs e) {
			Awaiba.Imaging.PPMImage ppm = new Awaiba.Imaging.PPMImage(e.Width, e.Height, e.BitsPerPixel, e.PixelData);

			if (e.SensorID == 0)
				displayAdapter1.DrawImage(ppm);

			/*
            if(e.SensorID == 1)
                displayAdapter2.DrawImage(ppm);
			 */
		}

		/// <summary>
		/// Displays the raw 8 bit image
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void provider_ImageTransaction(object sender, ImageReceivedEventArgs e) {
			if (this.InvokeRequired) {
				this.BeginInvoke(
					new Action<object, Awaiba.Drivers.Grabbers.ImageReceivedEventArgs>(provider_ImageTransaction),
						new object[] { sender, e });
			} else {
				Awaiba.Imaging.PGMImage ppm = new Awaiba.Imaging.PGMImage(e.Width, e.Height, e.BitsPerPixel, e.PixelData);
				if (e.SensorID == 0)
					displayAdapter1.DrawImage(ppm);

				/*
                if (e.SensorID == 1)
                    displayAdapter2.DrawImage(ppm);
				 */
			}
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
			provider.Dispose();
		}

		/// <summary>
		/// If the camera gets into any exception, it will be thrown in this method
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void camera_Exception(object sender, OnExceptionEventArgs e) {
			Console.WriteLine(e.ex.Message);
		}

		/// <summary>
		/// Example on how to use the Awaiba's image processing library
		/// More information on Awaiba's Support website on the "Awaiba Image Processing" document
		/// This can only be used in the Processed Images
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void colorCheckBox_CheckedChanged(object sender, EventArgs e) {
			ProcessingWrapper.pr[0].colorReconstruction.Apply = colorCheckBox.Checked;
		}

		/// <summary>
		/// Start getting images from the camera
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void StartButton_Click(object sender, EventArgs e) {
			provider.StartCapture();
		}

		/// <summary>
		/// To stop getting images from the camera
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void StopButton_Click(object sender, EventArgs e) {
			provider.StopCapture();
		}

		/// <summary>
		/// Method to save an image
		/// This can only be used in the Processed Images
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void saveRawImgButton_Click(object sender, EventArgs e) {
			ProcessingWrapper.pr[0].TakeSnapshost().rawImage.Save("image.pgm");
			ProcessingWrapper.pr[0].TakeSnapshost().processedImage.Save("image.png");
		}

		/// <summary>
		/// Example how to send registers to the camera
		/// In this case, changing the pre-scaler (0x05) value;
		/// Also available to change the exposure (0x06)
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void trackBar1_Scroll(object sender, EventArgs e) {
			//provider.WriteRegister(new NanEyeGSRegisterPayload(true, 0x05, true, 0, trackBar1.Value));
			provider.WriteRegister(new NanEyeGSRegisterPayload(false, 0x05, true, 0, trackBar1.Value));
		}

		/// <summary>
		/// Method to record raw videos
		/// This can only be used in the Processed Images
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button4_Click(object sender, EventArgs e) {
			if (button4.Text == "Record Raw Video") {
				ProcessingWrapper.pr[0].awRawVideo.StartVideo("Raw.awvideo");
				button4.Text = "Stop Recording...";
			} else if (button4.Text == "Stop Recording...") {
				ProcessingWrapper.pr[0].awRawVideo.Close();
				button4.Text = "Record Raw Video";
			}
		}

		/// <summary>
		/// Method to record processed videos (after the Awaiba Image Processing Pipeline)
		/// This can only be used in the Processed Images
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button5_Click(object sender, EventArgs e) {
			if (button5.Text == "Record Processed Video") {
				ProcessingWrapper.pr[0].awVideo.StartVideo(20, "Processed.avi", true);
				button5.Text = "Stop Recording...";
			} else if (button5.Text == "Stop Recording...") {
				ProcessingWrapper.pr[0].awVideo.StopVideo();
				button5.Text = "Record Processed Video";
			}
		}

		private void CannyButton_Click(object sender, EventArgs e) {
			
			Image<Bgr, Byte> img = new Image<Bgr, byte>(displayAdapter1.Image.ConvertToBitmap());
			Image<Gray, byte> filteredImg = img.Convert<Gray, byte>().PyrDown().PyrUp();
			Image<Gray, byte> cannyImg = filteredImg.Canny(minTrackBar.Value, maxTrackBar.Value);
			pictureBox1.Image = cannyImg.ToBitmap();
			
			if (houghCheckBox.Checked) {
				Image<Bgr, byte> tempImg = cannyImg.Convert<Bgr, byte>();
				Emgu.CV.Util.VectorOfPointF points = new Emgu.CV.Util.VectorOfPointF();
				CvInvoke.HoughLines(cannyImg, points, 1, Math.PI / 180.0, houghThreshholdBar.Value);
				for (int i = 0; i < points.Size - 1; i++) {
					double a = Math.Cos(points[i].Y);
					double b = Math.Sin(points[i].Y);
					double x0 = points[i].X * a;
					double y0 = points[i].X * b;
					int x1 = (int)(x0 + 1000 * (-b));
					int y1 = (int)(y0 + 1000 * (a));
					int x2 = (int)(x0 + 1000 * (-b));
					int y2 = (int)(y0 + 1000 * (b));
					tempImg.Draw(new LineSegment2D(new Point(x1, y1), new Point(x2, y2)), new Bgr(Color.Green), 2);
				}
				
				pictureBox1.Image = tempImg.ToBitmap();
			}
			
			// sobel
			/*
			Image<Bgr, Byte> img = new Image<Bgr, byte>(displayAdapter1.Image.ConvertToBitmap());
			Image<Gray, byte> gImg = img.Convert<Gray, byte>();
			Image<Gray, float> sobel = gImg.Sobel(0, 1, 3).Add(gImg.Sobel(1, 0, 3)).AbsDiff(new Gray(0.0));
			pictureBox1.Image = sobel.ToBitmap();
			*/

			//cvinvoke
			/*
			Image<Bgr, Byte> img = new Image<Bgr, byte>(displayAdapter1.Image.ConvertToBitmap());
			UMat uimage = new UMat();
			CvInvoke.CvtColor(img, uimage, Emgu.CV.CvEnum.ColorConversion.Bgr2Gray);
			UMat pyrDown = new UMat();
			CvInvoke.PyrDown(uimage, pyrDown);
			CvInvoke.PyrUp(pyrDown, uimage);

			UMat cannyEdges = new UMat();
			CvInvoke.Canny(uimage, cannyEdges, minTrackBar.Value, maxTrackBar.Value);
			Image<Bgr, byte> tempImage = cannyEdges.ToImage<Bgr, byte>();
			pictureBox1.Image = tempImage.Bitmap;

			if (houghCheckBox.Checked) {
				LineSegment2D[] lines = CvInvoke.HoughLinesP(cannyEdges, 1, Math.PI / 180.0, houghThreshholdBar.Value, 0, 0);
				foreach (LineSegment2D l in lines) {
					tempImage.Draw(l, new Bgr(Color.Green), 2);
				}
				pictureBox1.Image = tempImage.Bitmap;
			}
			*/


		}

		private void minTrackBar_Scroll(object sender, EventArgs e) {
			CannyButton_Click(null, null);
			minLabel.Text = minTrackBar.Value.ToString();
		}

		private void maxTrackBar_Scroll(object sender, EventArgs e) {
			CannyButton_Click(null, null);
			maxLabel.Text = maxTrackBar.Value.ToString();
		}

		private void houghThreshholdBar_Scroll(object sender, EventArgs e) {
			CannyButton_Click(null, null);
			thresholdLabel.Text = houghThreshholdBar.Value.ToString();
		}

	}
}
