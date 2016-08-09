using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Awaiba.Drivers.Grabbers;
using Awaiba.FrameProcessing;
using System.IO;
using System.Speech.Synthesis;
using System.Text.RegularExpressions;
using System.Threading;
//using ColorThief;
namespace ColorDetector {
	public partial class Form1 : Form {
		private KnownColor[] toRemove = {KnownColor.ActiveBorder,
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
		NanEye2DNanoUSB2Provider provider;
		private SpeechSynthesizer reader = new SpeechSynthesizer();

		public Form1() {
			Awaiba.Drivers.Grabbers.Location.Paths.FpgaFilesDirectory = @"C:\Users\Makeability\Source\Repos\handsight-color-texture\dependencies\fpga files\";
			Awaiba.Drivers.Grabbers.Location.Paths.BinFile = @"nanousb2_fpga_v07.bin";
			provider = new NanEye2DNanoUSB2Provider();
			InitializeComponent();
			System.Threading.Thread.Sleep(1);
			provider.ImageProcessed += provider_ImageProcessed;
			provider.Exception += provider_Exception;

			/* NanEye Automatic Exposure Control Configuration
			* 
			* Please follow with the "NanEye - Automatic Exposure Control" PDF that can be found on Awaiba Webpage on the software tab:
			* 
			* For .NET (C# or C++/CLI), please go to "AEC in .NET"*/

			/***In classes of "Cesys Provider DLL": ***/

			///Value that the algorithm will try to get by changing the sensor exposure and gain
			provider.AutomaticExpControl().TargetGreyValue = 512;

			///Values used inside the algorithm
			provider.AutomaticExpControl().Hysteresis = 16;
			provider.AutomaticExpControl().StepSize = 8;
			provider.AutomaticExpControl().FrameNumber = 0;

			///Enable the algorithm (value 0); Disable -> value 1;
			provider.AutomaticExpControl().Enabled = 0;

			///The ShowROI will show the Region of Interest and the current values of the Gain and Exposure
			provider.AutomaticExpControl().ShowROI = 0;

			///How to define the region of interest (where the algorithm will calculate the value so that it matches the "Target Grey Value":
			///topROI: Top Line
			///bottomROI: Bottom line
			///LeftROI: Left Column
			///RightROI: Right Column
			///The region that is inside this four lines is the region of intereset
			provider.AutomaticExpControl().TopROI = 50;
			provider.AutomaticExpControl().BottomROI = 200;
			provider.AutomaticExpControl().LeftROI = 50;
			provider.AutomaticExpControl().RightROI = 200;

			//To send the value 3 to Offset
			provider.WriteRegister(new NanEyeRegisterPayload(false, 0x02, true, 0, 3));

			//To send the value 2 to Gain
			provider.WriteRegister(new NanEyeRegisterPayload(false, 0x01, true, 0, 2));

			//To send the value 250 to exposure
			provider.WriteRegister(new NanEyeRegisterPayload(false, 0x03, true, 0, 249));

			////To send the value 1.8 to the digipot
			provider.WriteRegister(new NanEyeRegisterPayload(false, 0x04, true, 0, 2000));

			foreach (KnownColor c in toRemove) {
				knownColors.Remove(c);
			}
		}

		private void provider_Exception(object sender, OnExceptionEventArgs e) {
			Console.WriteLine(e.ex.Message);
		}

		string lockObj = "lockObj";
		private void provider_ImageProcessed(object sender, OnImageReceivedBitmapEventArgs e) {
			if (Monitor.TryEnter(lockObj)) {
				try {
					Bitmap temp = ProcessingWrapper.pr[0].CreateProcessedBitmap(e.GetImageData);
					// update the UI in the main thread to avoid annoying InvalidOperationException issues
					Invoke(new MethodInvoker(delegate { pictureBox1.Image = temp; }));
				} catch { } finally { Monitor.Exit(lockObj); }
			}
		}

		private void button1_Click(object sender, EventArgs e) {
			provider.StartCapture();
		}

		private void button2_Click(object sender, EventArgs e) {
			provider.StopCapture();
		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e) {
			ProcessingWrapper.pr[0].colorReconstruction.Apply = checkBox1.Checked;
		}

		private void button3_Click(object sender, EventArgs e) {
			ProcessingWrapper.pr[0].TakeSnapshost().rawImage.Save("image.pgm");
			ProcessingWrapper.pr[0].TakeSnapshost().processedImage.Save("image.png");
		}

		private void button4_Click(object sender, EventArgs e) {
			if (button4.Text == "Record Raw Video") {
				ProcessingWrapper.pr[0].awRawVideo.StartVideo("Raw.awvideo");
				button4.Text = "Stop Recording...";
			} else if (button4.Text == "Stop Recording...") {
				ProcessingWrapper.pr[0].awRawVideo.Close();
				button4.Text = "Record Raw Video";
			}
		}

		private void button5_Click(object sender, EventArgs e) {
			if (button5.Text == "Record Processed Video") {
				ProcessingWrapper.pr[0].awVideo.StartVideo(45, "Processed.avi", true);
				button5.Text = "Stop Recording...";
			} else if (button5.Text == "Stop Recording...") {
				ProcessingWrapper.pr[0].awVideo.StopVideo();
				button5.Text = "Record Processed Video";
			}
		}

		private void aecCheckbox_CheckedChanged(object sender, EventArgs e) {
			gainTrackbar.Enabled = !aecCheckbox.Checked;
			provider.AutomaticExpControl().Enabled = 1 - Convert.ToInt32(aecCheckbox.Checked);
		}

		private void ledCheckbox_CheckedChanged(object sender, EventArgs e) {
			provider.WriteRegister(new NanEyeRegisterPayload(false, 0x05, true, 0, Convert.ToInt32(ledCheckbox.Checked)));
		}

		private void ledTrackbar_Scroll(object sender, EventArgs e) {
			provider.WriteRegister(new NanEyeRegisterPayload(false, 0x06, true, 0, Convert.ToInt32(ledTrackbar.Value)));
		}

		private void gainTrackbar_Scroll(object sender, EventArgs e) {
			provider.WriteRegister(new NanEyeRegisterPayload(false, 0x01, true, 0, Convert.ToInt32(gainTrackbar.Value)));
		}

		private void TTS(string text) {
			reader.SpeakAsyncCancelAll();
			reader.SpeakAsync(text);
		}

		private void ColorButton_Click(object sender, EventArgs e) {
			Dictionary<Color, int> colors = new Dictionary<Color, int>();
			int totalR = 0;
			int totalG = 0;
			int totalB = 0;

			// get pixels in image
			Bitmap snap = new Bitmap(pictureBox1.Image);
			int pxCount = snap.Width * snap.Height;
			for (int i = 0; i < snap.Width; i++) {
				for (int j = 0; j < snap.Height; j++) {
					Color pixel = snap.GetPixel(i, j);
					totalR += pixel.R;
					totalG += pixel.G;
					totalB += pixel.B;
					if (colors.ContainsKey((pixel))) { colors[pixel] += 1; } else { colors.Add(pixel, 1); }
				}
			}

			// display average rgb color and closest knowncolor match
			Color avgRGBColor = Color.FromArgb(totalR / pxCount, totalG / pxCount, totalB / pxCount);
			Color closestColor = Color.FromKnownColor(KnownColor.Black);
			foreach (KnownColor c in knownColors) {
				closestColor = ColorDistance(avgRGBColor, Color.FromKnownColor(c)) < ColorDistance(avgRGBColor, closestColor) ? Color.FromKnownColor(c) : closestColor;
			}
			ColorLabel.Text = Regex.Replace(closestColor.Name, "(\\B[A-Z])", " $1");
			TTS(Regex.Replace(closestColor.Name, "(\\B[A-Z])", " $1"));
			actualColorBox.BackColor = avgRGBColor;
			closestColorBox.BackColor = closestColor;

			// generate histogram
			var sortedKeys = colors.Keys.ToList();
			sortedKeys.Sort(new ColorComparer());
			List<int> histData = new List<int>();
			int bins = 108;
			foreach (Color c in sortedKeys) {
				if (histData.Count > c.GetHue() * (bins/360.0)) {
					histData[(int)(c.GetHue() * (bins/360.0))] += colors[c];
				} else {
					histData.Add(colors[c]);
				}
			}

			Bitmap histImg = new Bitmap(625, 360);

			histBox.Image = histImg;
			Graphics g1 = Graphics.FromImage(histImg);

			int s = 0;
			for (int bin = 0; bin < histData.Count; bin++) {
				s += histData[bin];
				g1.FillRectangle(new SolidBrush(ColorFromHSL(1.0 * bin / bins, 1.0, .5)), new Rectangle(0, bin * (360 / bins), histData[bin] / 100, 360 / bins));
			}
			Console.WriteLine(s);
			Console.WriteLine(histData.Max());
			/*
			Dictionary<Color, int> smoothedColors = new Dictionary<Color, int>();
			smoothedColors[sortedKeys[0]] = (colors[sortedKeys.Last()] + colors[sortedKeys[0]] + colors[sortedKeys[1]]) / 3;
			smoothedColors[sortedKeys.Last()] = (colors[sortedKeys[sortedKeys.Count - 2]] + colors[sortedKeys.Last()] + colors[sortedKeys[0]]) / 3;
			for (int c = 1; c < sortedKeys.Count - 1; c++) {
				smoothedColors[sortedKeys[c]] = (colors[sortedKeys[c - 1]] + colors[sortedKeys[c]] + colors[sortedKeys[c + 1]]) / 3;
			}

			Bitmap histSmoothed = new Bitmap(360, smoothedColors.Values.Max());
			smoothedHistBox.Image = histSmoothed;
			Graphics g2 = Graphics.FromImage(histSmoothed);
			sortedKeys = smoothedColors.Keys.ToList();
			sortedKeys.Sort(new ColorComparer());
			foreach (Color c in sortedKeys) {
				g2.FillRectangle(new SolidBrush(c), new Rectangle((int)c.GetHue(), 0, 1, smoothedColors[c]));
			}

			Color highestColor = smoothedColors[sortedKeys[0]] > smoothedColors[sortedKeys.Last()] ? sortedKeys[0] : sortedKeys.Last();
			for (int c = 1; c < sortedKeys.Count - 1; c++) {
				highestColor = colors[highestColor] > colors[sortedKeys[c-1]] + colors[sortedKeys[c]] + colors[sortedKeys[c+1]] ? highestColor : sortedKeys[c];
			}
			
			foreach (KnownColor c in knownColors) {
				closestColor = ColorDistance(highestColor, Color.FromKnownColor(c)) < ColorDistance(highestColor, closestColor) ? Color.FromKnownColor(c) : closestColor;
			}
			ColorLabel2.Text = Regex.Replace(closestColor.Name, "(\\B[A-Z])", " $1");
			TTS(Regex.Replace(closestColor.Name, "(\\B[A-Z])", " $1"));
			highestColorBox.BackColor = highestColor;
			closestColorBox2.BackColor = closestColor;
			*/

			/*
			Bitmap snap = new Bitmap(pictureBox1.Image);
			var colorThief = new ColorThief.ColorThief();
			var x = colorThief.GetColor(snap).Color;
			closestColorBox.BackColor = System.Drawing.Color.FromArgb(x.R, x.G, x.B);
			 */
		}

		private double ColorDistance(Color c1, Color c2) {
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

		public class ColorComparer : IComparer<Color> {
			public int Compare(Color a, Color b) {
				return Math.Sign(a.GetHue() - b.GetHue());
			}
		}

	}
}
