using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using BetfairG = BFBot.com.betfair.api6.global;
using BetfairE = BFBot.com.betfair.api6.exchange;

namespace BFBotLauncher
{
    public partial class MarketItemControl : UserControl
    {
        private BFBot.MarketItem m_marketItem;

        private delegate void delegateUpdateText(Control ctrl,String odds, string amountavailable);
        private delegate void delegateUpdateColor(Control ctrl, Color color);
        
        public MarketItemControl()
        {
            InitializeComponent();
        }

        public MarketItemControl(BFBot.MarketItem marketItem)
        {
            InitializeComponent();
            m_marketItem = marketItem;
            groupBoxMarketItem.Text = m_marketItem.Name;
            m_marketItem.OnMarketItemUpdate += new BFBot.MarketItem.MarketItemUpdateDelegate(m_marketItem_OnMarketItemUpdate);
            m_marketItem.OnMarketItemBacked += new BFBot.MarketItem.MarketItemBacked(m_marketItem_OnMarketItemBacked);
            m_marketItem.OnMarketItemEqualised += new BFBot.MarketItem.MarketItemEqualised(m_marketItem_OnMarketItemEqualised);
            m_marketItem.OnMarketItemLayed += new BFBot.MarketItem.MarketItemLayed(m_marketItem_OnMarketItemLayed);
        }

        void m_marketItem_OnMarketItemLayed()
        {
            //throw new Exception("The method or operation is not implemented.");
        }

        void m_marketItem_OnMarketItemEqualised(BFBot.MarketItem marketItem)
        {
            //throw new Exception("The method or operation is not implemented.");
        }

        void m_marketItem_OnMarketItemBacked(BFBot.MarketItem marketItem)
        {
            try
            {
                if (groupBoxMarketItem.InvokeRequired)
                    groupBoxMarketItem.Invoke(new delegateUpdateColor(UpdateBackGroundColor), groupBoxMarketItem, Color.LightGreen);
                else
                    groupBoxMarketItem.BackColor = Color.LawnGreen;
                //throw new Exception("The method or operation is not implemented.");
            }
            catch (Exception ex)
            {
                BFBot.BfBot.DumpToFile("Error in MarketItemControl->OnMarketItemBacked : " + ex.Message);
            }
        }

