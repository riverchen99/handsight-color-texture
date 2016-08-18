﻿///Use the define that is good for your needs:
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
using System.Threading.Tasks;
using System.Threading;

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
		string lockObj = "lockObj";
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
			provider.WriteRegister(new NanEyeGSRegisterPayload(false, 0x05, true, 0, trackBar1.Value));
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
			if (Monitor.TryEnter(lockObj)) {
				try {
					Invoke(new MethodInvoker(delegate { checkCrossing(); }));
				} catch { } finally { Monitor.Exit(lockObj); }
			}
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
			// gaussian blur
			Image<Bgr, Byte> img = new Image<Bgr, byte>(displayAdapter1.Image.ConvertToBitmap());
			Image<Gray, byte> filteredImg = img.Convert<Gray, byte>().PyrDown().PyrUp();
			Image<Gray, byte> cannyImg = filteredImg.Canny(minTrackBar.Value, maxTrackBar.Value);
			pictureBox1.Image = cannyImg.ToBitmap();

			if (houghCheckBox.Checked) {
				Image<Bgr, byte> tempImg = cannyImg.Convert<Bgr, byte>();
				Emgu.CV.Util.VectorOfPointF points = new Emgu.CV.Util.VectorOfPointF();
				CvInvoke.HoughLines(cannyImg, points, 1, Math.PI / 180.0, houghThreshholdBar.Value);
				PointF[] pointArray = points.ToArray();
				List<polarEq> polarEqList = new List<polarEq>();
				foreach (PointF p in pointArray) {
					if (!(p.X == 7 && p.Y == 0) && !(p.X == 637 && p.Y == 0)) { // remove vertical lines (side)
						polarEqList.Add(new polarEq(p.X, p.Y));
					}
				}
				polarEqList = polarEqList.OrderBy(list => list.theta).ToList();


				List<int> splitIndices = new List<int>() { -1 }; // where to split
				for (int i = 0; i < polarEqList.Count - 1; i++) {
					if ((polarEqList[i + 1].theta - polarEqList[i].theta) > .1) {
						splitIndices.Add(i);
					}
				}
				splitIndices.Add(polarEqList.Count - 1);


				List<List<polarEq>> eqGroups = new List<List<polarEq>>(); // split into groups
				for (int i = 0; i < splitIndices.Count - 1; i++) {
					eqGroups.Add(polarEqList.Take(splitIndices[i+1]+1).Skip(splitIndices[i]+1).ToList<polarEq>());
				}

				outputLabel.Text = "";
				foreach (List<polarEq> group in eqGroups) {
					foreach (polarEq eq in group) {
						outputLabel.Text += eq + "\n";
					}
					outputLabel.Text += "\n";
				}

				if (polarEqList.Count == 0) {
					outputLabel2.Text = "No pattern.";
				} else if (eqGroups.Count == 1) {
					outputLabel2.Text = "Stripes.";
				} else if (eqGroups.Count == 2 && (Math.Abs(Math.Abs(eqGroups.First().First().theta - eqGroups.Last().First().theta) > Math.PI ? Math.Abs(eqGroups.First().First().theta - eqGroups.Last().First().theta) - Math.PI : Math.Abs(eqGroups.First().First().theta - eqGroups.Last().First().theta)) - Math.PI/2) < .1) {
					outputLabel2.Text = "Checkers";
				} else {
					outputLabel2.Text = "unknown pattern";
				}

				foreach (polarEq eq in polarEqList) { // drawing
					tempImg.Draw(new LineSegment2D(new Point(eq.x1, eq.y1), new Point(eq.x2, eq.y2)), new Bgr(Color.Green), 2);
				}

				tempImg.Draw();
				pictureBox1.Image = tempImg.ToBitmap();
			}
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

		bool crossing;
		private void checkCrossing() {
			bool temp = crossing;
			CannyButton_Click(null, null);
			Bitmap snap = new Bitmap(pictureBox1.Image);
			crossing = false;
			for (int i = 310; i <= 330; i++) {
				for (int j = 0; j <= 330; j++) {
					if (snap.GetPixel(i, j) == Color.Green) {
						crossing = true;
					}
				}
			}
			if (temp != crossing) {
				if (crossing) {
					Console.Beep(1000, 100000);
				} else {
					Console.Beep(1000, 1);
				}
			}
		}
	}

	public struct polarEq {
		public float rho, theta;
		public double a, b, x0, y0;
		public int x1, y1, x2, y2;
		public polarEq(float r, float t) {
			rho = r;
			theta = t;
			a = Math.Cos(theta);
			b = Math.Sin(theta);
			x0 = rho * a;
			y0 = rho * b;
			x1 = (int)(x0 + 1000 * (-b));
			y1 = (int)(y0 + 1000 * (a));
			x2 = (int)(x0 - 1000 * (-b));
			y2 = (int)(y0 - 1000 * (a));
		}
		public override string ToString() {
			return string.Format("rho: {0}, theta: {1}", rho, theta);
		}
	}
}
