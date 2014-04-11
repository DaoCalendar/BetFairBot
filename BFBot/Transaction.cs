using System;
using System.Collections.Generic;
using System.Text;

namespace BFBot
    {
    public class Transaction
        {
        private decimal m_stake;
        private decimal m_backOdds;
        private decimal m_layOdds;
        private decimal m_profit;

        public Transaction(decimal stake, decimal backOdds, decimal layOdds, decimal profit)
            {
            m_stake = stake;
            m_backOdds = backOdds;
            m_layOdds = layOdds;
            m_profit = profit;
            }

        public decimal Stake
            {
            get { return m_stake; }
            set { m_stake = value; }
            }

        public decimal BackOdds
            {
            get { return m_backOdds; }
            set { m_backOdds = value; }
            }

        public decimal LayOdds
            {
            get { return m_layOdds; }
            set { m_layOdds = value; }
            }

        public decimal Profit
            {
            get { return m_profit; }
            set { m_profit = value; }
            }

        public System.Windows.Forms.ListViewItem DisplayItem()
            {
            System.Windows.Forms.ListViewItem item = new System.Windows.Forms.ListViewItem(m_stake.ToString("0.00"));
            item.SubItems.Add(m_backOdds.ToString("0.00"));
            item.SubItems.Add(m_layOdds.ToString("0.00"));
            item.SubItems.Add(m_profit.ToString("0.00"));

            return item;
            }
        }
    }
