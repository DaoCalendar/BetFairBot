using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace BFBot
    {
    public class MarketDetailsView
        {
        private Market m_market;
        private List<ListViewItem> m_marketDetailViewItems;
        private ListViewItem m_listViewItem;

        public MarketDetailsView(Market market)
            {
            m_marketDetailViewItems = new List<ListViewItem>();
            m_market = market;

            foreach (MarketRunner marketRunner in m_market.Runners)
                {
                m_marketDetailViewItems.Add(marketRunner.DisplayItem());
                }
            }

        public List<ListViewItem> Items()
            {
            return m_marketDetailViewItems;
            }
        }
    }
