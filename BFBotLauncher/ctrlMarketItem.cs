using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace BFBotLauncher
    {
    public partial class ctrlMarketItem : UserControl
        {
        private BFBot.MarketItem m_marketItem;

        public ctrlMarketItem()
            {
            InitializeComponent();
            }

        public ctrlMarketItem(BFBot.MarketItem marketItem)
            {
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            groupBox1.Text = marketItem.Name;
            m_marketItem = marketItem;
            m_marketItem.OnMarketItemUpdate += new BFBot.MarketItem.MarketItemUpdateDelegate(m_marketItem_OnUpdateRunner);
            m_marketItem.OnMarketItemBacked += new BFBot.MarketItem.MarketItemBacked(m_marketItem_OnRunnerBacked);
            m_marketItem.OnMarketItemEqualised += new BFBot.MarketItem.MarketItemEqualised(m_marketItem_OnRunnerEqualised);
            }

        void m_marketItem_OnRunnerEqualised(BFBot.MarketItem runner)
            {
            LayedStake.Text = runner.LayStake().ToString("0.00");
            LayedOdds.Text = runner.LayOdds.ToString("0.00");
            WinProfit.Text = runner.WinProfit.ToString("0.00");
            LoseProfit.Text = runner.LoseProfit.ToString("0.00");
            this.BackColor = Color.LightGreen;
            }

        void m_marketItem_OnRunnerBacked(BFBot.MarketItem runner)
            {
            BackStake.Text = runner.BackedStake.ToString("0.00");
            BackOdds.Text = runner.BackedOdds.ToString("0.00");
            this.BackColor = Color.Magenta;
            }

        void m_marketItem_OnUpdateRunner()
            {
            //if(m_marketItem.MarketRunnerState == BFBot.BFBot.MarketItemState.Analysing)
                UpdatePrices();
            }

        private void UpdatePrices()
            {
            decimal[] backPrices = m_marketItem.GetBackPrices(18);
            decimal[] layPrices = m_marketItem.GetLayPrices(18);

            lblBack1.Text = backPrices[0].ToString("0.00");
            lblBack1.BackColor = lblBack2.BackColor;
            lblBack2.Text = backPrices[1].ToString("0.00");
            if (backPrices[1] > backPrices[0])
                lblBack2.BackColor = Color.Magenta;
            else if (backPrices[1] < backPrices[0])
                lblBack2.BackColor = Color.LightGreen;
            else
                lblBack2.BackColor = Color.Orange;

            lblBack3.Text = backPrices[2].ToString("0.00");
            if (backPrices[2] > backPrices[1])
                lblBack3.BackColor = Color.Magenta;
            else if (backPrices[2] < backPrices[1])
                lblBack3.BackColor = Color.LightGreen;
            else
                lblBack3.BackColor = Color.Orange;
            
            lblBack4.Text = backPrices[3].ToString("0.00");
            if (backPrices[3] > backPrices[2])
                lblBack4.BackColor = Color.Magenta;
            else if (backPrices[3] < backPrices[2])
                lblBack4.BackColor = Color.LightGreen;
            else
                lblBack4.BackColor = Color.Orange;
            
            lblBack5.Text = backPrices[4].ToString("0.00");
            if (backPrices[4] > backPrices[3])
                lblBack5.BackColor = Color.Magenta;
            else if (backPrices[4] < backPrices[3])
                lblBack5.BackColor = Color.LightGreen;
            else
                lblBack5.BackColor = Color.Orange;
            
            lblBack6.Text = backPrices[5].ToString("0.00");
            if (backPrices[5] > backPrices[4])
                lblBack6.BackColor = Color.Magenta;
            else if (backPrices[5] < backPrices[4])
                lblBack6.BackColor = Color.LightGreen;
            else
                lblBack6.BackColor = Color.Orange;
            
            lblBack7.Text = backPrices[6].ToString("0.00");
            if (backPrices[6] > backPrices[5])
                lblBack7.BackColor = Color.Magenta;
            else if (backPrices[6] < backPrices[5])
                lblBack7.BackColor = Color.LightGreen;
            else
                lblBack7.BackColor = Color.Orange;
            
            lblBack8.Text = backPrices[7].ToString("0.00");
            if (backPrices[7] > backPrices[6])
                lblBack8.BackColor = Color.Magenta;
            else if (backPrices[7] < backPrices[6])
                lblBack8.BackColor = Color.LightGreen;
            else
                lblBack8.BackColor = Color.Orange;
            
            lblBack9.Text = backPrices[8].ToString("0.00");
            if (backPrices[8] > backPrices[7])
                lblBack9.BackColor = Color.Magenta;
            else if (backPrices[8] < backPrices[7])
                lblBack9.BackColor = Color.LightGreen;
            else
                lblBack9.BackColor = Color.Orange;
            
            lblBack10.Text = backPrices[9].ToString("0.00");
            if (backPrices[9] > backPrices[8])
                lblBack10.BackColor = Color.Magenta;
            else if (backPrices[9] < backPrices[8])
                lblBack10.BackColor = Color.LightGreen;
            else
                lblBack10.BackColor = Color.Orange;
            
            lblBack11.Text = backPrices[10].ToString("0.00");
            if (backPrices[10] > backPrices[9])
                lblBack11.BackColor = Color.Magenta;
            else if (backPrices[10] < backPrices[9])
                lblBack11.BackColor = Color.LightGreen;
            else
                lblBack11.BackColor = Color.Orange;
            
            lblBack12.Text = backPrices[11].ToString("0.00");
            if (backPrices[11] > backPrices[10])
                lblBack12.BackColor = Color.Magenta;
            else if (backPrices[11] < backPrices[10])
                lblBack12.BackColor = Color.LightGreen;
            else
                lblBack12.BackColor = Color.Orange;
            
            lblBack13.Text = backPrices[13].ToString("0.00");
            if (backPrices[12] > backPrices[11])
                lblBack13.BackColor = Color.Magenta;
            else if (backPrices[12] < backPrices[11])
                lblBack13.BackColor = Color.LightGreen;
            else
                lblBack13.BackColor = Color.Orange;
            
            lblBack14.Text = backPrices[14].ToString("0.00");
            if (backPrices[13] > backPrices[12])
                lblBack14.BackColor = Color.Magenta;
            else if (backPrices[13] < backPrices[12])
                lblBack14.BackColor = Color.LightGreen;
            else
                lblBack14.BackColor = Color.Orange;
            
            lblBack15.Text = backPrices[15].ToString("0.00");
            if (backPrices[14] > backPrices[13])
                lblBack15.BackColor = Color.Magenta;
            else if (backPrices[14] < backPrices[13])
                lblBack15.BackColor = Color.LightGreen;
            else
                lblBack15.BackColor = Color.Orange;
            
            lblBack16.Text = backPrices[16].ToString("0.00");
            if (backPrices[15] > backPrices[14])
                lblBack16.BackColor = Color.Magenta;
            else if (backPrices[15] < backPrices[14])
                lblBack16.BackColor = Color.LightGreen;
            else
                lblBack16.BackColor = Color.Orange;
            
            lblBack17.Text = backPrices[17].ToString("0.00");
            if (backPrices[16] > backPrices[15])
                lblBack17.BackColor = Color.Magenta;
            else if (backPrices[16] < backPrices[15])
                lblBack17.BackColor = Color.LightGreen;
            else
                lblBack17.BackColor = Color.Orange;

            lblLay1.Text = layPrices[0].ToString("0.00");
            lblLay1.BackColor = lblLay2.BackColor;
            lblLay2.Text = layPrices[1].ToString("0.00");
            if (layPrices[1] > layPrices[0])
                lblLay2.BackColor = Color.Magenta;
            else if (layPrices[1] < layPrices[0])
                lblLay2.BackColor = Color.LightGreen;
            else
                lblLay2.BackColor = Color.Orange;

            lblLay3.Text = layPrices[2].ToString("0.00");
            if (layPrices[2] > layPrices[1])
                lblLay3.BackColor = Color.Magenta;
            else if (layPrices[2] < layPrices[1])
                lblLay3.BackColor = Color.LightGreen;
            else
                lblLay3.BackColor = Color.Orange;

            lblLay4.Text = layPrices[3].ToString("0.00");
            if (layPrices[3] > layPrices[2])
                lblLay4.BackColor = Color.Magenta;
            else if (layPrices[3] < layPrices[2])
                lblLay4.BackColor = Color.LightGreen;
            else
                lblLay4.BackColor = Color.Orange;

            lblLay5.Text = layPrices[4].ToString("0.00");
            if (layPrices[4] > layPrices[3])
                lblLay5.BackColor = Color.Magenta;
            else if (layPrices[4] < layPrices[3])
                lblLay5.BackColor = Color.LightGreen;
            else
                lblLay5.BackColor = Color.Orange;

            lblLay6.Text = layPrices[5].ToString("0.00");
            if (layPrices[5] > layPrices[4])
                lblLay6.BackColor = Color.Magenta;
            else if (layPrices[5] < layPrices[4])
                lblLay6.BackColor = Color.LightGreen;
            else
                lblLay6.BackColor = Color.Orange;

            lblLay7.Text = layPrices[6].ToString("0.00");
            if (layPrices[6] > layPrices[5])
                lblLay7.BackColor = Color.Magenta;
            else if (layPrices[6] < layPrices[5])
                lblLay7.BackColor = Color.LightGreen;
            else
                lblLay7.BackColor = Color.Orange;

            lblLay8.Text = layPrices[7].ToString("0.00");
            if (layPrices[7] > layPrices[6])
                lblLay8.BackColor = Color.Magenta;
            else if (layPrices[7] < layPrices[6])
                lblLay8.BackColor = Color.LightGreen;
            else
                lblLay8.BackColor = Color.Orange;

            lblLay9.Text = layPrices[8].ToString("0.00");
            if (layPrices[8] > layPrices[7])
                lblLay9.BackColor = Color.Magenta;
            else if (layPrices[8] < layPrices[7])
                lblLay9.BackColor = Color.LightGreen;
            else
                lblLay9.BackColor = Color.Orange;

            lblLay10.Text = layPrices[9].ToString("0.00");
            if (layPrices[9] > layPrices[8])
                lblLay10.BackColor = Color.Magenta;
            else if (layPrices[9] < layPrices[8])
                lblLay10.BackColor = Color.LightGreen;
            else
                lblLay10.BackColor = Color.Orange;

            lblLay11.Text = layPrices[10].ToString("0.00");
            if (layPrices[10] > layPrices[9])
                lblLay11.BackColor = Color.Magenta;
            else if (layPrices[10] < layPrices[9])
                lblLay11.BackColor = Color.LightGreen;
            else
                lblLay11.BackColor = Color.Orange;

            lblLay12.Text = layPrices[11].ToString("0.00");
            if (layPrices[11] > layPrices[10])
                lblLay12.BackColor = Color.Magenta;
            else if (layPrices[11] < layPrices[10])
                lblLay12.BackColor = Color.LightGreen;
            else
                lblLay12.BackColor = Color.Orange;

            lblLay13.Text = layPrices[13].ToString("0.00");
            if (layPrices[12] > layPrices[11])
                lblLay13.BackColor = Color.Magenta;
            else if (layPrices[12] < layPrices[11])
                lblLay13.BackColor = Color.LightGreen;
            else
                lblLay13.BackColor = Color.Orange;

            lblLay14.Text = layPrices[14].ToString("0.00");
            if (layPrices[13] > layPrices[12])
                lblLay14.BackColor = Color.Magenta;
            else if (layPrices[13] < layPrices[12])
                lblLay14.BackColor = Color.LightGreen;
            else
                lblLay14.BackColor = Color.Orange;

            lblLay15.Text = layPrices[15].ToString("0.00");
            if (layPrices[14] > layPrices[13])
                lblLay15.BackColor = Color.Magenta;
            else if (layPrices[14] < layPrices[13])
                lblLay15.BackColor = Color.LightGreen;
            else
                lblLay15.BackColor = Color.Orange;

            lblLay16.Text = layPrices[16].ToString("0.00");
            if (layPrices[15] > layPrices[14])
                lblLay16.BackColor = Color.Magenta;
            else if (layPrices[15] < layPrices[14])
                lblLay16.BackColor = Color.LightGreen;
            else
                lblLay16.BackColor = Color.Orange;

            lblLay17.Text = layPrices[17].ToString("0.00");
            if (layPrices[16] > layPrices[15])
                lblLay17.BackColor = Color.Magenta;
            else if (layPrices[16] < layPrices[15])
                lblLay17.BackColor = Color.LightGreen;
            else
                lblLay17.BackColor = Color.Orange;
            }
        }
    }
