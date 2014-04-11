using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BFBotLauncher
    {
    public partial class frmMarketDetails : Form
        {
        private System.Collections.Hashtable m_activeMarkets;
        private System.Collections.Hashtable m_closedMarkets;
        //private TreeNode m_closedMarketsNode;
        //private TreeNode m_activeMarketsNode;
        //private List<BFBot.Market> m_marketsToBeMoved;
        private BFBot.MarketTracker m_marketTracker;

        public frmMarketDetails()
            {
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            if (m_marketTracker == null)
                {
                m_marketTracker = BFBot.MarketTracker.Instance;
                m_marketTracker.OnMarketAdded += new BFBot.MarketTracker.MarketAdded(m_marketTracker_OnMarketAdded);
                m_activeMarkets = BFBot.MarketTracker.Instance.ActiveMarkets();
                }
            timer1.Interval = 10000;
            
            //m_marketsToBeMoved = new List<BFBot.Market>();

            listViewActiveMarkets1.Columns.Add("Meeting");
            listViewActiveMarkets1.Columns.Add("Market Date");
            listViewActiveMarkets1.Columns.Add("Market Close");
            listViewActiveMarkets1.Columns.Add("Seconds To Off");
            listViewActiveMarkets1.Columns.Add("Back Stake");
            listViewActiveMarkets1.Columns.Add("Back Price");
            listViewActiveMarkets1.Columns.Add("Selection");
            listViewActiveMarkets1.Columns.Add("Lay Stake");
            listViewActiveMarkets1.Columns.Add("Lay Price");

            listViewActiveMarkets1.Visible = true;
            foreach (System.Collections.DictionaryEntry entry in m_activeMarkets)
                {
                BFBot.Market market = (BFBot.Market)entry.Value;
                AddMarket(market);
                }

            List<BFBotDB.DBClosedMarket> closedMarkets = BFBotDB.BFBotDBWorker.Instance().GetClosedMarkets();
            foreach (BFBotDB.DBClosedMarket closedMarket in closedMarkets)
                {
                //m_closedMarkets.Add(marketName);
                ListViewItem listViewItem = new ListViewItem(closedMarket.Name + "-" + closedMarket.Date + "-" + closedMarket.Time, 4);
                
                listViewClosedMarkets.Items.Add(listViewItem);
                }


            timer1.Start();
            }

        void m_marketTracker_OnMarketAdded(BFBot.Market market)
            {
            try
                {
                AddMarket(market);
                }
            catch (Exception ex) 
                {
                AddMarket(market);
                }
            }

        void market_OnUpdateMarket(BFBot.Market market)
            {

            }

        public void AddMarket(BFBot.Market market)
            {
            if (!listViewActiveMarkets1.Items.Contains(market.GetMarketViewItem))
                {
                listViewActiveMarkets1.Items.Add(market.GetMarketViewItem);
                market.OnMarketClosed += new BFBot.Market.MarketClosed(market_OnMarketClosed);
                market.OnMarketBacked += new BFBot.Market.MarketBackedDelegate(market_OnMarketBacked);
                market.OnMarketEqualised += new BFBot.Market.MarketEqualisedDelegate(market_OnMarketEqualised);
                market.OnUpdateMarket += new BFBot.Market.MarketUpdateDelegate(market_OnUpdateMarket);
                }
            }

        void market_OnMarketEqualised(BFBot.Market market)
            {
            ChangeMarketIcon(market.Name, 2);
            }

        void market_OnMarketBacked(BFBot.Market market)
            {
            ChangeMarketIcon(market.Name, 1);
            }


        void market_OnMarketClosed(BFBot.Market market)
            {
            listViewActiveMarkets1.Items.Remove(market.GetMarketViewItem);
            while(listViewActiveMarkets1.Items.Contains(market.GetMarketViewItem))
                {}
            ListViewItem closedItem = new ListViewItem(market.MarketID, 4);
            closedItem.Tag = market;
            listViewClosedMarkets.Items.Add(closedItem);
            BFBotDB.BFBotDBWorker.Instance().CloseMarket(market.MarketGUID);
            }

        private void ChangeMarketIcon(string marketName, int index)
            {
            foreach (ListViewItem listViewItem in listViewActiveMarkets1.Items)
                {
                if (listViewItem != null)
                    {
                    if (listViewItem.Text == marketName)
                        listViewItem.ImageIndex = index;
                    }
                }
            }

        private void frmMarketDetails_FormClosing(object sender, FormClosingEventArgs e)
            {
            foreach (BFBot.Market market in m_activeMarkets.Values)
                {
                market.OnMarketClosed -= new BFBot.Market.MarketClosed(market_OnMarketClosed);
                market.OnMarketBacked -= new BFBot.Market.MarketBackedDelegate(market_OnMarketBacked);
                market.OnMarketEqualised -= new BFBot.Market.MarketEqualisedDelegate(market_OnMarketEqualised);
                market.OnUpdateMarket -= new BFBot.Market.MarketUpdateDelegate(market_OnUpdateMarket);
                }

            listViewActiveMarkets1.Items.Clear();
            listViewClosedMarkets.Items.Clear();
            }

        private void detailsToolStripMenuItem1_Click(object sender, EventArgs e)
            {
            ClosedMarketDetails closedMarketDetails;

            ListView.SelectedListViewItemCollection col = listViewClosedMarkets.SelectedItems;

            ListViewItem item = col[0];

            BFBot.Market selectedMarket = item.Tag as BFBot.Market;

            //BFBot.MarketViewItem selectedMarketViewItem = col[0] as BFBot.MarketViewItem;
            if (selectedMarket != null)
                closedMarketDetails = new ClosedMarketDetails(selectedMarket.MarketGUID);
            else
                {
                string[] items = item.Text.Split('-');
                closedMarketDetails = new ClosedMarketDetails(items[0], items[1], items[2]);
                }
            closedMarketDetails.ShowDialog();
            }

        private void listViewActiveMarkets1_SelectedIndexChanged(object sender, EventArgs e)
            {

            }

        private void listViewActiveMarkets1_DoubleClick(object sender, EventArgs e)
            {

            }

        private void detailsToolStripMenuItem_Click(object sender, EventArgs e)
            {
            ListView.SelectedListViewItemCollection col = listViewActiveMarkets1.SelectedItems;

            ListViewItem item = col[0];

            BFBot.Market selectedMarket = item.Tag as BFBot.Market;

            frmMarketView marketView = new frmMarketView(selectedMarket);
            marketView.Show();
            }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
            {
            listViewActiveMarkets1.Clear();
            }

        //private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        //    {
        //    }

        //private void detailsToolStripMenuItem_Click(object sender, EventArgs e)
        //    {
        //    tabControlActiveMarkets.TabPages.Add("TEST TEST");
        //    }

        //private void timer1_Tick(object sender, EventArgs e)
        //    {
        //    }

        }
    }