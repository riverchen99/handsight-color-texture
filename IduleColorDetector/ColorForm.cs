///Use the define that is good for your needs:
///IduleCam0 -> Get data from the first (or only) camera that is connected
///IduleCam1 -> Get data from the second camera that is connected. If only one camera is connected, then this will give an error
///IduleStereo -> Get data from two cameras simultaneously


//#define IduleCam0_raw
#define IduleCam0_processed
//#define IduleCam1_raw
//#define IduleCam1_processed
//#define IduleStereo_raw
//#define IduleStereo_processed

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
using System.Text.RegularExpressions;
using ColorMine;

namespace IduleCamProvider {
	public partial class ColorForm : Form {
		private KnownColor[] toRemove = {KnownColor.ActiveBorder, // system colors
										KnownColor.ActiveCaption,
										KnownColor.ActiveCaptionText,
										KnownColor.AppWorkspace,
										KnownColor.ButtonFace,
										KnownColor.ButtonHighlight,
										KnownColor.ButtonShadow,
										KnownColor.Control, 
										KnownColor.ControlDark,
										KnownColor.ControlDarkDark, 
										KnownColor.ControlLight,
										KnownColor.ControlLightLight, 
										KnownColor.ControlText,
										KnownColor.Desktop, 
										KnownColor.GradientActiveCaption,
										KnownColor.GradientInactiveCaption,
										KnownColor.GrayText,
										KnownColor.Highlight, 
										KnownColor.HighlightText, 
										KnownColor.HotTrack,
										KnownColor.InactiveBorder, 
										KnownColor.InactiveCaption, 
										KnownColor.InactiveCaptionText, 
										KnownColor.Info,
										KnownColor.InfoText,
										KnownColor.Menu,
										KnownColor.MenuBar, 
										KnownColor.MenuHighlight, 
										KnownColor.MenuText, 
										KnownColor.ScrollBar, 
										KnownColor.Window, 
										KnownColor.WindowFrame, 
										KnownColor.WindowText};
		private List<KnownColor> knownColors = new List<KnownColor>((KnownColor[])Enum.GetValues(typeof(KnownColor)));
		static int bins = 72;
		List<int> hueHistData = new List<int>(new int[bins]), satHistData = new List<int>(new int[bins]), lumHistData = new List<int>(new int[bins]);
		List<Color> colors = new List<Color>();
		List<Tuple<List<int>, List<int>, List<int>, String>> savedMaterials = new List<Tuple<List<int>, List<int>, List<int>, string>>();
		int totalR = 0, totalG = 0, totalB = 0;
		float totalH = 0, totalS = 0, totalL = 0;
		int pxCount;// = 62500;
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
		public ColorForm() {
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

			foreach (KnownColor c in toRemove) {
				knownColors.Remove(c);
			}

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

		private void GetPixels() {
			hueHistData = new List<int>(new int[bins]);
			satHistData = new List<int>(new int[bins]);
			lumHistData = new List<int>(new int[bins]);
			colors = new List<Color>();
			totalR = totalG = totalB = 0;
			totalH = totalS = totalL = 0;
			pxCount = 0;

			Image<Bgr, byte> img = new Image<Bgr, byte>(displayAdapter1.Image.ConvertToBitmap());

			img = img.SmoothGaussian(7).PyrDown().PyrDown();
			img.ROI = new Rectangle(new Point(75, 75), new Size(100, 100));
			//pictureBox1.Image = img.PyrUp().PyrUp().ToBitmap();

			Bitmap snap = img.ToBitmap();
			for (int i = 0; i < snap.Width; i++) {
				for (int j = 0; j < snap.Height; j++) {
					Color c = snap.GetPixel(i, j);
					colors.Add(c);
					hueHistData[(int)(c.GetHue() * (bins / 360.0))]++;
					satHistData[(int)((c.GetSaturation() - .00001) * bins)]++; // prevent c.GetSaturation() = 1
					lumHistData[(int)((c.GetBrightness() - .00001) * bins)]++;
					totalR += c.R;
					totalG += c.G;
					totalB += c.B;
					totalH += c.GetHue();
					totalS += c.GetSaturation();
					totalL += c.GetBrightness();
					pxCount++;

				}
			}
		}

		private void GenerateHist(List<int> histData) {
			Bitmap histImg = new Bitmap(625, 360);
			histBox.Image = histImg;
			Graphics g1 = Graphics.FromImage(histImg);

			for (int bin = 0; bin < histData.Count; bin++) {
				g1.FillRectangle(new SolidBrush(ColorFromHSL(1.0 * bin / bins, 1.0, .5)), new Rectangle(0, bin * (360 / bins), histData[bin] / 100, 360 / bins));
			}

			//smoothing
			List<int> smoothedHistData = new List<int>(histData);
			smoothedHistData[0] = (histData.Last() + histData[0] + histData[1]) / 3;
			smoothedHistData[smoothedHistData.Count - 1] = (histData[histData.Count - 2] + histData.Last() + histData[0]) / 3;
			for (int bin = 1; bin < histData.Count - 1; bin++) {
				smoothedHistData[bin] = (histData[bin - 1] + histData[bin] + histData[bin + 1]) / 3;
			}

			//generate smoothed histogram
			Bitmap histSmoothedImg = new Bitmap(625, 360);
			smoothedHistBox.Image = histSmoothedImg;
			Graphics g2 = Graphics.FromImage(histSmoothedImg);

			for (int bin = 0; bin < smoothedHistData.Count; bin++) {
				g2.FillRectangle(new SolidBrush(ColorFromHSL(1.0 * bin / bins, 1.0, .5)), new Rectangle(0, bin * (360 / bins), smoothedHistData[bin] / 100, 360 / bins));
			}
		}

		private double RGBColorDistance(Color c1, Color c2) {
			return Math.Pow(Math.Pow((double)(c1.R - c2.R), 2.0) + Math.Pow((double)(c1.G - c2.G), 2.0) + Math.Pow((double)(c1.B - c2.B), 2.0), .5);
		}

		// from http://james-ramsden.com/convert-from-hsl-to-rgb-colour-codes-in-c/
		public static Color ColorFromHSL(double h, double s, double l) {
			double r = 0, g = 0, b = 0;
			if (l != 0) {
				if (s == 0)
					r = g = b = l;
				else {
					double temp2;
					if (l < 0.5)
						temp2 = l * (1.0 + s);
					else
						temp2 = l + s - (l * s);

					double temp1 = 2.0 * l - temp2;

					r = GetColorComponent(temp1, temp2, h + 1.0 / 3.0);
					g = GetColorComponent(temp1, temp2, h);
					b = GetColorComponent(temp1, temp2, h - 1.0 / 3.0);
				}
			}
			return Color.FromArgb((int)(255 * r), (int)(255 * g), (int)(255 * b));
		}

		private static double GetColorComponent(double temp1, double temp2, double temp3) {
			if (temp3 < 0.0)
				temp3 += 1.0;
			else if (temp3 > 1.0)
				temp3 -= 1.0;

			if (temp3 < 1.0 / 6.0)
				return temp1 + (temp2 - temp1) * 6.0 * temp3;
			else if (temp3 < 0.5)
				return temp2;
			else if (temp3 < 2.0 / 3.0)
				return temp1 + ((temp2 - temp1) * ((2.0 / 3.0) - temp3) * 6.0);
			else
				return temp1;
		}

		private void saveButton_Click(object sender, EventArgs e) {
			GetPixels();
			savedMaterials.Add(new Tuple<List<int>, List<int>, List<int>, String>(new List<int>(hueHistData), new List<int>(satHistData), new List<int>(lumHistData), colorNameBox.Text));
			colorNameBox.Text = "";
		}

		private void guessButton_Click(object sender, EventArgs e) {
			GetPixels();
			int minDif = Int32.MaxValue;
			string closestName = "";
			foreach (Tuple<List<int>, List<int>, List<int>, String> material in savedMaterials) {
				int s = 0;
				for (int bin = 0; bin < bins; bin++) {
					s += Math.Abs(material.Item1[bin] - hueHistData[bin]);
					s += Math.Abs(material.Item2[bin] - satHistData[bin]);
					s += Math.Abs(material.Item3[bin] - lumHistData[bin]);
				}
				if (s < minDif) {
					minDif = s;
					closestName = material.Item4;
				}
			}
			//Console.WriteLine(minDif);
			if (minDif < 10000) {
				similarityLabel.Text = closestName;
			} else {
				similarityLabel.Text = "???";
			}
		}

		private void AverageColorButton_Click(object sender, EventArgs e) {
			GetPixels();
			// display average rgb color and closest knowncolor match
			Color avgRGBColor = Color.FromArgb(totalR / pxCount, totalG / pxCount, totalB / pxCount);
			Color avgHSLColor = ColorFromHSL(totalH / pxCount / 360, totalS / pxCount, totalL / pxCount);
			Color closestRGBColor = Color.Black;
			Color closestHueColor = Color.Black;
			Color[] myColorList = { 
									Color.Red,
									Color.Orange, 
									Color.Yellow, 
									Color.Green, 
									Color.Blue, 
									Color.Purple, 
									Color.Brown, 
									Color.Pink, 
									Color.White, 
									Color.Gray, 
									Color.LightGray,
									Color.DarkGray,
									Color.Black
								  };
			/*
			foreach (KnownColor c in knownColors) {
				closestColor = RGBColorDistance(avgRGBColor, Color.FromKnownColor(c)) < RGBColorDistance(avgRGBColor, closestColor) ? Color.FromKnownColor(c) : closestColor;
			}
			*/
			var colorMineAvg = new ColorMine.ColorSpaces.Rgb { R = totalR / pxCount, G = totalG / pxCount, B = totalB / pxCount };
			var colorMineClosest = new ColorMine.ColorSpaces.Rgb { R = 0, G = 0, B = 0 };
			foreach (Color c in myColorList) {
				closestRGBColor = RGBColorDistance(avgRGBColor, c) < RGBColorDistance(avgRGBColor, closestRGBColor) ? c : closestRGBColor;
				closestHueColor = Math.Abs(c.GetHue() - totalH / pxCount) < Math.Abs(closestHueColor.GetHue() - totalH / pxCount) ? c : closestHueColor;
				colorMineClosest = colorMineAvg.Compare(colorMineClosest, new ColorMine.ColorSpaces.Comparisons.CieDe2000Comparison()) < colorMineAvg.Compare(new ColorMine.ColorSpaces.Rgb { R = c.R, G = c.G, B = c.B }, new ColorMine.ColorSpaces.Comparisons.CieDe2000Comparison()) ? colorMineClosest : new ColorMine.ColorSpaces.Rgb { R = c.R, G = c.G, B = c.B };

				Console.WriteLine(colorMineAvg.Compare(new ColorMine.ColorSpaces.Rgb { R = c.R, G = c.G, B = c.B }, new ColorMine.ColorSpaces.Comparisons.CieDe2000Comparison()));
			}
			
			Console.WriteLine("r {0}, g {1}, b {2}", colorMineClosest.R, colorMineClosest.G, colorMineClosest.B);
			Console.WriteLine(colorMineAvg.Compare(colorMineClosest, new ColorMine.ColorSpaces.Comparisons.CieDe2000Comparison()));

			/*
			if (totalL / pxCount < .1) {
				closestHueColor = Color.Black;
			} else if (totalL / pxCount > .9) {
				closestHueColor = Color.White;
			} else if (totalL / pxCount < .2 && totalS / pxCount < .1) {
				closestHueColor = Color.Gray;
			}
			*/

			AvgRGBLabel.Text = String.Format("r {0}, g {1}, b {2}", avgRGBColor.R, avgRGBColor.G, avgRGBColor.B);
			AvgRGBColorBox.BackColor = avgRGBColor;

			AvgHSLLabel.Text = String.Format("h {0}, s {1}, l {2}", avgHSLColor.GetHue(), avgHSLColor.GetSaturation(), avgHSLColor.GetBrightness());
			AvgHSLColorBox.BackColor = avgHSLColor;

			ClosestRGBLabel.Text = String.Format("r {0}, g {1}, b {2}", closestRGBColor.R, closestRGBColor.G, closestRGBColor.B) + " " + Regex.Replace(closestRGBColor.Name, "(\\B[A-Z])", " $1");
			ClosestRGBColorBox.BackColor = closestRGBColor;

			ClosestHueLabel.Text = String.Format("h {0}, s {1}, l {2}", closestHueColor.GetHue(), closestHueColor.GetSaturation(), closestHueColor.GetBrightness()) + " " + Regex.Replace(closestHueColor.Name, "(\\B[A-Z])", " $1");
			ClosestHueColorBox.BackColor = closestHueColor;
			//ClosestHueColorBox.BackColor = ColorFromHSL(closestHueColor.GetHue() / 360, totalS / pxCount, totalL / pxCount);

			CIERGBLabel.Text = String.Format("r {0}, g {1}, b {2}", (int)colorMineClosest.R, (int)colorMineClosest.G, (int)colorMineClosest.B);
			CIERGBColorBox.BackColor = Color.FromArgb((int) colorMineClosest.R, (int) colorMineClosest.G, (int) colorMineClosest.B);

			if (colorMineClosest.R == 255 && colorMineClosest.G == 255 && colorMineClosest.B == 255) {
				FinalColorGuessLabel.Text = "White";
			} else if (colorMineClosest.R == 0 && colorMineClosest.G == 0 && colorMineClosest.B == 0) {
				FinalColorGuessLabel.Text = "Black";
			} else {
				FinalColorGuessLabel.Text = Regex.Replace(closestHueColor.Name, "(\\B[A-Z])", " $1");
			}

			//TTS(Regex.Replace(closestColor.Name, "(\\B[A-Z])", " $1"));
			/*
			Bitmap snap = new Bitmap(pictureBox1.Image);
			var colorThief = new ColorThief.ColorThief();
			var x = colorThief.GetColor(snap).Color;
			closestColorBox.BackColor = System.Drawing.Color.FromArgb(x.R, x.G, x.B);
			 */
		}

		private void HueHistButton_Click(object sender, EventArgs e) {
			GetPixels();
			GenerateHist(hueHistData);
		}

		private void SatHistButton_Click(object sender, EventArgs e) {
			GetPixels();
			GenerateHist(satHistData);
		}

		private void LumHistButton_Click(object sender, EventArgs e) {
			GetPixels();
			GenerateHist(lumHistData);
		}

		string prevColor;
		private void checkCrossing() {
			Thread beepThread = new Thread(new ThreadStart(delegate() { Console.Beep(1000, 500); }));
			beepThread.IsBackground = true;
			guessButton_Click(null, null);
			if (prevColor != similarityLabel.Text) {
				beepThread.Start();
				prevColor = similarityLabel.Text;
			}
		}
	}
}
