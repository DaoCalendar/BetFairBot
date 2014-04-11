namespace BFBotLauncher
{
    partial class BfbViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BfbViewer));
            this.listBoxMarkets = new System.Windows.Forms.ListBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.SuspendLayout();
            // 
            // listBoxMarkets
            // 
            this.listBoxMarkets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxMarkets.FormattingEnabled = true;
            this.listBoxMarkets.Location = new System.Drawing.Point(0, 0);
            this.listBoxMarkets.Name = "listBoxMarkets";
            this.listBoxMarkets.Size = new System.Drawing.Size(304, 420);
            this.listBoxMarkets.TabIndex = 0;
            this.listBoxMarkets.Click += new System.EventHandler(this.listBoxMarkets_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 407);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(304, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // BFBViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 429);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.listBoxMarkets);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BfbViewer";
            this.Text = "BFBViewer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxMarkets;
        private System.Windows.Forms.StatusStrip statusStrip1;

    }
}