        void m_marketItem_OnMarketItemUpdate()
        {
            try
            {
                BetfairE.Price[] BackPrices;
                BetfairE.Price[] LayPrices;

                BackPrices = m_marketItem.BackPrices();
                LayPrices = m_marketItem.LayPrices();

                if (BackPrices.Length >= 1)
                {
                    ShowMovementByColor(textBoxBack1, BackPrices[0].price, true);
                    if (textBoxBack1.InvokeRequired)
                        textBoxBack1.Invoke(new delegateUpdateText(UpdateTextBox), textBoxBack1, BackPrices[0].price.ToString(), BackPrices[0].amountAvailable.ToString());
                    else
                        textBoxBack1.Text = BackPrices[0].price.ToString() + Environment.NewLine + "£" + BackPrices[0].amountAvailable.ToString();
                }
                if (BackPrices.Length >= 2)
                {
                    ShowMovementByColor(textBoxBack2, BackPrices[1].price, true);
                    if (textBoxBack2.InvokeRequired)
                        textBoxBack2.Invoke(new delegateUpdateText(UpdateTextBox), textBoxBack2, BackPrices[1].price.ToString(), BackPrices[1].amountAvailable.ToString());
                    else
                        textBoxBack2.Text = BackPrices[0].price.ToString() + Environment.NewLine + "£" + BackPrices[0].amountAvailable.ToString();
                }
                if (BackPrices.Length >= 3)
                {
                    ShowMovementByColor(textBoxBack3, BackPrices[2].price, true);
                    if (textBoxBack3.InvokeRequired)
                        textBoxBack3.Invoke(new delegateUpdateText(UpdateTextBox), textBoxBack3, BackPrices[2].price.ToString(), BackPrices[2].amountAvailable.ToString());
                    else
                        textBoxBack3.Text = BackPrices[0].price.ToString() + Environment.NewLine + "£" + BackPrices[0].amountAvailable.ToString();
                }
                if (LayPrices.Length >= 1)
                {
                    ShowMovementByColor(textBoxLay1, LayPrices[0].price, false);
                    if (textBoxLay1.InvokeRequired)
                        textBoxLay1.Invoke(new delegateUpdateText(UpdateTextBox), textBoxLay1, LayPrices[0].price.ToString(), LayPrices[0].amountAvailable.ToString());
                    else
                        textBoxLay1.Text = LayPrices[0].price.ToString() + Environment.NewLine + "£" + LayPrices[0].amountAvailable.ToString();
                }
                if (LayPrices.Length >= 2)
                {
                    ShowMovementByColor(textBoxLay2, LayPrices[1].price, false);
                    if (textBoxLay2.InvokeRequired)
                        textBoxLay2.Invoke(new delegateUpdateText(UpdateTextBox), textBoxLay2, LayPrices[1].price.ToString(), LayPrices[1].amountAvailable.ToString());
                    else
                        textBoxLay2.Text = LayPrices[1].price.ToString() + Environment.NewLine + "£" + LayPrices[1].amountAvailable.ToString();
                }
                if (LayPrices.Length >= 3)
                {
                    ShowMovementByColor(textBoxLay3, LayPrices[2].price, false);
                    if (textBoxLay3.InvokeRequired)
                        textBoxLay3.Invoke(new delegateUpdateText(UpdateTextBox), textBoxLay3, LayPrices[2].price.ToString(), LayPrices[2].amountAvailable.ToString());
                    else
                        textBoxLay3.Text = LayPrices[2].price.ToString() + Environment.NewLine + "£" + LayPrices[2].amountAvailable.ToString();
                }
            }
            catch (Exception ex)
            {
                BFBot.BfBot.DumpToFile("Error in MarketItemControl->OnMarketItemUpdate : " + ex.Message);
            }
        }

        private void ShowMovementByColor(Control ctrl, double newPrice, bool back)
        {
            string[] parts;
            parts = ctrl.Text.Split('£');
            if (parts.Length > 1)
            {
                double price = double.Parse(parts[0]);

                if (price > newPrice)
                {
                    if (back)
                    {
                        if (ctrl.InvokeRequired)
                            ctrl.Invoke(new delegateUpdateColor(UpdateBackGroundColor), ctrl, Color.LightGreen);
                        else
                            ctrl.BackColor = Color.LightGreen;
                    }
                    else
                    {
                        if (ctrl.InvokeRequired)
                            ctrl.Invoke(new delegateUpdateColor(UpdateBackGroundColor), ctrl, Color.IndianRed);
                        else
                            ctrl.BackColor = Color.IndianRed;
                    }
                }
                else if (price == newPrice)
                {
                    if (ctrl.InvokeRequired)
                        ctrl.Invoke(new delegateUpdateColor(UpdateBackGroundColor), ctrl, Color.LightYellow);
                    else
                        ctrl.BackColor = Color.LightYellow;

                }
                else if (price < newPrice)
                {
                    if (back)
                    {
                        if (ctrl.InvokeRequired)
                            ctrl.Invoke(new delegateUpdateColor(UpdateBackGroundColor), ctrl, Color.IndianRed);
                        else
                            ctrl.BackColor = Color.IndianRed;
                    }
                    else
                    {
                        if (ctrl.InvokeRequired)
                            ctrl.Invoke(new delegateUpdateColor(UpdateBackGroundColor), ctrl, Color.LightGreen);
                        else
                            ctrl.BackColor = Color.LightGreen;
                    }
                }
            }
        }

        private void UpdateBackGroundColor(Control ctrl, Color color)
        {
            ctrl.BackColor = color;
        }

        private void UpdateTextBox(Control ctrl, string odds, string amount)
        {
            ctrl.Text = odds + Environment.NewLine + "£" + amount;
        }

        private void textBoxBack1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("Backed");
        }

    }
}
