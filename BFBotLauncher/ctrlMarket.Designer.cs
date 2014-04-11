namespace BFBotLauncher
    {
    partial class ctrlMarket
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
            {
            this.groupBoxMarketDetails = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBoxMarketDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxMarketDetails
            // 
            this.groupBoxMarketDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxMarketDetails.Controls.Add(this.flowLayoutPanel1);
            this.groupBoxMarketDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBoxMarketDetails.Location = new System.Drawing.Point(13, 14);
            this.groupBoxMarketDetails.Name = "groupBoxMarketDetails";
            this.groupBoxMarketDetails.Size = new System.Drawing.Size(645, 525);
            this.groupBoxMarketDetails.TabIndex = 1;
            this.groupBoxMarketDetails.TabStop = false;
            this.groupBoxMarketDetails.Text = "Market Details";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(6, 19);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(633, 500);
            this.flowLayoutPanel1.TabIndex = 1;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // ctrlMarket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxMarketDetails);
            this.Name = "ctrlMarket";
            this.Size = new System.Drawing.Size(672, 553);
            this.groupBoxMarketDetails.ResumeLayout(false);
            this.ResumeLayout(false);

            }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxMarketDetails;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;


        }
    }
