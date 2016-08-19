namespace IduleCamProvider {
	partial class ColorForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.displayAdapter1 = new Awaiba.Controls.DisplayAdapter();
			this.button5 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.colorCheckBox = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.trackBar1 = new System.Windows.Forms.TrackBar();
			this.saveRawImgButton = new System.Windows.Forms.Button();
			this.StopButton = new System.Windows.Forms.Button();
			this.StartButton = new System.Windows.Forms.Button();
			this.LumHistButton = new System.Windows.Forms.Button();
			this.SatHistButton = new System.Windows.Forms.Button();
			this.HueHistButton = new System.Windows.Forms.Button();
			this.colorNameBox = new System.Windows.Forms.TextBox();
			this.similarityLabel = new System.Windows.Forms.Label();
			this.guessButton = new System.Windows.Forms.Button();
			this.saveButton = new System.Windows.Forms.Button();
			this.closestColorBox = new System.Windows.Forms.PictureBox();
			this.ColorLabel = new System.Windows.Forms.Label();
			this.actualColorBox = new System.Windows.Forms.PictureBox();
			this.AverageColorButton = new System.Windows.Forms.Button();
			this.smoothedHistBox = new System.Windows.Forms.PictureBox();
			this.histBox = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.closestColorBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.actualColorBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.smoothedHistBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.histBox)).BeginInit();
			this.SuspendLayout();
			// 
			// displayAdapter1
			// 
			this.displayAdapter1.Location = new System.Drawing.Point(256, 13);
			this.displayAdapter1.Margin = new System.Windows.Forms.Padding(4);
			this.displayAdapter1.Name = "displayAdapter1";
			this.displayAdapter1.Size = new System.Drawing.Size(853, 788);
			this.displayAdapter1.TabIndex = 39;
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(13, 120);
			this.button5.Margin = new System.Windows.Forms.Padding(4);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(208, 28);
			this.button5.TabIndex = 38;
			this.button5.Text = "Record Processed Video";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(13, 84);
			this.button4.Margin = new System.Windows.Forms.Padding(4);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(208, 28);
			this.button4.TabIndex = 37;
			this.button4.Text = "Record Raw Video";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// colorCheckBox
			// 
			this.colorCheckBox.AutoSize = true;
			this.colorCheckBox.Checked = true;
			this.colorCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.colorCheckBox.Location = new System.Drawing.Point(20, 208);
			this.colorCheckBox.Margin = new System.Windows.Forms.Padding(4);
			this.colorCheckBox.Name = "colorCheckBox";
			this.colorCheckBox.Size = new System.Drawing.Size(162, 21);
			this.colorCheckBox.TabIndex = 36;
			this.colorCheckBox.Text = "Color Reconstruction";
			this.colorCheckBox.UseVisualStyleBackColor = true;
			this.colorCheckBox.CheckedChanged += new System.EventHandler(this.colorCheckBox_CheckedChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(14, 164);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(75, 17);
			this.label1.TabIndex = 35;
			this.label1.Text = "Pre-Scaler";
			// 
			// trackBar1
			// 
			this.trackBar1.AutoSize = false;
			this.trackBar1.Location = new System.Drawing.Point(88, 158);
			this.trackBar1.Margin = new System.Windows.Forms.Padding(4);
			this.trackBar1.Maximum = 255;
			this.trackBar1.Name = "trackBar1";
			this.trackBar1.Size = new System.Drawing.Size(139, 31);
			this.trackBar1.TabIndex = 34;
			this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
			this.trackBar1.Value = 5;
			this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
			// 
			// saveRawImgButton
			// 
			this.saveRawImgButton.Location = new System.Drawing.Point(13, 48);
			this.saveRawImgButton.Margin = new System.Windows.Forms.Padding(4);
			this.saveRawImgButton.Name = "saveRawImgButton";
			this.saveRawImgButton.Size = new System.Drawing.Size(208, 28);
			this.saveRawImgButton.TabIndex = 33;
			this.saveRawImgButton.Text = "Take Snapshot";
			this.saveRawImgButton.UseVisualStyleBackColor = true;
			this.saveRawImgButton.Click += new System.EventHandler(this.saveRawImgButton_Click);
			// 
			// StopButton
			// 
			this.StopButton.Location = new System.Drawing.Point(121, 13);
			this.StopButton.Margin = new System.Windows.Forms.Padding(4);
			this.StopButton.Name = "StopButton";
			this.StopButton.Size = new System.Drawing.Size(100, 28);
			this.StopButton.TabIndex = 32;
			this.StopButton.Text = "Stop";
			this.StopButton.UseVisualStyleBackColor = true;
			this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
			// 
			// StartButton
			// 
			this.StartButton.Location = new System.Drawing.Point(13, 13);
			this.StartButton.Margin = new System.Windows.Forms.Padding(4);
			this.StartButton.Name = "StartButton";
			this.StartButton.Size = new System.Drawing.Size(100, 28);
			this.StartButton.TabIndex = 31;
			this.StartButton.Text = "Start";
			this.StartButton.UseVisualStyleBackColor = true;
			this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
			// 
			// LumHistButton
			// 
			this.LumHistButton.Location = new System.Drawing.Point(88, 704);
			this.LumHistButton.Name = "LumHistButton";
			this.LumHistButton.Size = new System.Drawing.Size(91, 42);
			this.LumHistButton.TabIndex = 61;
			this.LumHistButton.Text = "Lum Histogram";
			this.LumHistButton.UseVisualStyleBackColor = true;
			this.LumHistButton.Click += new System.EventHandler(this.LumHistButton_Click);
			// 
			// SatHistButton
			// 
			this.SatHistButton.Location = new System.Drawing.Point(88, 637);
			this.SatHistButton.Name = "SatHistButton";
			this.SatHistButton.Size = new System.Drawing.Size(91, 42);
			this.SatHistButton.TabIndex = 60;
			this.SatHistButton.Text = "Sat Histogram";
			this.SatHistButton.UseVisualStyleBackColor = true;
			this.SatHistButton.Click += new System.EventHandler(this.SatHistButton_Click);
			// 
			// HueHistButton
			// 
			this.HueHistButton.Location = new System.Drawing.Point(88, 572);
			this.HueHistButton.Name = "HueHistButton";
			this.HueHistButton.Size = new System.Drawing.Size(91, 42);
			this.HueHistButton.TabIndex = 59;
			this.HueHistButton.Text = "Hue Histogram";
			this.HueHistButton.UseVisualStyleBackColor = true;
			this.HueHistButton.Click += new System.EventHandler(this.HueHistButton_Click);
			// 
			// colorNameBox
			// 
			this.colorNameBox.Location = new System.Drawing.Point(13, 326);
			this.colorNameBox.Name = "colorNameBox";
			this.colorNameBox.Size = new System.Drawing.Size(100, 22);
			this.colorNameBox.TabIndex = 58;
			// 
			// similarityLabel
			// 
			this.similarityLabel.AutoSize = true;
			this.similarityLabel.Location = new System.Drawing.Point(172, 326);
			this.similarityLabel.Name = "similarityLabel";
			this.similarityLabel.Size = new System.Drawing.Size(23, 17);
			this.similarityLabel.TabIndex = 57;
			this.similarityLabel.Text = "---";
			// 
			// guessButton
			// 
			this.guessButton.Location = new System.Drawing.Point(129, 271);
			this.guessButton.Name = "guessButton";
			this.guessButton.Size = new System.Drawing.Size(111, 42);
			this.guessButton.TabIndex = 56;
			this.guessButton.Text = "Guess";
			this.guessButton.UseVisualStyleBackColor = true;
			this.guessButton.Click += new System.EventHandler(this.guessButton_Click);
			// 
			// saveButton
			// 
			this.saveButton.Location = new System.Drawing.Point(12, 271);
			this.saveButton.Name = "saveButton";
			this.saveButton.Size = new System.Drawing.Size(111, 42);
			this.saveButton.TabIndex = 55;
			this.saveButton.Text = "Save Histogram";
			this.saveButton.UseVisualStyleBackColor = true;
			this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
			// 
			// closestColorBox
			// 
			this.closestColorBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.closestColorBox.Location = new System.Drawing.Point(139, 438);
			this.closestColorBox.Margin = new System.Windows.Forms.Padding(4);
			this.closestColorBox.Name = "closestColorBox";
			this.closestColorBox.Size = new System.Drawing.Size(101, 94);
			this.closestColorBox.TabIndex = 54;
			this.closestColorBox.TabStop = false;
			// 
			// ColorLabel
			// 
			this.ColorLabel.AutoSize = true;
			this.ColorLabel.Location = new System.Drawing.Point(140, 417);
			this.ColorLabel.Name = "ColorLabel";
			this.ColorLabel.Size = new System.Drawing.Size(23, 17);
			this.ColorLabel.TabIndex = 53;
			this.ColorLabel.Text = "---";
			// 
			// actualColorBox
			// 
			this.actualColorBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.actualColorBox.Location = new System.Drawing.Point(12, 438);
			this.actualColorBox.Margin = new System.Windows.Forms.Padding(4);
			this.actualColorBox.Name = "actualColorBox";
			this.actualColorBox.Size = new System.Drawing.Size(101, 94);
			this.actualColorBox.TabIndex = 52;
			this.actualColorBox.TabStop = false;
			// 
			// AverageColorButton
			// 
			this.AverageColorButton.Location = new System.Drawing.Point(88, 368);
			this.AverageColorButton.Name = "AverageColorButton";
			this.AverageColorButton.Size = new System.Drawing.Size(75, 42);
			this.AverageColorButton.TabIndex = 51;
			this.AverageColorButton.Text = "Check Color";
			this.AverageColorButton.UseVisualStyleBackColor = true;
			this.AverageColorButton.Click += new System.EventHandler(this.AverageColorButton_Click);
			// 
			// smoothedHistBox
			// 
			this.smoothedHistBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.smoothedHistBox.Location = new System.Drawing.Point(1117, 417);
			this.smoothedHistBox.Margin = new System.Windows.Forms.Padding(4);
			this.smoothedHistBox.Name = "smoothedHistBox";
			this.smoothedHistBox.Size = new System.Drawing.Size(575, 360);
			this.smoothedHistBox.TabIndex = 63;
			this.smoothedHistBox.TabStop = false;
			// 
			// histBox
			// 
			this.histBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.histBox.Location = new System.Drawing.Point(1117, 34);
			this.histBox.Margin = new System.Windows.Forms.Padding(4);
			this.histBox.Name = "histBox";
			this.histBox.Size = new System.Drawing.Size(575, 360);
			this.histBox.TabIndex = 62;
			this.histBox.TabStop = false;
			// 
			// ColorForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1906, 826);
			this.Controls.Add(this.smoothedHistBox);
			this.Controls.Add(this.histBox);
			this.Controls.Add(this.LumHistButton);
			this.Controls.Add(this.SatHistButton);
			this.Controls.Add(this.HueHistButton);
			this.Controls.Add(this.colorNameBox);
			this.Controls.Add(this.similarityLabel);
			this.Controls.Add(this.guessButton);
			this.Controls.Add(this.saveButton);
			this.Controls.Add(this.closestColorBox);
			this.Controls.Add(this.ColorLabel);
			this.Controls.Add(this.actualColorBox);
			this.Controls.Add(this.AverageColorButton);
			this.Controls.Add(this.displayAdapter1);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.colorCheckBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.trackBar1);
			this.Controls.Add(this.saveRawImgButton);
			this.Controls.Add(this.StopButton);
			this.Controls.Add(this.StartButton);
			this.Name = "ColorForm";
			this.Text = "ColorForm";
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.closestColorBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.actualColorBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.smoothedHistBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.histBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Awaiba.Controls.DisplayAdapter displayAdapter1;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.CheckBox colorCheckBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TrackBar trackBar1;
		private System.Windows.Forms.Button saveRawImgButton;
		private System.Windows.Forms.Button StopButton;
		private System.Windows.Forms.Button StartButton;
		private System.Windows.Forms.Button LumHistButton;
		private System.Windows.Forms.Button SatHistButton;
		private System.Windows.Forms.Button HueHistButton;
		private System.Windows.Forms.TextBox colorNameBox;
		private System.Windows.Forms.Label similarityLabel;
		private System.Windows.Forms.Button guessButton;
		private System.Windows.Forms.Button saveButton;
		private System.Windows.Forms.PictureBox closestColorBox;
		private System.Windows.Forms.Label ColorLabel;
		private System.Windows.Forms.PictureBox actualColorBox;
		private System.Windows.Forms.Button AverageColorButton;
		private System.Windows.Forms.PictureBox smoothedHistBox;
		private System.Windows.Forms.PictureBox histBox;
	}
}