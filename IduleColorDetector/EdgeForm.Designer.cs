﻿namespace IduleProvider
{
    partial class EdgeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.colorCheckBox = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.trackBar1 = new System.Windows.Forms.TrackBar();
			this.saveRawImgButton = new System.Windows.Forms.Button();
			this.StopButton = new System.Windows.Forms.Button();
			this.StartButton = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.displayAdapter1 = new Awaiba.Controls.DisplayAdapter();
			this.edgeDetectButton = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.minTrackBar = new System.Windows.Forms.TrackBar();
			this.maxTrackBar = new System.Windows.Forms.TrackBar();
			this.minLabel = new System.Windows.Forms.Label();
			this.maxLabel = new System.Windows.Forms.Label();
			this.houghCheckBox = new System.Windows.Forms.CheckBox();
			this.houghThreshholdBar = new System.Windows.Forms.TrackBar();
			this.thresholdLabel = new System.Windows.Forms.Label();
			this.outputLabel = new System.Windows.Forms.Label();
			this.outputLabel2 = new System.Windows.Forms.Label();
			this.outputLabel3 = new System.Windows.Forms.Label();
			this.cannyCheckBox = new System.Windows.Forms.CheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.downscalingLabel = new System.Windows.Forms.Label();
			this.downscalingBar = new System.Windows.Forms.TrackBar();
			this.label6 = new System.Windows.Forms.Label();
			this.colorFactorLabel = new System.Windows.Forms.Label();
			this.colorFactorBar = new System.Windows.Forms.TrackBar();
			this.label8 = new System.Windows.Forms.Label();
			this.spatialFactorLabel = new System.Windows.Forms.Label();
			this.spatialFactorBar = new System.Windows.Forms.TrackBar();
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.minTrackBar)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.maxTrackBar)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.houghThreshholdBar)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.downscalingBar)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.colorFactorBar)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.spatialFactorBar)).BeginInit();
			this.SuspendLayout();
			// 
			// colorCheckBox
			// 
			this.colorCheckBox.AutoSize = true;
			this.colorCheckBox.Checked = true;
			this.colorCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.colorCheckBox.Location = new System.Drawing.Point(16, 199);
			this.colorCheckBox.Margin = new System.Windows.Forms.Padding(4);
			this.colorCheckBox.Name = "colorCheckBox";
			this.colorCheckBox.Size = new System.Drawing.Size(162, 21);
			this.colorCheckBox.TabIndex = 13;
			this.colorCheckBox.Text = "Color Reconstruction";
			this.colorCheckBox.UseVisualStyleBackColor = true;
			this.colorCheckBox.CheckedChanged += new System.EventHandler(this.colorCheckBox_CheckedChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(17, 166);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(75, 17);
			this.label1.TabIndex = 12;
			this.label1.Text = "Pre-Scaler";
			// 
			// trackBar1
			// 
			this.trackBar1.AutoSize = false;
			this.trackBar1.Location = new System.Drawing.Point(91, 160);
			this.trackBar1.Margin = new System.Windows.Forms.Padding(4);
			this.trackBar1.Maximum = 255;
			this.trackBar1.Name = "trackBar1";
			this.trackBar1.Size = new System.Drawing.Size(139, 31);
			this.trackBar1.TabIndex = 11;
			this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
			this.trackBar1.Value = 10;
			this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
			// 
			// saveRawImgButton
			// 
			this.saveRawImgButton.Location = new System.Drawing.Point(16, 50);
			this.saveRawImgButton.Margin = new System.Windows.Forms.Padding(4);
			this.saveRawImgButton.Name = "saveRawImgButton";
			this.saveRawImgButton.Size = new System.Drawing.Size(208, 28);
			this.saveRawImgButton.TabIndex = 10;
			this.saveRawImgButton.Text = "Take Snapshot";
			this.saveRawImgButton.UseVisualStyleBackColor = true;
			this.saveRawImgButton.Click += new System.EventHandler(this.saveRawImgButton_Click);
			// 
			// StopButton
			// 
			this.StopButton.Location = new System.Drawing.Point(124, 15);
			this.StopButton.Margin = new System.Windows.Forms.Padding(4);
			this.StopButton.Name = "StopButton";
			this.StopButton.Size = new System.Drawing.Size(100, 28);
			this.StopButton.TabIndex = 9;
			this.StopButton.Text = "Stop";
			this.StopButton.UseVisualStyleBackColor = true;
			this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
			// 
			// StartButton
			// 
			this.StartButton.Location = new System.Drawing.Point(16, 15);
			this.StartButton.Margin = new System.Windows.Forms.Padding(4);
			this.StartButton.Name = "StartButton";
			this.StartButton.Size = new System.Drawing.Size(100, 28);
			this.StartButton.TabIndex = 7;
			this.StartButton.Text = "Start";
			this.StartButton.UseVisualStyleBackColor = true;
			this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(16, 122);
			this.button5.Margin = new System.Windows.Forms.Padding(4);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(208, 28);
			this.button5.TabIndex = 16;
			this.button5.Text = "Record Processed Video";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(16, 86);
			this.button4.Margin = new System.Windows.Forms.Padding(4);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(208, 28);
			this.button4.TabIndex = 15;
			this.button4.Text = "Record Raw Video";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// displayAdapter1
			// 
			this.displayAdapter1.Location = new System.Drawing.Point(259, 15);
			this.displayAdapter1.Margin = new System.Windows.Forms.Padding(4);
			this.displayAdapter1.Name = "displayAdapter1";
			this.displayAdapter1.Size = new System.Drawing.Size(853, 788);
			this.displayAdapter1.TabIndex = 18;
			// 
			// edgeDetectButton
			// 
			this.edgeDetectButton.Location = new System.Drawing.Point(51, 716);
			this.edgeDetectButton.Margin = new System.Windows.Forms.Padding(4);
			this.edgeDetectButton.Name = "edgeDetectButton";
			this.edgeDetectButton.Size = new System.Drawing.Size(111, 28);
			this.edgeDetectButton.TabIndex = 19;
			this.edgeDetectButton.Text = "Detect Edges";
			this.edgeDetectButton.UseVisualStyleBackColor = true;
			this.edgeDetectButton.Click += new System.EventHandler(this.edgeDetectButton_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(1132, 15);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(853, 788);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// minTrackBar
			// 
			this.minTrackBar.AutoSize = false;
			this.minTrackBar.Location = new System.Drawing.Point(23, 323);
			this.minTrackBar.Margin = new System.Windows.Forms.Padding(4);
			this.minTrackBar.Maximum = 255;
			this.minTrackBar.Name = "minTrackBar";
			this.minTrackBar.Size = new System.Drawing.Size(139, 30);
			this.minTrackBar.TabIndex = 20;
			this.minTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
			this.minTrackBar.Value = 25;
			this.minTrackBar.Scroll += new System.EventHandler(this.minTrackBar_Scroll);
			// 
			// maxTrackBar
			// 
			this.maxTrackBar.AutoSize = false;
			this.maxTrackBar.Location = new System.Drawing.Point(23, 386);
			this.maxTrackBar.Margin = new System.Windows.Forms.Padding(4);
			this.maxTrackBar.Maximum = 255;
			this.maxTrackBar.Name = "maxTrackBar";
			this.maxTrackBar.Size = new System.Drawing.Size(139, 30);
			this.maxTrackBar.TabIndex = 21;
			this.maxTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
			this.maxTrackBar.Value = 125;
			this.maxTrackBar.Scroll += new System.EventHandler(this.maxTrackBar_Scroll);
			// 
			// minLabel
			// 
			this.minLabel.AutoSize = true;
			this.minLabel.Location = new System.Drawing.Point(184, 323);
			this.minLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.minLabel.Name = "minLabel";
			this.minLabel.Size = new System.Drawing.Size(24, 17);
			this.minLabel.TabIndex = 22;
			this.minLabel.Text = "25";
			// 
			// maxLabel
			// 
			this.maxLabel.AutoSize = true;
			this.maxLabel.Location = new System.Drawing.Point(180, 386);
			this.maxLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.maxLabel.Name = "maxLabel";
			this.maxLabel.Size = new System.Drawing.Size(32, 17);
			this.maxLabel.TabIndex = 23;
			this.maxLabel.Text = "120";
			// 
			// houghCheckBox
			// 
			this.houghCheckBox.AutoSize = true;
			this.houghCheckBox.Location = new System.Drawing.Point(136, 260);
			this.houghCheckBox.Margin = new System.Windows.Forms.Padding(4);
			this.houghCheckBox.Name = "houghCheckBox";
			this.houghCheckBox.Size = new System.Drawing.Size(72, 21);
			this.houghCheckBox.TabIndex = 24;
			this.houghCheckBox.Text = "Hough";
			this.houghCheckBox.UseVisualStyleBackColor = true;
			// 
			// houghThreshholdBar
			// 
			this.houghThreshholdBar.AutoSize = false;
			this.houghThreshholdBar.Location = new System.Drawing.Point(23, 449);
			this.houghThreshholdBar.Margin = new System.Windows.Forms.Padding(4);
			this.houghThreshholdBar.Maximum = 255;
			this.houghThreshholdBar.Name = "houghThreshholdBar";
			this.houghThreshholdBar.Size = new System.Drawing.Size(139, 30);
			this.houghThreshholdBar.TabIndex = 25;
			this.houghThreshholdBar.TickStyle = System.Windows.Forms.TickStyle.None;
			this.houghThreshholdBar.Value = 150;
			this.houghThreshholdBar.Scroll += new System.EventHandler(this.houghThreshholdBar_Scroll);
			// 
			// thresholdLabel
			// 
			this.thresholdLabel.AutoSize = true;
			this.thresholdLabel.Location = new System.Drawing.Point(180, 449);
			this.thresholdLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.thresholdLabel.Name = "thresholdLabel";
			this.thresholdLabel.Size = new System.Drawing.Size(32, 17);
			this.thresholdLabel.TabIndex = 26;
			this.thresholdLabel.Text = "150";
			// 
			// outputLabel
			// 
			this.outputLabel.AutoSize = true;
			this.outputLabel.Location = new System.Drawing.Point(20, 810);
			this.outputLabel.Name = "outputLabel";
			this.outputLabel.Size = new System.Drawing.Size(23, 17);
			this.outputLabel.TabIndex = 27;
			this.outputLabel.Text = "---";
			// 
			// outputLabel2
			// 
			this.outputLabel2.AutoSize = true;
			this.outputLabel2.Location = new System.Drawing.Point(20, 757);
			this.outputLabel2.Name = "outputLabel2";
			this.outputLabel2.Size = new System.Drawing.Size(23, 17);
			this.outputLabel2.TabIndex = 28;
			this.outputLabel2.Text = "---";
			// 
			// outputLabel3
			// 
			this.outputLabel3.AutoSize = true;
			this.outputLabel3.Location = new System.Drawing.Point(155, 757);
			this.outputLabel3.Name = "outputLabel3";
			this.outputLabel3.Size = new System.Drawing.Size(23, 17);
			this.outputLabel3.TabIndex = 29;
			this.outputLabel3.Text = "---";
			// 
			// cannyCheckBox
			// 
			this.cannyCheckBox.AutoSize = true;
			this.cannyCheckBox.Location = new System.Drawing.Point(16, 260);
			this.cannyCheckBox.Margin = new System.Windows.Forms.Padding(4);
			this.cannyCheckBox.Name = "cannyCheckBox";
			this.cannyCheckBox.Size = new System.Drawing.Size(70, 21);
			this.cannyCheckBox.TabIndex = 30;
			this.cannyCheckBox.Text = "Canny";
			this.cannyCheckBox.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(23, 298);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(98, 17);
			this.label2.TabIndex = 31;
			this.label2.Text = "Min Threshold";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(23, 361);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(101, 17);
			this.label3.TabIndex = 32;
			this.label3.Text = "Max Threshold";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(23, 424);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(118, 17);
			this.label4.TabIndex = 33;
			this.label4.Text = "Hough Threshold";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(23, 487);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(139, 17);
			this.label5.TabIndex = 36;
			this.label5.Text = "Downscaling Amount";
			// 
			// downscalingLabel
			// 
			this.downscalingLabel.AutoSize = true;
			this.downscalingLabel.Location = new System.Drawing.Point(188, 512);
			this.downscalingLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.downscalingLabel.Name = "downscalingLabel";
			this.downscalingLabel.Size = new System.Drawing.Size(16, 17);
			this.downscalingLabel.TabIndex = 35;
			this.downscalingLabel.Text = "0";
			// 
			// downscalingBar
			// 
			this.downscalingBar.AutoSize = false;
			this.downscalingBar.Location = new System.Drawing.Point(23, 512);
			this.downscalingBar.Margin = new System.Windows.Forms.Padding(4);
			this.downscalingBar.Maximum = 7;
			this.downscalingBar.Name = "downscalingBar";
			this.downscalingBar.Size = new System.Drawing.Size(139, 30);
			this.downscalingBar.TabIndex = 34;
			this.downscalingBar.TickStyle = System.Windows.Forms.TickStyle.None;
			this.downscalingBar.Scroll += new System.EventHandler(this.downscalingBar_Scroll);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(23, 550);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(85, 17);
			this.label6.TabIndex = 39;
			this.label6.Text = "Color Factor";
			// 
			// colorFactorLabel
			// 
			this.colorFactorLabel.AutoSize = true;
			this.colorFactorLabel.Location = new System.Drawing.Point(188, 575);
			this.colorFactorLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.colorFactorLabel.Name = "colorFactorLabel";
			this.colorFactorLabel.Size = new System.Drawing.Size(16, 17);
			this.colorFactorLabel.TabIndex = 38;
			this.colorFactorLabel.Text = "0";
			// 
			// colorFactorBar
			// 
			this.colorFactorBar.AutoSize = false;
			this.colorFactorBar.Location = new System.Drawing.Point(23, 575);
			this.colorFactorBar.Margin = new System.Windows.Forms.Padding(4);
			this.colorFactorBar.Maximum = 255;
			this.colorFactorBar.Name = "colorFactorBar";
			this.colorFactorBar.Size = new System.Drawing.Size(139, 30);
			this.colorFactorBar.TabIndex = 37;
			this.colorFactorBar.TickStyle = System.Windows.Forms.TickStyle.None;
			this.colorFactorBar.Scroll += new System.EventHandler(this.colorFactorBar_Scroll);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(23, 613);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(95, 17);
			this.label8.TabIndex = 42;
			this.label8.Text = "Spatial Factor";
			// 
			// spatialFactorLabel
			// 
			this.spatialFactorLabel.AutoSize = true;
			this.spatialFactorLabel.Location = new System.Drawing.Point(188, 638);
			this.spatialFactorLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.spatialFactorLabel.Name = "spatialFactorLabel";
			this.spatialFactorLabel.Size = new System.Drawing.Size(16, 17);
			this.spatialFactorLabel.TabIndex = 41;
			this.spatialFactorLabel.Text = "0";
			// 
			// spatialFactorBar
			// 
			this.spatialFactorBar.AutoSize = false;
			this.spatialFactorBar.Location = new System.Drawing.Point(23, 638);
			this.spatialFactorBar.Margin = new System.Windows.Forms.Padding(4);
			this.spatialFactorBar.Maximum = 255;
			this.spatialFactorBar.Name = "spatialFactorBar";
			this.spatialFactorBar.Size = new System.Drawing.Size(139, 30);
			this.spatialFactorBar.TabIndex = 40;
			this.spatialFactorBar.TickStyle = System.Windows.Forms.TickStyle.None;
			this.spatialFactorBar.Scroll += new System.EventHandler(this.spatialFactorBar_Scroll);
			// 
			// EdgeForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1906, 834);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.spatialFactorLabel);
			this.Controls.Add(this.spatialFactorBar);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.colorFactorLabel);
			this.Controls.Add(this.colorFactorBar);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.downscalingLabel);
			this.Controls.Add(this.downscalingBar);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.cannyCheckBox);
			this.Controls.Add(this.outputLabel3);
			this.Controls.Add(this.outputLabel2);
			this.Controls.Add(this.outputLabel);
			this.Controls.Add(this.thresholdLabel);
			this.Controls.Add(this.houghThreshholdBar);
			this.Controls.Add(this.houghCheckBox);
			this.Controls.Add(this.maxLabel);
			this.Controls.Add(this.minLabel);
			this.Controls.Add(this.maxTrackBar);
			this.Controls.Add(this.minTrackBar);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.edgeDetectButton);
			this.Controls.Add(this.displayAdapter1);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.colorCheckBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.trackBar1);
			this.Controls.Add(this.saveRawImgButton);
			this.Controls.Add(this.StopButton);
			this.Controls.Add(this.StartButton);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "EdgeForm";
			this.Text = "EdgeForm";
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.minTrackBar)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.maxTrackBar)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.houghThreshholdBar)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.downscalingBar)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.colorFactorBar)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.spatialFactorBar)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox colorCheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Button saveRawImgButton;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
		private Awaiba.Controls.DisplayAdapter displayAdapter1;
		private System.Windows.Forms.Button edgeDetectButton;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.TrackBar minTrackBar;
		private System.Windows.Forms.TrackBar maxTrackBar;
		private System.Windows.Forms.Label minLabel;
		private System.Windows.Forms.Label maxLabel;
		private System.Windows.Forms.CheckBox houghCheckBox;
		private System.Windows.Forms.TrackBar houghThreshholdBar;
		private System.Windows.Forms.Label thresholdLabel;
		private System.Windows.Forms.Label outputLabel;
		private System.Windows.Forms.Label outputLabel2;
		private System.Windows.Forms.Label outputLabel3;
		private System.Windows.Forms.CheckBox cannyCheckBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label downscalingLabel;
		private System.Windows.Forms.TrackBar downscalingBar;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label colorFactorLabel;
		private System.Windows.Forms.TrackBar colorFactorBar;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label spatialFactorLabel;
		private System.Windows.Forms.TrackBar spatialFactorBar;
    }
}

