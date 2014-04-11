namespace BFBotLauncher
    {
    partial class frmSettings
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettings));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nudMaxStake = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.nudMaxBalance = new System.Windows.Forms.NumericUpDown();
            this.grpOneFourWeight = new System.Windows.Forms.GroupBox();
            this.trackBarOneFourWeight = new System.Windows.Forms.TrackBar();
            this.grpOverallWeight = new System.Windows.Forms.GroupBox();
            this.trackBarOverallWeight = new System.Windows.Forms.TrackBar();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.nudSecondsToBack = new System.Windows.Forms.NumericUpDown();
            this.grpOneTwoWeight = new System.Windows.Forms.GroupBox();
            this.trackBarOneTwoWeight = new System.Windows.Forms.TrackBar();
            this.grpOneTenWeight = new System.Windows.Forms.GroupBox();
            this.trackBarOneTenWeight = new System.Windows.Forms.TrackBar();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBoxEmailAddress = new System.Windows.Forms.TextBox();
            this.checkBoxEmailNotification = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.numericUpDownMultipleBackStopTime = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxStake)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxBalance)).BeginInit();
            this.grpOneFourWeight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOneFourWeight)).BeginInit();
            this.grpOverallWeight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOverallWeight)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSecondsToBack)).BeginInit();
            this.grpOneTwoWeight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOneTwoWeight)).BeginInit();
            this.grpOneTenWeight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOneTenWeight)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMultipleBackStopTime)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nudMaxStake);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(126, 54);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Max Stake";
            // 
            // nudMaxStake
            // 
            this.nudMaxStake.DecimalPlaces = 2;
            this.nudMaxStake.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudMaxStake.Location = new System.Drawing.Point(7, 20);
            this.nudMaxStake.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudMaxStake.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMaxStake.Name = "nudMaxStake";
            this.nudMaxStake.Size = new System.Drawing.Size(113, 20);
            this.nudMaxStake.TabIndex = 0;
            this.nudMaxStake.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.nudMaxBalance);
            this.groupBox2.Location = new System.Drawing.Point(144, 14);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(126, 52);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Max balance";
            // 
            // nudMaxBalance
            // 
            this.nudMaxBalance.DecimalPlaces = 2;
            this.nudMaxBalance.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudMaxBalance.Location = new System.Drawing.Point(7, 17);
            this.nudMaxBalance.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudMaxBalance.Name = "nudMaxBalance";
            this.nudMaxBalance.Size = new System.Drawing.Size(113, 20);
            this.nudMaxBalance.TabIndex = 0;
            // 
            // grpOneFourWeight
            // 
            this.grpOneFourWeight.Controls.Add(this.trackBarOneFourWeight);
            this.grpOneFourWeight.Location = new System.Drawing.Point(12, 355);
            this.grpOneFourWeight.Name = "grpOneFourWeight";
            this.grpOneFourWeight.Size = new System.Drawing.Size(391, 67);
            this.grpOneFourWeight.TabIndex = 7;
            this.grpOneFourWeight.TabStop = false;
            this.grpOneFourWeight.Text = "1/4 Weighting";
            // 
            // trackBarOneFourWeight
            // 
            this.trackBarOneFourWeight.Location = new System.Drawing.Point(20, 16);
            this.trackBarOneFourWeight.Maximum = 100;
            this.trackBarOneFourWeight.Name = "trackBarOneFourWeight";
            this.trackBarOneFourWeight.Size = new System.Drawing.Size(350, 45);
            this.trackBarOneFourWeight.TabIndex = 0;
            this.trackBarOneFourWeight.TickFrequency = 5;
            this.trackBarOneFourWeight.Value = 5;
            this.trackBarOneFourWeight.ValueChanged += new System.EventHandler(this.trackBarOneFourWeight_ValueChanged);
            // 
            // grpOverallWeight
            // 
            this.grpOverallWeight.Controls.Add(this.trackBarOverallWeight);
            this.grpOverallWeight.Location = new System.Drawing.Point(12, 209);
            this.grpOverallWeight.Name = "grpOverallWeight";
            this.grpOverallWeight.Size = new System.Drawing.Size(391, 67);
            this.grpOverallWeight.TabIndex = 5;
            this.grpOverallWeight.TabStop = false;
            this.grpOverallWeight.Text = "Overall Weighting";
            // 
            // trackBarOverallWeight
            // 
            this.trackBarOverallWeight.Location = new System.Drawing.Point(18, 16);
            this.trackBarOverallWeight.Maximum = 100;
            this.trackBarOverallWeight.Name = "trackBarOverallWeight";
            this.trackBarOverallWeight.Size = new System.Drawing.Size(350, 45);
            this.trackBarOverallWeight.TabIndex = 0;
            this.trackBarOverallWeight.TickFrequency = 5;
            this.trackBarOverallWeight.Value = 5;
            this.trackBarOverallWeight.ValueChanged += new System.EventHandler(this.trackBarOverallWeight_ValueChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.nudSecondsToBack);
            this.groupBox5.Location = new System.Drawing.Point(277, 14);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(126, 52);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Time to Back";
            // 
            // nudSecondsToBack
            // 
            this.nudSecondsToBack.Location = new System.Drawing.Point(7, 18);
            this.nudSecondsToBack.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudSecondsToBack.Name = "nudSecondsToBack";
            this.nudSecondsToBack.Size = new System.Drawing.Size(113, 20);
            this.nudSecondsToBack.TabIndex = 0;
            // 
            // grpOneTwoWeight
            // 
            this.grpOneTwoWeight.Controls.Add(this.trackBarOneTwoWeight);
            this.grpOneTwoWeight.Location = new System.Drawing.Point(12, 282);
            this.grpOneTwoWeight.Name = "grpOneTwoWeight";
            this.grpOneTwoWeight.Size = new System.Drawing.Size(391, 67);
            this.grpOneTwoWeight.TabIndex = 6;
            this.grpOneTwoWeight.TabStop = false;
            this.grpOneTwoWeight.Text = "1/2 Weighting";
            // 
            // trackBarOneTwoWeight
            // 
            this.trackBarOneTwoWeight.Location = new System.Drawing.Point(20, 16);
            this.trackBarOneTwoWeight.Maximum = 100;
            this.trackBarOneTwoWeight.Name = "trackBarOneTwoWeight";
            this.trackBarOneTwoWeight.Size = new System.Drawing.Size(350, 45);
            this.trackBarOneTwoWeight.TabIndex = 0;
            this.trackBarOneTwoWeight.TickFrequency = 5;
            this.trackBarOneTwoWeight.Value = 5;
            this.trackBarOneTwoWeight.ValueChanged += new System.EventHandler(this.trackBarOneTwoWeight_ValueChanged);
            // 
            // grpOneTenWeight
            // 
            this.grpOneTenWeight.Controls.Add(this.trackBarOneTenWeight);
            this.grpOneTenWeight.Location = new System.Drawing.Point(12, 428);
            this.grpOneTenWeight.Name = "grpOneTenWeight";
            this.grpOneTenWeight.Size = new System.Drawing.Size(391, 67);
            this.grpOneTenWeight.TabIndex = 8;
            this.grpOneTenWeight.TabStop = false;
            this.grpOneTenWeight.Text = "1/10 Weighting";
            // 
            // trackBarOneTenWeight
            // 
            this.trackBarOneTenWeight.Location = new System.Drawing.Point(20, 16);
            this.trackBarOneTenWeight.Maximum = 100;
            this.trackBarOneTenWeight.Name = "trackBarOneTenWeight";
            this.trackBarOneTenWeight.Size = new System.Drawing.Size(350, 45);
            this.trackBarOneTenWeight.TabIndex = 0;
            this.trackBarOneTenWeight.TickFrequency = 5;
            this.trackBarOneTenWeight.Value = 5;
            this.trackBarOneTenWeight.ValueChanged += new System.EventHandler(this.trackBarOneTenWeight_ValueChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBoxEmailAddress);
            this.groupBox3.Controls.Add(this.checkBoxEmailNotification);
            this.groupBox3.Location = new System.Drawing.Point(12, 155);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(391, 52);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "email notification";
            // 
            // textBoxEmailAddress
            // 
            this.textBoxEmailAddress.Location = new System.Drawing.Point(30, 19);
            this.textBoxEmailAddress.Name = "textBoxEmailAddress";
            this.textBoxEmailAddress.Size = new System.Drawing.Size(355, 20);
            this.textBoxEmailAddress.TabIndex = 1;
            // 
            // checkBoxEmailNotification
            // 
            this.checkBoxEmailNotification.AutoSize = true;
            this.checkBoxEmailNotification.Location = new System.Drawing.Point(10, 23);
            this.checkBoxEmailNotification.Name = "checkBoxEmailNotification";
            this.checkBoxEmailNotification.Size = new System.Drawing.Size(15, 14);
            this.checkBoxEmailNotification.TabIndex = 0;
            this.checkBoxEmailNotification.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.numericUpDownMultipleBackStopTime);
            this.groupBox4.Controls.Add(this.checkBox1);
            this.groupBox4.Location = new System.Drawing.Point(12, 71);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(391, 58);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(10, 23);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(90, 17);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Multiple Back";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // numericUpDownMultipleBackStopTime
            // 
            this.numericUpDownMultipleBackStopTime.Location = new System.Drawing.Point(265, 21);
            this.numericUpDownMultipleBackStopTime.Name = "numericUpDownMultipleBackStopTime";
            this.numericUpDownMultipleBackStopTime.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownMultipleBackStopTime.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(144, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Multiple back stop time";
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 517);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.grpOneFourWeight);
            this.Controls.Add(this.grpOverallWeight);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.grpOneTwoWeight);
            this.Controls.Add(this.grpOneTenWeight);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSettings";
            this.Text = "BFB Settings";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSettings_FormClosed);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxStake)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxBalance)).EndInit();
            this.grpOneFourWeight.ResumeLayout(false);
            this.grpOneFourWeight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOneFourWeight)).EndInit();
            this.grpOverallWeight.ResumeLayout(false);
            this.grpOverallWeight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOverallWeight)).EndInit();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudSecondsToBack)).EndInit();
            this.grpOneTwoWeight.ResumeLayout(false);
            this.grpOneTwoWeight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOneTwoWeight)).EndInit();
            this.grpOneTenWeight.ResumeLayout(false);
            this.grpOneTenWeight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOneTenWeight)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMultipleBackStopTime)).EndInit();
            this.ResumeLayout(false);

            }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox grpOneFourWeight;
        private System.Windows.Forms.GroupBox grpOverallWeight;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox grpOneTwoWeight;
        private System.Windows.Forms.GroupBox grpOneTenWeight;
        private System.Windows.Forms.NumericUpDown nudMaxStake;
        private System.Windows.Forms.NumericUpDown nudMaxBalance;
        private System.Windows.Forms.TrackBar trackBarOneFourWeight;
        private System.Windows.Forms.TrackBar trackBarOverallWeight;
        private System.Windows.Forms.NumericUpDown nudSecondsToBack;
        private System.Windows.Forms.TrackBar trackBarOneTwoWeight;
        private System.Windows.Forms.TrackBar trackBarOneTenWeight;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBoxEmailAddress;
        private System.Windows.Forms.CheckBox checkBoxEmailNotification;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownMultipleBackStopTime;
        private System.Windows.Forms.CheckBox checkBox1;

        }
    }