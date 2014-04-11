namespace BFBotLauncher
    {
    partial class frmMarketDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMarketDetails));
            this.splMarketDetails = new System.Windows.Forms.SplitContainer();
            this.tabControlActiveMarkets = new System.Windows.Forms.TabControl();
            this.tabPageActiveMarkets = new System.Windows.Forms.TabPage();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.listViewActiveMarkets1 = new System.Windows.Forms.ListView();
            this.columnHeaderMarket = new System.Windows.Forms.ColumnHeader();
            this.contextMenuStripActiveMarkets = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.detailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageListMarketDetails = new System.Windows.Forms.ImageList(this.components);
            this.toolStripActiveMarkets = new System.Windows.Forms.ToolStrip();
            this.tabControlClosedMarkets = new System.Windows.Forms.TabControl();
            this.tabPageClosedMarkets = new System.Windows.Forms.TabPage();
            this.listViewClosedMarkets = new System.Windows.Forms.ListView();
            this.columnHeaderClosedMarketName = new System.Windows.Forms.ColumnHeader();
            this.contextMenuStripClosedMarkets = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.detailsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripClosedMarkets = new System.Windows.Forms.ToolStrip();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splMarketDetails.Panel1.SuspendLayout();
            this.splMarketDetails.Panel2.SuspendLayout();
            this.splMarketDetails.SuspendLayout();
            this.tabControlActiveMarkets.SuspendLayout();
            this.tabPageActiveMarkets.SuspendLayout();
            this.statusStrip2.SuspendLayout();
            this.contextMenuStripActiveMarkets.SuspendLayout();
            this.tabControlClosedMarkets.SuspendLayout();
            this.tabPageClosedMarkets.SuspendLayout();
            this.contextMenuStripClosedMarkets.SuspendLayout();
            this.SuspendLayout();
            // 
            // splMarketDetails
            // 
            this.splMarketDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splMarketDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splMarketDetails.Location = new System.Drawing.Point(0, 0);
            this.splMarketDetails.Name = "splMarketDetails";
            this.splMarketDetails.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splMarketDetails.Panel1
            // 
            this.splMarketDetails.Panel1.Controls.Add(this.tabControlActiveMarkets);
            this.splMarketDetails.Panel1.Controls.Add(this.toolStripActiveMarkets);
            // 
            // splMarketDetails.Panel2
            // 
            this.splMarketDetails.Panel2.Controls.Add(this.tabControlClosedMarkets);
            this.splMarketDetails.Panel2.Controls.Add(this.toolStripClosedMarkets);
            this.splMarketDetails.Panel2.Controls.Add(this.statusStrip1);
            this.splMarketDetails.Size = new System.Drawing.Size(872, 637);
            this.splMarketDetails.SplitterDistance = 372;
            this.splMarketDetails.TabIndex = 1;
            // 
            // tabControlActiveMarkets
            // 
            this.tabControlActiveMarkets.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControlActiveMarkets.Controls.Add(this.tabPageActiveMarkets);
            this.tabControlActiveMarkets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlActiveMarkets.Location = new System.Drawing.Point(0, 25);
            this.tabControlActiveMarkets.Name = "tabControlActiveMarkets";
            this.tabControlActiveMarkets.SelectedIndex = 0;
            this.tabControlActiveMarkets.Size = new System.Drawing.Size(870, 345);
            this.tabControlActiveMarkets.TabIndex = 2;
            // 
            // tabPageActiveMarkets
            // 
            this.tabPageActiveMarkets.Controls.Add(this.statusStrip2);
            this.tabPageActiveMarkets.Controls.Add(this.listViewActiveMarkets1);
            this.tabPageActiveMarkets.Location = new System.Drawing.Point(4, 25);
            this.tabPageActiveMarkets.Name = "tabPageActiveMarkets";
            this.tabPageActiveMarkets.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageActiveMarkets.Size = new System.Drawing.Size(862, 316);
            this.tabPageActiveMarkets.TabIndex = 0;
            this.tabPageActiveMarkets.Text = "Active Markets ";
            this.tabPageActiveMarkets.UseVisualStyleBackColor = true;
            // 
            // statusStrip2
            // 
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3});
            this.statusStrip2.Location = new System.Drawing.Point(3, 288);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(856, 25);
            this.statusStrip2.SizingGrip = false;
            this.statusStrip2.TabIndex = 1;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.toolStripStatusLabel1.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.toolStripStatusLabel1.Image = global::BFBotLauncher.Properties.Resources.MarketStateAnalysing;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(73, 20);
            this.toolStripStatusLabel1.Text = "Analysing";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.toolStripStatusLabel2.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabel2.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.toolStripStatusLabel2.Image = global::BFBotLauncher.Properties.Resources.MarketStateBacked;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(61, 20);
            this.toolStripStatusLabel2.Text = "Backed";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.toolStripStatusLabel3.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabel3.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.toolStripStatusLabel3.Image = global::BFBotLauncher.Properties.Resources.MarketStateEqualised;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(72, 20);
            this.toolStripStatusLabel3.Text = "Equalised";
            // 
            // listViewActiveMarkets1
            // 
            this.listViewActiveMarkets1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewActiveMarkets1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewActiveMarkets1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderMarket});
            this.listViewActiveMarkets1.ContextMenuStrip = this.contextMenuStripActiveMarkets;
            this.listViewActiveMarkets1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewActiveMarkets1.LargeImageList = this.imageListMarketDetails;
            this.listViewActiveMarkets1.Location = new System.Drawing.Point(3, 3);
            this.listViewActiveMarkets1.Name = "listViewActiveMarkets1";
            this.listViewActiveMarkets1.Size = new System.Drawing.Size(856, 282);
            this.listViewActiveMarkets1.SmallImageList = this.imageListMarketDetails;
            this.listViewActiveMarkets1.TabIndex = 0;
            this.listViewActiveMarkets1.UseCompatibleStateImageBehavior = false;
            this.listViewActiveMarkets1.View = System.Windows.Forms.View.Details;
            this.listViewActiveMarkets1.Visible = false;
            this.listViewActiveMarkets1.DoubleClick += new System.EventHandler(this.listViewActiveMarkets1_DoubleClick);
            this.listViewActiveMarkets1.SelectedIndexChanged += new System.EventHandler(this.listViewActiveMarkets1_SelectedIndexChanged);
            // 
            // columnHeaderMarket
            // 
            this.columnHeaderMarket.Text = "Market";
            this.columnHeaderMarket.Width = 100;
            // 
            // contextMenuStripActiveMarkets
            // 
            this.contextMenuStripActiveMarkets.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.detailsToolStripMenuItem,
            this.removeToolStripMenuItem});
            this.contextMenuStripActiveMarkets.Name = "contextMenuStripActiveMarkets";
            this.contextMenuStripActiveMarkets.Size = new System.Drawing.Size(153, 70);
            // 
            // detailsToolStripMenuItem
            // 
            this.detailsToolStripMenuItem.Name = "detailsToolStripMenuItem";
            this.detailsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.detailsToolStripMenuItem.Text = "Details";
            this.detailsToolStripMenuItem.Click += new System.EventHandler(this.detailsToolStripMenuItem_Click);
            // 
            // imageListMarketDetails
            // 
            this.imageListMarketDetails.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListMarketDetails.ImageStream")));
            this.imageListMarketDetails.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListMarketDetails.Images.SetKeyName(0, "MarketStateUnknown.ico");
            this.imageListMarketDetails.Images.SetKeyName(1, "MarketStateBacked.ico");
            this.imageListMarketDetails.Images.SetKeyName(2, "MarketStateEqualised.ico");
            this.imageListMarketDetails.Images.SetKeyName(3, "MarketStateAnalysing.ico");
            this.imageListMarketDetails.Images.SetKeyName(4, "MarketStateClosed.ico");
            // 
            // toolStripActiveMarkets
            // 
            this.toolStripActiveMarkets.Location = new System.Drawing.Point(0, 0);
            this.toolStripActiveMarkets.Name = "toolStripActiveMarkets";
            this.toolStripActiveMarkets.Size = new System.Drawing.Size(870, 25);
            this.toolStripActiveMarkets.TabIndex = 0;
            this.toolStripActiveMarkets.Text = "toolStrip2";
            // 
            // tabControlClosedMarkets
            // 
            this.tabControlClosedMarkets.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControlClosedMarkets.Controls.Add(this.tabPageClosedMarkets);
            this.tabControlClosedMarkets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlClosedMarkets.Location = new System.Drawing.Point(0, 25);
            this.tabControlClosedMarkets.Name = "tabControlClosedMarkets";
            this.tabControlClosedMarkets.SelectedIndex = 0;
            this.tabControlClosedMarkets.Size = new System.Drawing.Size(870, 212);
            this.tabControlClosedMarkets.TabIndex = 3;
            // 
            // tabPageClosedMarkets
            // 
            this.tabPageClosedMarkets.Controls.Add(this.listViewClosedMarkets);
            this.tabPageClosedMarkets.Location = new System.Drawing.Point(4, 25);
            this.tabPageClosedMarkets.Name = "tabPageClosedMarkets";
            this.tabPageClosedMarkets.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageClosedMarkets.Size = new System.Drawing.Size(862, 183);
            this.tabPageClosedMarkets.TabIndex = 0;
            this.tabPageClosedMarkets.Text = "Closed Markets";
            this.tabPageClosedMarkets.UseVisualStyleBackColor = true;
            // 
            // listViewClosedMarkets
            // 
            this.listViewClosedMarkets.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderClosedMarketName});
            this.listViewClosedMarkets.ContextMenuStrip = this.contextMenuStripClosedMarkets;
            this.listViewClosedMarkets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewClosedMarkets.Location = new System.Drawing.Point(3, 3);
            this.listViewClosedMarkets.Name = "listViewClosedMarkets";
            this.listViewClosedMarkets.Size = new System.Drawing.Size(856, 177);
            this.listViewClosedMarkets.SmallImageList = this.imageListMarketDetails;
            this.listViewClosedMarkets.TabIndex = 0;
            this.listViewClosedMarkets.UseCompatibleStateImageBehavior = false;
            this.listViewClosedMarkets.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderClosedMarketName
            // 
            this.columnHeaderClosedMarketName.Text = "Market";
            // 
            // contextMenuStripClosedMarkets
            // 
            this.contextMenuStripClosedMarkets.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.detailsToolStripMenuItem1});
            this.contextMenuStripClosedMarkets.Name = "contextMenuStripClosedMarkets";
            this.contextMenuStripClosedMarkets.Size = new System.Drawing.Size(118, 26);
            // 
            // detailsToolStripMenuItem1
            // 
            this.detailsToolStripMenuItem1.Name = "detailsToolStripMenuItem1";
            this.detailsToolStripMenuItem1.Size = new System.Drawing.Size(117, 22);
            this.detailsToolStripMenuItem1.Text = "Details";
            this.detailsToolStripMenuItem1.Click += new System.EventHandler(this.detailsToolStripMenuItem1_Click);
            // 
            // toolStripClosedMarkets
            // 
            this.toolStripClosedMarkets.Location = new System.Drawing.Point(0, 0);
            this.toolStripClosedMarkets.Name = "toolStripClosedMarkets";
            this.toolStripClosedMarkets.Size = new System.Drawing.Size(870, 25);
            this.toolStripClosedMarkets.TabIndex = 1;
            this.toolStripClosedMarkets.Text = "toolStrip1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 237);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(870, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // frmMarketDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 637);
            this.Controls.Add(this.splMarketDetails);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMarketDetails";
            this.Text = "BFB Market Details";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMarketDetails_FormClosing);
            this.splMarketDetails.Panel1.ResumeLayout(false);
            this.splMarketDetails.Panel1.PerformLayout();
            this.splMarketDetails.Panel2.ResumeLayout(false);
            this.splMarketDetails.Panel2.PerformLayout();
            this.splMarketDetails.ResumeLayout(false);
            this.tabControlActiveMarkets.ResumeLayout(false);
            this.tabPageActiveMarkets.ResumeLayout(false);
            this.tabPageActiveMarkets.PerformLayout();
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.contextMenuStripActiveMarkets.ResumeLayout(false);
            this.tabControlClosedMarkets.ResumeLayout(false);
            this.tabPageClosedMarkets.ResumeLayout(false);
            this.contextMenuStripClosedMarkets.ResumeLayout(false);
            this.ResumeLayout(false);

            }

        #endregion

        private System.Windows.Forms.SplitContainer splMarketDetails;
        private System.Windows.Forms.ToolStrip toolStripActiveMarkets;
        private System.Windows.Forms.ToolStrip toolStripClosedMarkets;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TabControl tabControlActiveMarkets;
        private System.Windows.Forms.TabPage tabPageActiveMarkets;
        private System.Windows.Forms.TabControl tabControlClosedMarkets;
        private System.Windows.Forms.TabPage tabPageClosedMarkets;
        private System.Windows.Forms.ListView listViewActiveMarkets1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripActiveMarkets;
        private System.Windows.Forms.ToolStripMenuItem detailsToolStripMenuItem;
        private System.Windows.Forms.ImageList imageListMarketDetails;
        private System.Windows.Forms.ColumnHeader columnHeaderMarket;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ListView listViewClosedMarkets;
        private System.Windows.Forms.ColumnHeader columnHeaderClosedMarketName;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripClosedMarkets;
        private System.Windows.Forms.ToolStripMenuItem detailsToolStripMenuItem1;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;

        }
    }