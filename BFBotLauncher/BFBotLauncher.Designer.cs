namespace BFBotLauncher
    {
    partial class BFBotUI
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
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BFBotUI));
                this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
                this.contextMenuBFBot = new System.Windows.Forms.ContextMenuStrip(this.components);
                this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
                this.viewerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
                this.mnuRestore = new System.Windows.Forms.ToolStripMenuItem();
                this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
                this.imageList1 = new System.Windows.Forms.ImageList(this.components);
                this.timer1 = new System.Windows.Forms.Timer(this.components);
                this.timer2 = new System.Windows.Forms.Timer(this.components);
                this.btnTest = new System.Windows.Forms.Button();
                this.imageList2 = new System.Windows.Forms.ImageList(this.components);
                this.statusStrip1 = new System.Windows.Forms.StatusStrip();
                this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
                this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
                this.contextMenuBFBot.SuspendLayout();
                this.statusStrip1.SuspendLayout();
                this.SuspendLayout();
                // 
                // notifyIcon1
                // 
                this.notifyIcon1.ContextMenuStrip = this.contextMenuBFBot;
                this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
                this.notifyIcon1.Text = "BFBot";
                this.notifyIcon1.Visible = true;
                this.notifyIcon1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseMove);
                this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
                // 
                // contextMenuBFBot
                // 
                this.contextMenuBFBot.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.preferencesToolStripMenuItem,
            this.viewerToolStripMenuItem,
            this.mnuRestore,
            this.mnuExit});
                this.contextMenuBFBot.Name = "contextMenuStrip1";
                this.contextMenuBFBot.Size = new System.Drawing.Size(144, 92);
                // 
                // preferencesToolStripMenuItem
                // 
                this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
                this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
                this.preferencesToolStripMenuItem.Text = "Preferences";
                this.preferencesToolStripMenuItem.Click += new System.EventHandler(this.preferencesToolStripMenuItem_Click);
                // 
                // viewerToolStripMenuItem
                // 
                this.viewerToolStripMenuItem.Name = "viewerToolStripMenuItem";
                this.viewerToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
                this.viewerToolStripMenuItem.Text = "Viewer";
                this.viewerToolStripMenuItem.Click += new System.EventHandler(this.viewerToolStripMenuItem_Click);
                // 
                // mnuRestore
                // 
                this.mnuRestore.Name = "mnuRestore";
                this.mnuRestore.Size = new System.Drawing.Size(143, 22);
                this.mnuRestore.Text = "Restore";
                this.mnuRestore.Click += new System.EventHandler(this.mnuRestore_Click);
                // 
                // mnuExit
                // 
                this.mnuExit.Name = "mnuExit";
                this.mnuExit.Size = new System.Drawing.Size(143, 22);
                this.mnuExit.Text = "Exit";
                this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
                // 
                // imageList1
                // 
                this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
                this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
                this.imageList1.Images.SetKeyName(0, "App.ico");
                this.imageList1.Images.SetKeyName(1, "App1.ico");
                this.imageList1.Images.SetKeyName(2, "App2.ico");
                this.imageList1.Images.SetKeyName(3, "App3.ico");
                // 
                // timer1
                // 
                this.timer1.Enabled = true;
                this.timer1.Interval = 1000;
                this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
                // 
                // timer2
                // 
                this.timer2.Enabled = true;
                this.timer2.Interval = 3600000;
                this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
                // 
                // btnTest
                // 
                this.btnTest.Location = new System.Drawing.Point(177, 12);
                this.btnTest.Name = "btnTest";
                this.btnTest.Size = new System.Drawing.Size(75, 23);
                this.btnTest.TabIndex = 0;
                this.btnTest.Text = "Test";
                this.btnTest.UseVisualStyleBackColor = true;
                this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
                // 
                // imageList2
                // 
                this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
                this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
                this.imageList2.Images.SetKeyName(0, "bfbot1.ico");
                this.imageList2.Images.SetKeyName(1, "bfbot3.ico");
                this.imageList2.Images.SetKeyName(2, "bfbot4.ico");
                this.imageList2.Images.SetKeyName(3, "bfbot5.ico");
                this.imageList2.Images.SetKeyName(4, "bfbot6.ico");
                this.imageList2.Images.SetKeyName(5, "bfbot7.ico");
                this.imageList2.Images.SetKeyName(6, "bfbot8.ico");
                this.imageList2.Images.SetKeyName(7, "bfbot9.ico");
                this.imageList2.Images.SetKeyName(8, "bfbot10.ico");
                // 
                // statusStrip1
                // 
                this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
                this.statusStrip1.Location = new System.Drawing.Point(0, 41);
                this.statusStrip1.Name = "statusStrip1";
                this.statusStrip1.Size = new System.Drawing.Size(264, 22);
                this.statusStrip1.SizingGrip = false;
                this.statusStrip1.TabIndex = 1;
                this.statusStrip1.Text = "statusStrip1";
                // 
                // toolStripStatusLabel1
                // 
                this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
                this.toolStripStatusLabel1.Size = new System.Drawing.Size(109, 17);
                this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
                // 
                // toolStripStatusLabel2
                // 
                this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
                this.toolStripStatusLabel2.Size = new System.Drawing.Size(109, 17);
                this.toolStripStatusLabel2.Text = "toolStripStatusLabel2";
                // 
                // BFBotUI
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(264, 63);
                this.Controls.Add(this.statusStrip1);
                this.Controls.Add(this.btnTest);
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
                this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
                this.MaximizeBox = false;
                this.MinimizeBox = false;
                this.Name = "BFBotUI";
                this.ShowInTaskbar = false;
                this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                this.Text = "BFBot";
                this.TopMost = true;
                this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
                this.Load += new System.EventHandler(this.BFBot_Load);
                this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BFBot_FormClosing);
                this.Resize += new System.EventHandler(this.BFBot_Resize);
                this.contextMenuBFBot.ResumeLayout(false);
                this.statusStrip1.ResumeLayout(false);
                this.statusStrip1.PerformLayout();
                this.ResumeLayout(false);
                this.PerformLayout();

            }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuBFBot;
        private System.Windows.Forms.ToolStripMenuItem mnuRestore;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewerToolStripMenuItem;
        }
    }

