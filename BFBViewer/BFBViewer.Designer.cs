namespace BFBViewer
{
    partial class BFBViewer
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
            this.listViewMarkets = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // listViewMarkets
            // 
            this.listViewMarkets.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.listViewMarkets.Location = new System.Drawing.Point(12, 12);
            this.listViewMarkets.Name = "listViewMarkets";
            this.listViewMarkets.Size = new System.Drawing.Size(218, 411);
            this.listViewMarkets.TabIndex = 2;
            this.listViewMarkets.UseCompatibleStateImageBehavior = false;
            // 
            // BFBViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 435);
            this.Controls.Add(this.listViewMarkets);
            this.Name = "BFBViewer";
            this.Text = "BFB Viewer";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewMarkets;
    }
}

