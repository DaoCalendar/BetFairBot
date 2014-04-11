using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BFBotLauncher
{
    public partial class MarketViewer : Form
    {
        private delegate void delegateUpdateText(Control ctrl, String value);
        private delegate void delegateChangeBackgroundColor(Control ctrl, Color color);

        private readonly BFBot.Market m_market;

        public MarketViewer(BFBot.Market market)
        {
            InitializeComponent();
            m_market = market;

            m_market.OnMarketBacked += new BFBot.Market.MarketBackedDelegate(m_market_OnMarketBacked);
            m_market.OnMarketClosed += new BFBot.Market.MarketClosed(m_market_OnMarketClosed);
            m_market.OnMarketEqualised += new BFBot.Market.MarketEqualisedDelegate(m_market_OnMarketEqualised);
            m_market.OnUpdateMarket += new BFBot.Market.MarketUpdateDelegate(m_market_OnUpdateMarket);
            m_market.OnMarketInPlay += new BFBot.Market.MarketInPlayAlert(m_market_OnMarketInPlay);

            UpdateMarketDetails();

            foreach(BFBot.MarketItem marketItem in m_market.GetMarketItems().Values)
            {
                flowLayoutPanel1.Controls.Add(new MarketItemControl(marketItem));
            }
            m_market.MarketUpdateTimer();
        }

        void m_market_OnMarketInPlay(BFBot.Market market)
        {
            if (groupBoxRaceDetails.InvokeRequired)
                groupBoxRaceDetails.Invoke(new delegateChangeBackgroundColor(ChangeBackgroundColor), groupBoxRaceDetails, Color.LightSeaGreen);
            else
                groupBoxRaceDetails.BackColor = Color.LightSeaGreen;
        }

        void m_market_OnUpdateMarket(BFBot.Market market)
        {
            UpdateMarketDetails();
        }

        void m_market_OnMarketEqualised(BFBot.Market market)
        {
            //throw new Exception("The method or operation is not implemented.");
        }

        void m_market_OnMarketClosed(BFBot.Market market)
        {
            //this.Enabled = false;
            //throw new Exception("The method or operation is not implemented.");
        }

        void m_market_OnMarketBacked(BFBot.Market market)
        {
            //groupBoxRaceDetails.BackColor = Color.Green;
            //throw new Exception("The method or operation is not implemented.");
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            m_market.CallUpdateMarket();
            UpdateMarketDetails();
        }

        private void UpdateMarketDetails()
        {
            try
            {
                if (groupBoxRaceDetails.InvokeRequired)
                    groupBoxRaceDetails.Invoke(new delegateUpdateText(UpdateText), groupBoxRaceDetails, m_market.RaceDescription());
                else
                    groupBoxRaceDetails.Text = m_market.RaceDescription();

                if (label1.InvokeRequired)
                    label1.Invoke(new delegateUpdateText(UpdateText), label1, m_market.TimeToOffTime().TimeOfDay.ToString());
                else
                    label1.Text = m_market.TimeToOffTime().TimeOfDay.ToString();

                if (label2.InvokeRequired)
                    label3.Invoke(new delegateUpdateText(UpdateText), label2, m_market.GetFavourite.Name + " : " + m_market.GetFavourite.BackPrice.ToString());
                else
                    label2.Text = m_market.GetFavourite.Name;

                if (label3.InvokeRequired)
                    label3.Invoke(new delegateUpdateText(UpdateText), label3, m_market.SuspendTime.ToString());
                else
                    label3.Text = m_market.SuspendTime.ToString();

                if (label4.InvokeRequired)
                    label4.Invoke(new delegateUpdateText(UpdateText), label4, m_market.GetSecondFavourite.Name + " : " + m_market.GetSecondFavourite.BackPrice.ToString());
                else
                    label4.Text = m_market.GetSecondFavourite.Name;
            }
            catch (Exception ex)
            {
                BFBot.BfBot.DumpToFile("Error in MarketViewer->UpdateMarketDetails" + ex.Message);
            }
        }

        private void UpdateText(Control ctrl, string value)
        {
            ctrl.Text = value;
        }

        private void ChangeBackgroundColor(Control ctrl, Color color)
        {
            ctrl.BackColor = color;
        }
    }
}