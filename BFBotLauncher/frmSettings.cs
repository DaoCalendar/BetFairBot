using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BFBotLauncher
    {
    public partial class frmSettings : Form
        {
        public frmSettings()
            {
            InitializeComponent();
            this.nudMaxStake.Value = (decimal)BFBot.BfBot.MaxStake;
            this.nudMaxBalance.Value = (decimal)BFBot.BfBot.TransferLimit;
            this.nudSecondsToBack.Value = BFBot.BfBot.SecondsToClose;
            this.trackBarOverallWeight.Value = BFBotLauncher.BFBotUI.IniFile.ReadInt("preferences", "overall_weight", 50);
            this.trackBarOneTwoWeight.Value = BFBotLauncher.BFBotUI.IniFile.ReadInt("preferences", "one_two_weight", 50);
            this.trackBarOneFourWeight.Value = BFBotLauncher.BFBotUI.IniFile.ReadInt("preferences", "one_four_weight", 50);
            this.trackBarOneTenWeight.Value = BFBotLauncher.BFBotUI.IniFile.ReadInt("preferences", "one_ten_weight", 50);
            //this.checkBoxEmailNotification.Checked = BFBotLauncher.BFBotUI.IniFile.ReadBool("preferences", "email notification", false);
            //BFBot.BFBot.EmailNotification = this.checkBoxEmailNotification.Checked;
            //this.textBoxEmailAddress.Text = BFBotLauncher.BFBotUI.IniFile.ReadString("preferences", "email notification address", "");
            }

        private void frmSettings_FormClosed(object sender, FormClosedEventArgs e)
            {
                BFBot.BfBot.MaxStake = (double)this.nudMaxStake.Value;
                BFBot.BfBot.TransferLimit = (double)this.nudMaxBalance.Value;
                BFBot.BfBot.SecondsToClose = (int)this.nudSecondsToBack.Value;

            BFBotLauncher.BFBotUI.IniFile.WriteDouble("preferences", "max_stake", (double)this.nudMaxStake.Value);
            BFBotLauncher.BFBotUI.IniFile.WriteDouble("preferences", "transfer_limit", (double)this.nudMaxBalance.Value);
            BFBotLauncher.BFBotUI.IniFile.WriteInt("preferences", "seconds_to_back", (int)this.nudSecondsToBack.Value);
            BFBotLauncher.BFBotUI.IniFile.WriteInt("preferences", "overall_weight", (int)this.trackBarOverallWeight.Value);
            BFBotLauncher.BFBotUI.IniFile.WriteInt("preferences", "one_two_weight", (int)this.trackBarOneTwoWeight.Value);
            BFBotLauncher.BFBotUI.IniFile.WriteInt("preferences", "one_four_weight", (int)this.trackBarOneFourWeight.Value);
            BFBotLauncher.BFBotUI.IniFile.WriteInt("preferences", "one_ten_weight", (int)this.trackBarOneTenWeight.Value);
            //BFBotLauncher.BFBotUI.IniFile.WriteBool("preferences", "email notifications", (bool)this.checkBoxEmailNotification.Checked);
            //BFBotLauncher.BFBotUI.IniFile.WriteString("preferences", "email notification address", (string)this.textBoxEmailAddress.Text);

            BFBotLauncher.BFBotUI.IniFile.Flush();
            BFBotLauncher.BFBotUI.IniFile.Save();
            }

        private void trackBarOverallWeight_ValueChanged(object sender, EventArgs e)
            {
            grpOverallWeight.Text = "Overall Weight " + trackBarOverallWeight.Value.ToString() + " %";            
            }

        private void trackBarOneTwoWeight_ValueChanged(object sender, EventArgs e)
            {
            grpOneTwoWeight.Text = "1/2 Weight " + trackBarOneTwoWeight.Value.ToString() + " %";
            }

        private void trackBarOneFourWeight_ValueChanged(object sender, EventArgs e)
            {
            grpOneTwoWeight.Text = "1/4 Weight " + trackBarOneFourWeight.Value.ToString() + " %";
            }

        private void trackBarOneTenWeight_ValueChanged(object sender, EventArgs e)
            {
            grpOneTenWeight.Text = "1/10 Weight " + trackBarOneTenWeight.Value.ToString() + " %";
            }

        
        }
    }