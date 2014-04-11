using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BFBot;

namespace BFBotLauncher
    {
    public partial class BFBotUI : Form
        {
        private int m_imageIndex = 0;
        private bool m_quit = false;
        private readonly BFBot.MarketTracker m_marketTracker;
        private readonly Icon[] m_icons = new Icon[2];
        private static readonly Settings m_iniFile = new Settings(System.IO.Path.GetDirectoryName(Application.ExecutablePath.ToString()) + "\\bfbot_settings.ini");
        private frmSettings m_settingsForm;
        private BfbViewer m_marketView;

        public BFBotUI()
            {
            InitializeComponent();

            BFBot.BfBot.Quiting = false;
            BFBot.BfBot.Balance = (double)m_iniFile.ReadDouble("account", "balance", 20.00);
            BFBot.BfBot.MaxStake = (double)m_iniFile.ReadDouble("preferences", "max_stake", 100.00);
            BFBot.BfBot.SecondsToClose = m_iniFile.ReadInt("preferences", "seconds_to_back", 120);
            BFBot.BfBot.TransferLimit = (double)m_iniFile.ReadDouble("preferences", "transfer_limit", 1000.00);
            BFBot.BfBot.Transfered = (double)m_iniFile.ReadDouble("account", "transfered", 0.00);
            //BFBot.BFBot.EmailNotification = (bool)m_iniFile.ReadBool("preferences", "email notifications", false);

            m_marketTracker = BFBot.MarketTracker.Instance;
            //this.Icon = new Icon(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("BFBotLauncher.MarketStateAnalysing.ico"));

            m_icons[0] = new Icon(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("BFBotLauncher.bfbot1-1.ico"));
            m_icons[1] = new Icon(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("BFBotLauncher.bfbot1-18.ico"));
            //this.Icon = new Icon(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("BFBotLauncher.MarketStateAnalysing.ico"));
            timer1.Interval = 500;
            }

        public static Settings IniFile
            {
            get { return m_iniFile; }
            }

        private void BFBot_Resize(object sender, EventArgs e)
            {
            if (FormWindowState.Minimized == WindowState)
                Hide();
            }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
            {
            Show();
            WindowState = FormWindowState.Normal;
            }

        private void BFBot_FormClosing(object sender, FormClosingEventArgs e)
            {
                if (m_quit == false)
                {
                    Hide();
                    e.Cancel = true;
                }
            }

        private void mnuRestore_Click(object sender, EventArgs e)
            {
            Show();
            WindowState = FormWindowState.Normal;
            }

        private void mnuExit_Click(object sender, EventArgs e)
            {
            //BFBot.BFBot.Quiting = true;
            //if (m_marketTracker.Quitable())
            //    {
            //    m_quit = true;
            //    //while (!m_marketTracker.Quitable())
            //    //    ;
                m_quit = true;
                SaveBFBotSettings();
                Application.Exit(new CancelEventArgs(false));
            //    }
            }

        private void BFBot_Load(object sender, EventArgs e)
            {
            Hide();
            }

        private void notifyIcon1_MouseMove(object sender, MouseEventArgs e)
            {
            if(m_marketTracker != null)
                notifyIcon1.Text = string.Format("Day = {0} - £ {1} Transfered = £{2}", m_marketTracker.Day.ToString(), BFBot.BfBot.GetAccount.Balance.ToString("0.00"), BFBot.BfBot.GetAccount.AmountTransferd.ToString("0.00"));
            }

        private void btnTest_Click(object sender, EventArgs e)
            {
            //BFBot.BFBot.SendMailMessage("test", "test email from BFBot");
            }

        private void timer1_Tick(object sender, EventArgs e)
            {
            if (m_marketTracker == null)
                return;
            System.Threading.Thread.Sleep(100);
            if (m_imageIndex == 0)
                m_imageIndex = 1;
            else
                m_imageIndex = 0;
            notifyIcon1.Icon = m_icons[m_imageIndex];
            toolStripStatusLabel1.Text = string.Format("Transfered = £{0}", BFBot.BfBot.GetAccount.AmountTransferd.ToString("0.00"));
            //toolStripStatusLabel2.Text = " [current market count = " + m_marketTracker.ActiveMarkets().Count + " ]";
            toolStripStatusLabel2.Text = string.Format(" Curent Balance = £{0}", BFBot.BfBot.GetAccount.Balance);
            }

        private void SaveBFBotSettings()
            {
                m_iniFile.WriteDouble("account", "balance", (double)BFBot.BfBot.GetAccount.Balance);
                m_iniFile.WriteDouble("account", "transfered", (double)BFBot.BfBot.Transfered);
            m_iniFile.Flush();
            m_iniFile.Save();
            }

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
            {
            m_settingsForm = new frmSettings();
            m_settingsForm.ShowDialog();
            }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //aaaaa;

        }

        private void viewerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_marketView = new BfbViewer();
            m_marketView.ShowDialog();
        }
        }
    }