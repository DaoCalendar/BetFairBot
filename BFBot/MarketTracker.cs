using System;
using System.Collections.Generic;
using System.Text;
using BetfairG = BFBot.com.betfair.api6.global;
using BetfairE = BFBot.com.betfair.api6.exchange;

namespace BFBot
    {
    public class MarketTracker
        {
        public static Exchange s_exchange = null;
        private System.Collections.Hashtable m_activeMarkets;
        private System.Collections.Hashtable m_closedMarkets;
        private System.Windows.Forms.Timer m_timer;
        private static MarketTracker m_instance;
        public int Day = 0;

        public delegate void MarketAdded(Market market);

        protected MarketTracker()
            {
            try
                {
                m_activeMarkets = new System.Collections.Hashtable();
                m_closedMarkets = new System.Collections.Hashtable();
                s_exchange = new Exchange();
                Login();
                m_timer = new System.Windows.Forms.Timer();
                m_timer.Tick += new EventHandler(m_timer_Tick);
                m_timer.Interval = 900000;
                //GetClosedMarkets();
                Process();
                }
            catch (Exception ex)
                {
                    BfBot.DumpToFile("Error in MarketTracker->MarketTracker : " + ex.Message);
                }
            }

        private void Login()
            {
            try
                {
                s_exchange.Login("xxxxx", "d!");
                }
            catch (Exception ex)
                {
                    BfBot.DumpToFile("Error in MarketTracker->Login : " + ex.Message);
                }
            }

        //private void GetClosedMarkets()
        //    {
        //        try
        //        {
        //            List<BFBotDB.DBClosedMarket> closedMarkets = new List<BFBotDB.DBClosedMarket>();
        //            closedMarkets = BFBotDB.BFBotDBWorker.Instance().GetClosedMarkets();
        //            foreach (BFBotDB.DBClosedMarket closedMarket in closedMarkets)
        //            {
        //                m_closedMarkets.Add(closedMarket.Name + "-" + closedMarket.Date + "-" + closedMarket.Time, closedMarket.Name);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            BFBot.DumpToFile("Error in MarketTracker->GetClosedMarkets : " + ex.Message);
        //        }
        //    }

        private void m_timer_Tick(object sender, EventArgs e)
            {
                Process();
            }

        //public bool Quitable()
        //    {
        //    BFBot.Quiting = true;
        //    foreach (Market market in m_activeMarkets.Values)
        //        {
        //        if (market.MarketState == BFBot.MarketState.Backed)
        //            return false;
        //        }
        //    return true;
        //    }

        public static MarketTracker Instance
            {
            get
                {
                if (m_instance == null)
                    m_instance = new MarketTracker();
                return m_instance;
                }
            }

        public Exchange Exchange
        {
            get { return s_exchange; }
        }

        public System.Collections.Hashtable ClosedMarkets()
            {
            return m_closedMarkets;
            }

        public System.Collections.Hashtable ActiveMarkets()
            {
            return m_activeMarkets;
            }

        public Market GetMarket(int id)
        {
            foreach (Market market in m_activeMarkets.Values)
            {
                if (market.MarketID == id)
                    return market;
            }
            return null;
        }

        private void Process()
            {
            try
                {
                if (m_activeMarkets.Count != 0)
                    return;
                
                string currentMarkets = s_exchange.GetAllMarketsUKHorseRacing();
                string[] marketsSplit = currentMarkets.Split(':');
                foreach (string str in marketsSplit)
                    {
                    if (str != "")
                        {
                        if (ValidMarket(str))
                            {
                            Market market = new Market(str);
                            if (!m_closedMarkets.ContainsKey(market.ExchangeID + " - " + market.MarketID))
                                {
                                market.InitialiseMarket();
                                if (market.IsMarketActive() == true && market.ValidMarket)
                                    {
                                    market.ActivateMarket();
                                    market.OnMarketBacked += new Market.MarketBackedDelegate(market_OnMarketBacked);
                                    market.OnMarketEqualised += new Market.MarketEqualisedDelegate(market_OnMarketEqualised);
                                    market.OnMarketClosed += new Market.MarketClosed(market_OnMarketClosed);
                                    m_activeMarkets.Add(market.ExchangeID + " - " + market.MarketID, market);
                                    //return;
                                    }
                                }
                            }
                        }
                    }
                }
            catch (Exception ex)
                {
                    BfBot.DumpToFile("Error in MarketTracker->Process : " + ex.Message);
                }
            }

        private bool ValidMarket(string s)
            {
            try
                {
                string[] parts = s.Split('~');

                if (m_activeMarkets.ContainsKey(parts[8] + " - " + parts[0]))
                    return false;
                if (parts[14] != "Y")
                    return false;
                if (parts[3] == "SUSPENDED")
                    return false;
                if (parts[5].Split('\\').Length > 4)
                    return false;
                if (parts[1] == "To Be Placed")
                    return false;
                return true;
                }
            catch (Exception ex)
                {
                    BfBot.DumpToFile("Error in MarketTracker->ValidMarket : " + ex.Message);
                return false;
                }
            }

        void market_OnMarketClosed(Market market)
            {
                try
                {
                    if (!m_closedMarkets.ContainsKey(market.ExchangeID + " - " + market.MarketID))
                    {
                        m_closedMarkets.Add(market.ExchangeID + " - " + market.MarketID, market);
                        m_activeMarkets.Remove(market.ExchangeID + " - " + market.MarketID);
                    }
                }
                catch (Exception ex)
                {
                    BfBot.DumpToFile("Error in MarketTracker->OnMarketClosed : " + ex.Message);
                }
            }

        void market_OnMarketEqualised(Market market)
            {
            //string message = "Equalised : ";

            //BFBot.DumpToFile(message);
            }

        void market_OnMarketBacked(Market market)
            {
            //string message = "Backed : ";

            //BFBot.DumpToFile(message);
            }
        }
    }
