using System;
using System.Collections.Generic;
using System.Text;

namespace BFBot
    {
    public class Markets
        {
        private SortedList<DateTime, Market> m_markets;

        public Markets()
            {
            m_markets = new SortedList<DateTime, Market>();
            }

        public void Add(Market market)
            {
            m_markets.Add(market.MarketClose, market);
            }

        //public Market GetNextMarket(Market market)
        //    {
        //    Market returnValue = null;
        //    foreach (Market m in m_markets)
        //        {
        //        if (returnValue == null)
        //            returnValue = m;
        //        else
        //            {
        //            if (returnValue.SecondsToOff > m.SecondsToOff)
        //                returnValue = m;
        //            }
        //        }
        //    return returnValue;
        //    }


        }
    }
