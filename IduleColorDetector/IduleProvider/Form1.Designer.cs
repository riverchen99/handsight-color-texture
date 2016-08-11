namespace IduleProvider
{
    partial class Form1
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
            this.colorCheckbox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.saveRawImgButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.StartButton = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.displayAdapter2 = new Awaiba.Controls.DisplayAdapter();
            this.displayAdapter1 = new Awaiba.Controls.DisplayAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // colorCheckbox
            // 
            this.colorCheckbox.AutoSize = true;
            this.colorCheckbox.Checked = true;
            this.colorCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.colorCheckbox.Location = new System.Drawing.Point(17, 171);
            this.colorCheckbox.Name = "colorCheckbox";
            this.colorCheckbox.Size = new System.Drawing.Size(125, 17);
            this.colorCheckbox.TabIndex = 13;
            this.colorCheckbox.Text = "Color Reconstruction";
            this.colorCheckbox.UseVisualStyleBackColor = true;
            this.colorCheckbox.CheckedChanged += new System.EventHandler(this.colorCheckbox_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Pre-Scaler";
            // 
            // trackBar1
            // 
            this.trackBar1.AutoSize = false;
            this.trackBar1.Location = new System.Drawing.Point(68, 130);
            this.trackBar1.Maximum = 255;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(104, 25);
            this.trackBar1.TabIndex = 11;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar1.Value = 50;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // saveRawImgButton
            // 
            this.saveRawImgButton.Location = new System.Drawing.Point(12, 41);
            this.saveRawImgButton.Name = "saveRawImgButton";
            this.saveRawImgButton.Size = new System.Drawing.Size(156, 23);
            this.saveRawImgButton.TabIndex = 10;
            this.saveRawImgButton.Text = "Take Snapshot";
            this.saveRawImgButton.UseVisualStyleBackColor = true;
            this.saveRawImgButton.Click += new System.EventHandler(this.saveRawImgButton_Click);
            // 
            // StopButton
            // 
            this.StopButton.Location = new System.Drawing.Point(93, 12);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(75, 23);
            this.StopButton.TabIndex = 9;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(12, 12);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(75, 23);
            this.StartButton.TabIndex = 7;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(12, 99);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(156, 23);
            this.button5.TabIndex = 16;
            this.button5.Text = "Record Processed Video";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(12, 70);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(156, 23);
            this.button4.TabIndex = 15;
            this.button4.Text = "Record Raw Video";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // displayAdapter2
            // 
            this.displayAdapter2.Location = new System.Drawing.Point(840, 12);
            this.displayAdapter2.Name = "displayAdapter2";
            this.displayAdapter2.Size = new System.Drawing.Size(640, 640);
            this.displayAdapter2.TabIndex = 19;
            // 
            // displayAdapter1
            // 
            this.displayAdapter1.Location = new System.Drawing.Point(194, 12);
            this.displayAdapter1.Name = "displayAdapter1";
            this.displayAdapter1.Size = new System.Drawing.Size(640, 640);
            this.displayAdapter1.TabIndex = 18;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1538, 678);
            this.Controls.Add(this.displayAdapter2);
            this.Controls.Add(this.displayAdapter1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.colorCheckbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.saveRawImgButton);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.StartButton);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox colorCheckbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Button saveRawImgButton;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private Awaiba.Controls.DisplayAdapter displayAdapter1;
        private Awaiba.Controls.DisplayAdapter displayAdapter2;
    }
}

