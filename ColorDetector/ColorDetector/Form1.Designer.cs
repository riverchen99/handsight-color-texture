namespace ColorDetector {
	partial class Form1 {
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
			this.ledTrackbar = new System.Windows.Forms.TrackBar();
			this.ledCheckbox = new System.Windows.Forms.CheckBox();
			this.aecCheckbox = new System.Windows.Forms.CheckBox();
			this.button5 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.gainTrackbar = new System.Windows.Forms.TrackBar();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.ColorButton = new System.Windows.Forms.Button();
			this.actualColorBox = new System.Windows.Forms.PictureBox();
			this.ColorLabel = new System.Windows.Forms.Label();
			this.closestColorBox = new System.Windows.Forms.PictureBox();
			this.histBox = new System.Windows.Forms.PictureBox();
			this.smoothedHistBox = new System.Windows.Forms.PictureBox();
			this.commonColorBox = new System.Windows.Forms.PictureBox();
			this.closestColorBox2 = new System.Windows.Forms.PictureBox();
			this.ColorLabel2 = new System.Windows.Forms.Label();
			this.ColorNameLabel = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.ledTrackbar)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gainTrackbar)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.actualColorBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.closestColorBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.histBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.smoothedHistBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.commonColorBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.closestColorBox2)).BeginInit();
			this.SuspendLayout();
			// 
			// ledTrackbar
			// 
			this.ledTrackbar.AutoSize = false;
			this.ledTrackbar.Location = new System.Drawing.Point(436, 263);
			this.ledTrackbar.Margin = new System.Windows.Forms.Padding(4);
			this.ledTrackbar.Maximum = 4095;
			this.ledTrackbar.Name = "ledTrackbar";
			this.ledTrackbar.Size = new System.Drawing.Size(157, 30);
			this.ledTrackbar.TabIndex = 37;
			this.ledTrackbar.TickStyle = System.Windows.Forms.TickStyle.None;
			this.ledTrackbar.Scroll += new System.EventHandler(this.ledTrackbar_Scroll);
			// 
			// ledCheckbox
			// 
			this.ledCheckbox.AutoSize = true;
			this.ledCheckbox.Location = new System.Drawing.Point(370, 268);
			this.ledCheckbox.Margin = new System.Windows.Forms.Padding(4);
			this.ledCheckbox.Name = "ledCheckbox";
			this.ledCheckbox.Size = new System.Drawing.Size(57, 21);
			this.ledCheckbox.TabIndex = 36;
			this.ledCheckbox.Text = "LED";
			this.ledCheckbox.UseVisualStyleBackColor = true;
			this.ledCheckbox.CheckedChanged += new System.EventHandler(this.ledCheckbox_CheckedChanged);
			// 
			// aecCheckbox
			// 
			this.aecCheckbox.AutoSize = true;
			this.aecCheckbox.Location = new System.Drawing.Point(370, 237);
			this.aecCheckbox.Margin = new System.Windows.Forms.Padding(4);
			this.aecCheckbox.Name = "aecCheckbox";
			this.aecCheckbox.Size = new System.Drawing.Size(135, 21);
			this.aecCheckbox.TabIndex = 35;
			this.aecCheckbox.Text = "Auto Exp Control";
			this.aecCheckbox.UseVisualStyleBackColor = true;
			this.aecCheckbox.CheckedChanged += new System.EventHandler(this.aecCheckbox_CheckedChanged);
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(368, 120);
			this.button5.Margin = new System.Windows.Forms.Padding(4);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(225, 28);
			this.button5.TabIndex = 34;
			this.button5.Text = "Record Processed Video";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(368, 84);
			this.button4.Margin = new System.Windows.Forms.Padding(4);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(225, 28);
			this.button4.TabIndex = 33;
			this.button4.Text = "Record Raw Video";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(368, 48);
			this.button3.Margin = new System.Windows.Forms.Padding(4);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(225, 28);
			this.button3.TabIndex = 32;
			this.button3.Text = "Take Snapshot";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(370, 169);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(38, 17);
			this.label1.TabIndex = 31;
			this.label1.Text = "Gain";
			// 
			// gainTrackbar
			// 
			this.gainTrackbar.AutoSize = false;
			this.gainTrackbar.LargeChange = 1;
			this.gainTrackbar.Location = new System.Drawing.Point(436, 163);
			this.gainTrackbar.Margin = new System.Windows.Forms.Padding(4);
			this.gainTrackbar.Maximum = 3;
			this.gainTrackbar.Name = "gainTrackbar";
			this.gainTrackbar.Size = new System.Drawing.Size(161, 34);
			this.gainTrackbar.TabIndex = 30;
			this.gainTrackbar.TickStyle = System.Windows.Forms.TickStyle.None;
			this.gainTrackbar.Value = 2;
			this.gainTrackbar.Scroll += new System.EventHandler(this.gainTrackbar_Scroll);
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(370, 205);
			this.checkBox1.Margin = new System.Windows.Forms.Padding(4);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(162, 21);
			this.checkBox1.TabIndex = 29;
			this.checkBox1.Text = "Color Reconstruction";
			this.checkBox1.UseVisualStyleBackColor = true;
			this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(493, 13);
			this.button2.Margin = new System.Windows.Forms.Padding(4);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(100, 28);
			this.button2.TabIndex = 28;
			this.button2.Text = "Stop";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(368, 13);
			this.button1.Margin = new System.Windows.Forms.Padding(4);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(100, 28);
			this.button1.TabIndex = 27;
			this.button1.Text = "Start";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBox1.Location = new System.Drawing.Point(13, 13);
			this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(333, 307);
			this.pictureBox1.TabIndex = 26;
			this.pictureBox1.TabStop = false;
			// 
			// ColorButton
			// 
			this.ColorButton.Location = new System.Drawing.Point(25, 362);
			this.ColorButton.Name = "ColorButton";
			this.ColorButton.Size = new System.Drawing.Size(75, 42);
			this.ColorButton.TabIndex = 38;
			this.ColorButton.Text = "Check Color";
			this.ColorButton.UseVisualStyleBackColor = true;
			this.ColorButton.Click += new System.EventHandler(this.ColorButton_Click);
			// 
			// actualColorBox
			// 
			this.actualColorBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.actualColorBox.Location = new System.Drawing.Point(142, 341);
			this.actualColorBox.Margin = new System.Windows.Forms.Padding(4);
			this.actualColorBox.Name = "actualColorBox";
			this.actualColorBox.Size = new System.Drawing.Size(101, 94);
			this.actualColorBox.TabIndex = 39;
			this.actualColorBox.TabStop = false;
			// 
			// ColorLabel
			// 
			this.ColorLabel.AutoSize = true;
			this.ColorLabel.Location = new System.Drawing.Point(259, 324);
			this.ColorLabel.Name = "ColorLabel";
			this.ColorLabel.Size = new System.Drawing.Size(23, 17);
			this.ColorLabel.TabIndex = 40;
			this.ColorLabel.Text = "---";
			// 
			// closestColorBox
			// 
			this.closestColorBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.closestColorBox.Location = new System.Drawing.Point(262, 341);
			this.closestColorBox.Margin = new System.Windows.Forms.Padding(4);
			this.closestColorBox.Name = "closestColorBox";
			this.closestColorBox.Size = new System.Drawing.Size(101, 94);
			this.closestColorBox.TabIndex = 41;
			this.closestColorBox.TabStop = false;
			// 
			// histBox
			// 
			this.histBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.histBox.Location = new System.Drawing.Point(13, 443);
			this.histBox.Margin = new System.Windows.Forms.Padding(4);
			this.histBox.Name = "histBox";
			this.histBox.Size = new System.Drawing.Size(625, 360);
			this.histBox.TabIndex = 42;
			this.histBox.TabStop = false;
			// 
			// smoothedHistBox
			// 
			this.smoothedHistBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.smoothedHistBox.Location = new System.Drawing.Point(693, 443);
			this.smoothedHistBox.Margin = new System.Windows.Forms.Padding(4);
			this.smoothedHistBox.Name = "smoothedHistBox";
			this.smoothedHistBox.Size = new System.Drawing.Size(625, 360);
			this.smoothedHistBox.TabIndex = 43;
			this.smoothedHistBox.TabStop = false;
			// 
			// highestColorBox
			// 
			this.commonColorBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.commonColorBox.Location = new System.Drawing.Point(392, 341);
			this.commonColorBox.Margin = new System.Windows.Forms.Padding(4);
			this.commonColorBox.Name = "highestColorBox";
			this.commonColorBox.Size = new System.Drawing.Size(101, 94);
			this.commonColorBox.TabIndex = 44;
			this.commonColorBox.TabStop = false;
			// 
			// closestColorBox2
			// 
			this.closestColorBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.closestColorBox2.Location = new System.Drawing.Point(512, 341);
			this.closestColorBox2.Margin = new System.Windows.Forms.Padding(4);
			this.closestColorBox2.Name = "closestColorBox2";
			this.closestColorBox2.Size = new System.Drawing.Size(101, 94);
			this.closestColorBox2.TabIndex = 45;
			this.closestColorBox2.TabStop = false;
			// 
			// ColorLabel2
			// 
			this.ColorLabel2.AutoSize = true;
			this.ColorLabel2.Location = new System.Drawing.Point(509, 320);
			this.ColorLabel2.Name = "ColorLabel2";
			this.ColorLabel2.Size = new System.Drawing.Size(23, 17);
			this.ColorLabel2.TabIndex = 46;
			this.ColorLabel2.Text = "---";
			// 
			// ColorNameLabel
			// 
			this.ColorNameLabel.AutoSize = true;
			this.ColorNameLabel.Location = new System.Drawing.Point(776, 218);
			this.ColorNameLabel.Name = "ColorNameLabel";
			this.ColorNameLabel.Size = new System.Drawing.Size(23, 17);
			this.ColorNameLabel.TabIndex = 47;
			this.ColorNameLabel.Text = "---";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1400, 825);
			this.Controls.Add(this.ColorNameLabel);
			this.Controls.Add(this.ColorLabel2);
			this.Controls.Add(this.closestColorBox2);
			this.Controls.Add(this.commonColorBox);
			this.Controls.Add(this.smoothedHistBox);
			this.Controls.Add(this.histBox);
			this.Controls.Add(this.closestColorBox);
			this.Controls.Add(this.ColorLabel);
			this.Controls.Add(this.actualColorBox);
			this.Controls.Add(this.ColorButton);
			this.Controls.Add(this.ledTrackbar);
			this.Controls.Add(this.ledCheckbox);
			this.Controls.Add(this.aecCheckbox);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.gainTrackbar);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.pictureBox1);
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.ledTrackbar)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gainTrackbar)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.actualColorBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.closestColorBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.histBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.smoothedHistBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.commonColorBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.closestColorBox2)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TrackBar ledTrackbar;
		private System.Windows.Forms.CheckBox ledCheckbox;
		private System.Windows.Forms.CheckBox aecCheckbox;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TrackBar gainTrackbar;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button ColorButton;
		private System.Windows.Forms.PictureBox actualColorBox;
		private System.Windows.Forms.Label ColorLabel;
		private System.Windows.Forms.PictureBox closestColorBox;
		private System.Windows.Forms.PictureBox histBox;
		private System.Windows.Forms.PictureBox smoothedHistBox;
		private System.Windows.Forms.PictureBox commonColorBox;
		private System.Windows.Forms.PictureBox closestColorBox2;
		private System.Windows.Forms.Label ColorLabel2;
		private System.Windows.Forms.Label ColorNameLabel;

	}
}

