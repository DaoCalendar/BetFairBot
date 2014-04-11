using System;
using System.Collections.Generic;
using System.Text;

namespace BFBot
    {
    public class BfPrice
        {
        private readonly string m_odds;
        private readonly string m_amountAvailable;
        private readonly string m_type;
        private readonly string m_depth;

        public BfPrice(string odds, string amountAvailable, string type, string depth)
            {
            m_odds = odds;
            m_amountAvailable = amountAvailable;
            m_type = type;
            m_depth = depth;
            }

        public string Odds
            {
            get { return m_odds; }
            }

        public string AmountAvailable
            {
            get { return m_amountAvailable; }
            }

        public string Type
            {
            get { return m_type; }
            }

        public string Depth
            {
            get { return m_depth; }
            }
        }
    }
