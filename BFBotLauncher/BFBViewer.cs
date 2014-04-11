using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BFBotLauncher
{
    public partial class BfbViewer : Form
    {
        public BfbViewer()
        {
            InitializeComponent();
            PopulateMarkets();
        }

        private void PopulateMarkets()
        {
            System.Collections.Hashtable markets = BFBot.MarketTracker.Instance.ActiveMarkets();
            foreach(BFBot.Market market in markets.Values)
            {
                listBoxMarkets.Items.Add(market.RaceDescription() + "  @  " + market.MarketID);
                market.OnMarketClosed += market_OnMarketClosed;
            }
        }

        void market_OnMarketClosed(BFBot.Market market)
        {
            listBoxMarkets.Items.RemoveAt(listBoxMarkets.Items.IndexOf(market.RaceDescription() + "  @  " + market.MarketID));
            //throw new Exception("The method or operation is not implemented.");
        }

        private void listBoxMarkets_Click(object sender, EventArgs e)
        {
            try
            {
                String selected = listBoxMarkets.SelectedItem.ToString();
                String[] parts = selected.Split('@');
                MarketViewer marketViewer = new MarketViewer(GetSelectedMarket(int.Parse(parts[1])));
                marketViewer.Show();
                //LoadMarketDetails((parts[1]).Trim());
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error in BFBViewer->listBoxMarkets_Click : " + ex.Message);
            }
        }

        private BFBot.Market GetSelectedMarket(int marketId)
        {
            System.Collections.Hashtable markets = BFBot.MarketTracker.Instance.ActiveMarkets();
            foreach (BFBot.Market market in markets.Values)
            {
                //if (market.MarketID.ToString().Trim() == marketId.Trim())
                if (market.MarketID == marketId)
                    return market;
            }
            return null;
        }
        //private void LoadMarketDetails(string id)
        //{
        //    //listBoxMarketItems.Items.Clear();
        //    //flowLayoutPanelMarketItems.Controls.Clear();
        //    //BFBot.Market selectedMarket = BFBot.MarketTracker.Instance.GetMarket(int.Parse(id));
        //    //foreach (BFBot.MarketItem marketItem in selectedMarket.GetMarketItems().Values)
        //    //{
        //    //    flowLayoutPanelMarketItems.Controls.Add(new MarketItemControl(marketItem));
        //    //}
        //}
    }
}