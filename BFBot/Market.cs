using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using BetfairG = BFBot.com.betfair.api6.global;
using BetfairE = BFBot.com.betfair.api6.exchange;

namespace BFBot
    {
    public class Market
        {
        private int m_marketId;
        private string m_marketName;
        private string m_meetingID;
        private List<MarketItem> m_interestedMarketItems = new List<MarketItem>();
        private string m_marketType;
        private string m_marketStatus;
        private DateTime m_eventDate;
        private string m_menuPath;
        private string m_eventHirerarchy;
        private string m_betDelay;
        private int m_exchangeId;
        private string m_countryCode;
        private DateTime m_lastRefresh;
        private int m_numberOfRunners;
        private int m_numberOfWinners;
        private double m_totalAmountMatched;
        private string m_lastItem;
        private DateTime m_suspendTime;
        private bool m_validMarket = false;
        private BetfairE.Market m_bfMarket;
        private System.Collections.Hashtable m_marketItems = new System.Collections.Hashtable();
        private System.Timers.Timer m_timer = new System.Timers.Timer();
        private MarketItem m_favourite;
        private MarketItem m_secondFavourite;
        private MarketItem m_leastFavourite;
        private BfBot.MarketState m_marketState;
        private bool m_marketActive;
        private bool m_marketInitialised;
        private bool m_inPlay;
        private int m_totalFurlongs;
        private double m_estimatedRaceTime;
        private string m_raceDescription;
        private DateTime m_raceCountdown;
        private DateTime m_raceOffTime;

        public delegate void MarketUpdateDelegate(Market market);
        public event MarketUpdateDelegate OnUpdateMarket;
        public delegate void MarketBackedDelegate(Market market);
        public event MarketBackedDelegate OnMarketBacked;
        public delegate void MarketEqualisedDelegate(Market market);
        public event MarketEqualisedDelegate OnMarketEqualised;
        public delegate void MarketClosed(Market market);
        public event MarketClosed OnMarketClosed;
        public delegate void MarketInPlayAlert(Market market);
        public event MarketInPlayAlert OnMarketInPlay;

        public DateTime SuspendTime
            {
            get { return m_suspendTime; }
            set { m_suspendTime = value; }
            }
        public string RaceDescription()
        {
            return m_raceDescription;
        }

        public bool InPlay
        {
            get { return m_inPlay; }
        }

        public string BetDelay
        {
            get { return m_betDelay; }
        }

        public bool ValidMarket
            {
            get { return m_validMarket; }
            set { m_validMarket = value; }
            }

        public string MarketName
        {
            get { return m_marketName + m_menuPath; }
            set { m_marketName = value; }
        }

        public System.Collections.Hashtable GetMarketItems()
        {
            return m_marketItems;
        }

        public Market(string marketDetails)
            {
                try
                {
                    GetValue(marketDetails);
                }
                catch (Exception ex)
                {
                    BfBot.DumpToFile("Error in Market->Market : " + ex.Message);
                }
            }

        private void GetValue(string marketDetails)
        {
            string[] marketParts = marketDetails.Split('~');

            m_marketActive = false;
            m_marketInitialised = false;
            m_marketState = BfBot.MarketState.Analysing;
            m_marketId = int.Parse(marketParts[0]);
            m_marketName = marketParts[1];
            m_marketType = marketParts[2];
            m_marketStatus = marketParts[3];
            m_eventDate = new DateTime(1970, 1, 1);
            double ms = double.Parse(marketParts[4]);
            m_eventDate = m_eventDate.AddMilliseconds(ms);
            m_menuPath = marketParts[5];
            m_eventHirerarchy = marketParts[6];
            m_betDelay = marketParts[7];
            m_exchangeId = int.Parse(marketParts[8]);
            m_countryCode = marketParts[9];
            m_lastRefresh = new DateTime(long.Parse(marketParts[10]));
            m_numberOfRunners = int.Parse(marketParts[11]);
            m_numberOfWinners = int.Parse(marketParts[12]);
            m_totalAmountMatched = double.Parse(marketParts[13]);
            m_lastItem = marketParts[14];
            m_meetingID = System.Guid.NewGuid().ToString();

            string[] temp;
            temp = m_menuPath.Split('\\');

            m_raceDescription = temp[3] + " - " + m_marketName + " - " + m_eventDate.Hour + ":" + m_eventDate.Minute;

            CalculateRaceLength(m_marketName);

            BFBotDB.BfBotDbWorker.Instance()
                .AddMarket(m_marketId, m_raceDescription, m_eventDate.ToString(), m_marketState.ToString());
            //BFBotDB.BFBotDBWorker.Instance().AddMarket(m_meetingID, m_marketID.ToString(), m_raceDescription, m_eventDate.ToString(), m_marketState.ToString());
        }

        public bool InitialiseMarket()
            {
            try
                {
                return MarketInitialise();
                }
            catch (Exception ex)
                {
                BfBot.DumpToFile("Error in  Market->InitialiseMarket: " + ex.Message);
                m_marketInitialised = false;
                return false;
                }
            }

        private bool MarketInitialise()
        {
            m_bfMarket = MarketTracker.Instance.Exchange.GetMarket(m_exchangeId, m_marketId);

            System.Threading.Thread.Sleep(12000);

            m_suspendTime = m_bfMarket.marketSuspendTime.ToLocalTime();
            TimeSpan timeSpan = m_suspendTime - DateTime.Now;
            if (m_betDelay != "0")
            {
                m_validMarket = false;
                return false;
            }
            if (m_bfMarket.marketStatus == global::BFBot.com.betfair.api6.exchange.MarketStatusEnum.CLOSED ||
                m_bfMarket.marketStatus == global::BFBot.com.betfair.api6.exchange.MarketStatusEnum.SUSPENDED)
            {
                m_marketState = BfBot.MarketState.Closed;
                m_validMarket = false;
                if (OnMarketClosed != null)
                    OnMarketClosed(this);
                return false;
            }
            if (timeSpan.TotalMilliseconds < 600000)
            {
                m_validMarket = false;
                return false;
            }
            PopulateMarketDetails();
            UpdateMarket();
            m_marketInitialised = true;
            m_validMarket = true;
            return true;
        }

        public void MarketUpdateTimer()
        {
            m_timer.Interval = 3000;
        }

        public bool ActivateMarket()
            {
            try
                {
                m_timer.Elapsed += new ElapsedEventHandler(m_timer_Elapsed);
                m_timer.Interval = 3000;
                m_timer.Start();
                m_marketActive = true;
                return true;
                }
            catch (Exception ex)
                {
                    BfBot.DumpToFile("Error in Market->ActivateMarket : " + ex.Message);
                return false;
                }
            }

        public bool MarketInitialised()
            {
            return m_marketInitialised;
            }

        public bool MarketInPlay()
            {
            return m_marketActive;
            }

        public bool IsMarketActive()
            {
            if (m_marketState != BfBot.MarketState.Closed)
                return true;
            
            return false;
            }

        private void m_timer_Elapsed(object sender, ElapsedEventArgs e)
            {//1000 milliseconds in a second
                //m_timer.Interval = 3000;
                if (TimeToOff() > 30)
                    m_timer.Interval = 900000;//0; //600 seconds - 10 minutes
                if (TimeToOff() < 30)
                    m_timer.Interval = 300000; //60 seconds - 1 minute
                if (TimeToOff() < 20)
                    m_timer.Interval = 50000;
                if (TimeToOff() < 19)
                    m_timer.Interval = 25000;
                if (TimeToOff() < 18)
                    m_timer.Interval = 20000;
                if (TimeToOff() < 17)
                    m_timer.Interval = 19000;
                if (TimeToOff() < 16)
                    m_timer.Interval = 18000;
                if (TimeToOff() < 15)
                    m_timer.Interval = 17000;
                if (TimeToOff() < 14)
                    m_timer.Interval = 16000;
                if (TimeToOff() < 13)
                    m_timer.Interval = 15000;
                if (TimeToOff() < 12)
                    m_timer.Interval = 14000;
                if (TimeToOff() < 11)
                    m_timer.Interval = 13000;
                if (TimeToOff() < 10)
                    m_timer.Interval = 12000;
                if (TimeToOff() < 9)
                    m_timer.Interval = 11000;
                if (TimeToOff() < 8)
                    m_timer.Interval = 10000;
                if (TimeToOff() < 7)
                    m_timer.Interval = 9000;
                if (TimeToOff() < 6)
                    m_timer.Interval = 8000;
                if (TimeToOff() < 5)
                    m_timer.Interval = 7000;
                if (TimeToOff() < 4)
                    m_timer.Interval = 6000;
                if (TimeToOff() < 3)
                    m_timer.Interval = 5000;
                if (TimeToOff() < 2)
                    m_timer.Interval = 4000;
                if (TimeToOff() < 1)
                    m_timer.Interval = 3000;
                //if (TimeToOff() < 20)
                //    m_timer.Interval = 50000;
                //if (TimeToOff() < 10)
                //    m_timer.Interval = 20000; //50 seconds
                //if (TimeToOff() < 5)
                //m_timer.Interval = 10000; //10 seconds
                //if (TimeToOff() < 4)
                //    m_timer.Interval = 8000; //7 Seconds
                //if (TimeToOff() < 3)
                //    m_timer.Interval = 5000; // 5 seconds
                //if (TimeToOff() < 2)
                //    m_timer.Interval = 4000; //4 seconds
                //if (TimeToOff() < 1)
                //    m_timer.Interval = 3000; //3 seconds
                //if (m_marketState == BFBot.MarketState.Backed)
                //    m_timer.Interval = 3000;
                //if (m_marketState == BFBot.MarketState.Equalised)
                //    m_timer.Stop();
                //m_timer.Interval = 100000000;
            UpdateMarket();
            }

        public MarketItem GetFavourite
            {
            get { return m_favourite; }
            }

        public MarketItem GetSecondFavourite
        {
            get { return m_secondFavourite; }
        }

        private void CalculateRaceLength(string value)
        {
            try
            {
                //int furlongs;
                string[] cfurlongs;

                string[] temp = value.Split(' ');
                string[] cmiles = temp[0].Split('m');
                if (cmiles.Length > 1)
                {
                    int miles = Convert.ToInt16(cmiles[0]);
                    cfurlongs = cmiles[1].Split('f');
                    if (cfurlongs.Length > 1)
                        m_totalFurlongs = (miles * 8) + Convert.ToInt16(cfurlongs[0]);
                    else
                        m_totalFurlongs = (miles * 8);
                }
                else
                {
                    cfurlongs = temp[0].Split('f');
                    m_totalFurlongs = Convert.ToInt16(cfurlongs[0]);
                }
                m_estimatedRaceTime = m_totalFurlongs * 12;
            }
            catch (Exception ex)
            {
                BfBot.DumpToFile("Error in Market->CalculateRaceLength : " + ex.Message);
            }
        }

        private void PopulateMarketDetails()
            {
                try
                {
                    if (m_bfMarket != null)
                    {
                        foreach (BetfairE.Runner thisRunner in m_bfMarket.runners)
                        {
                            MarketItem marketItem = new MarketItem(thisRunner, m_exchangeId, this);
                            marketItem.OnMarketItemBacked += new MarketItem.MarketItemBacked(marketItem_OnMarketItemBacked);
                            marketItem.OnMarketItemEqualised += new MarketItem.MarketItemEqualised(marketItem_OnMarketItemEqualised);
                            m_marketItems.Add(marketItem.ItemID, marketItem);
                        }
                    }
                }
                catch (Exception ex)
                {
                    BfBot.DumpToFile("Error in Market->PopulateMarketDetails : " + ex.Message);
                }
            }

        void marketItem_OnMarketItemEqualised(MarketItem marketItem)
            {
            m_marketState = BfBot.MarketState.Equalised;
            if (OnMarketEqualised != null)
                OnMarketEqualised(this);
            }

        void marketItem_OnMarketItemBacked(MarketItem marketItem)
            {
            m_marketState = BfBot.MarketState.Backed;
            if (OnMarketBacked != null)
                OnMarketBacked(this);
            }

        //private void CalculateInterests()
        //    {
            
        //    }


        private void CalculateFavourite()
            {
            try
                {
                if (m_marketState == BfBot.MarketState.Backed)
                    return;
                if (m_marketItems.Count == 0)
                    PopulateMarketDetails();
                foreach (MarketItem marketItem in m_marketItems.Values)
                    {
                    if (m_favourite == null)
                        m_favourite = marketItem;
                    else if (m_favourite.Name == marketItem.Name)
                        m_favourite = marketItem;
                    if (marketItem.BackPrice < m_favourite.BackPrice)// & marketItem.BackLayDif <= Math.Abs(m_favourite.BackLayDif))
                        m_favourite = marketItem;
                    }
                    BfBot.DumpToFile("*****Favourite : " + m_favourite.Name + "  : Back Price " + m_favourite.BackPrice);
                    CalculateSecondFavourite();    
                if (m_favourite.BackPrice <= 1.25 & m_betDelay == "1")
                    {
                        if ((m_secondFavourite.BackPrice - m_favourite.BackPrice) >= 3.0)
                            BfBot.DumpToFile("1st - 2nd dif >= 3.0");
                        m_favourite.Back();
                        m_marketState = BfBot.MarketState.Backed;
                    }
                    //CalculateSecondFavourite();
                }
            catch (Exception ex)
                {
                    BfBot.DumpToFile("Error in Market->CalculateFavourite : " + ex.Message);
                }
            }

        private void CalculateSecondFavourite()
        {
            try
            {
                if (m_marketState == BfBot.MarketState.Backed)
                    return;
                if (m_marketItems.Count == 0)
                    PopulateMarketDetails();
                foreach (MarketItem marketItem in m_marketItems.Values)
                {
                    if (marketItem.Name != m_favourite.Name)
                    {
                        if (m_secondFavourite == null)
                            m_secondFavourite = marketItem;
                        if (marketItem.BackPrice < m_secondFavourite.BackPrice)
                            m_secondFavourite = marketItem;
                        else if (marketItem.BackPrice == m_secondFavourite.BackPrice)
                        {
                            if (marketItem.LayPrice < m_secondFavourite.LayPrice)
                                m_secondFavourite = marketItem;
                        }
                    }
                }
                BfBot.DumpToFile("*****Second Favourite : " + m_secondFavourite.Name + "  : Back Price " + m_secondFavourite.BackPrice);                    
                }
            catch (Exception ex)
                {
                    BfBot.DumpToFile("Error in Market->CalculateSecondFavourite : " + ex.Message);
                }
        }

        private void CalculateLeastFavourite()
        {
            try
            {
                if (m_marketItems.Count == 0)
                    PopulateMarketDetails();
                foreach (MarketItem marketItem in m_marketItems.Values)
                {
                    if (m_leastFavourite == null)
                        m_leastFavourite = marketItem;
                    else if (m_leastFavourite.Name == marketItem.Name)
                        m_leastFavourite = marketItem;
                    if (marketItem.BackPrice > m_leastFavourite.BackPrice)
                        m_leastFavourite = marketItem;
                }
            }
            catch (Exception ex)
            {
                BfBot.DumpToFile("Error in Market->CalculateLeastFavourite : " + ex.Message);
            }
        }

        public void CallUpdateMarket()
        {
            UpdateMarket();
        }

        public int MarketID
            {
            get { return m_marketId; }
            set { m_marketId = value; }
            }

        public int ExchangeID
            {
            get { return m_exchangeId; }
            set { m_exchangeId = value; }
            }

        //public string MeetingGUID
        //    {
        //    get { return m_meetingGUID; }
        //    }
        //public List<MarketItem> Runners
        //    {
        //    get { return m_marketItems; }
        //    }

        public double TimeToOff()
            {
            TimeSpan ts = m_suspendTime - DateTime.Now;
            return ts.TotalMinutes;
            }

        public DateTime TimeToOffTime()
        {
            TimeSpan ts = m_suspendTime - DateTime.Now;
            if (ts.Milliseconds > 0)
                return new DateTime(ts.Ticks);
            else
                return DateTime.Now; //m_raceCountdown.Subtract(DateTime.Now);
        }

        private void UpdateMarket()
            {
                try
                {
                    m_timer.Stop();
                    BetfairE.MarketPrices marketPrices = MarketTracker.Instance.Exchange.GetMarketPrices(m_exchangeId, m_marketId);
                    m_betDelay = marketPrices.delay.ToString();
                    BfBot.DumpToFile("=================================================================================");
                    if (marketPrices.marketStatus == global::BFBot.com.betfair.api6.exchange.MarketStatusEnum.SUSPENDED)
                    {
                        m_raceOffTime = DateTime.Now;
                        BfBot.DumpToFile("SUSPENDED," + m_marketName + "," + m_menuPath + "," + TimeToOff() + "," + m_suspendTime);
                        if (m_leastFavourite.LayAmount > 2)
                            BfBot.DumpToFile("Least Favourite Layed," + m_leastFavourite.Name + " - Lay Price = " + m_leastFavourite.LayPrice + " , Lay Amount = " + m_leastFavourite.LayAmount);
                        if (m_favourite != null)
                            BfBot.DumpToFile("Favourite : " + m_favourite.Name + " , Back = " + m_favourite.BackPrice + " , Layed = " + m_favourite.LayPrice);
                        m_raceCountdown = DateTime.Now.AddSeconds(m_estimatedRaceTime);
                        if (OnUpdateMarket != null)
                            OnUpdateMarket(this);
                        m_timer.Start();
                    }
                    else if (marketPrices.marketStatus == global::BFBot.com.betfair.api6.exchange.MarketStatusEnum.CLOSED)
                    {
                        BfBot.DumpToFile("CLOSED," + m_marketName + "," + m_menuPath + "," + TimeToOff() + "," + m_suspendTime);
                        if (m_leastFavourite != null)
                            BfBot.DumpToFile(" Least Favourite End Price," + m_leastFavourite.Name + " , Layed = " + m_leastFavourite.LayPrice + " , Back = " + m_leastFavourite.BackPrice);
                        if (m_favourite != null)
                            BfBot.DumpToFile("Favourite End Price," + m_favourite.Name + " , Layed = " + m_favourite.LayPrice + " , Back = " + m_favourite.BackPrice);
                        m_marketState = BfBot.MarketState.Closed;
                        if (OnMarketClosed != null)
                            OnMarketClosed(this);
                        return;
                    }
                    else if (m_betDelay == "1")
                    {
                        foreach (BetfairE.RunnerPrices runnerprices in marketPrices.runnerPrices)
                        {
                            MarketItem thisMarketItem = m_marketItems[runnerprices.selectionId] as MarketItem;
                            if (thisMarketItem != null)
                            {
                                thisMarketItem.UpdateItem(runnerprices, marketPrices.delay);
                            }
                        }
                        CalculateFavourite();
                        CalculateLeastFavourite();
                        BfBot.DumpToFile("** in play **," + m_marketId + "," + m_marketName + "," + m_menuPath + "," + TimeToOff() + "," + m_suspendTime + "," + m_timer.Interval.ToString());
                        if (m_leastFavourite != null)
                            BfBot.DumpToFile(m_marketId + " Least favourite : " + m_leastFavourite.Name + " - Lay Price = " + m_leastFavourite.LayPrice + " , Lay Amount = " + m_leastFavourite.LayAmount + " ' " + m_leastFavourite.BackPrice);
                        if (m_favourite != null)
                            BfBot.DumpToFile("Favourite : " + m_favourite.Name + " , Back = " + m_favourite.BackPrice + " , Layed = " + m_favourite.LayPrice);
                        BfBot.DumpToFile("Estimated time to race finish : " + m_raceCountdown.Subtract(DateTime.Now));
                        if (OnUpdateMarket != null)
                            OnUpdateMarket(this);
                        if (OnMarketInPlay != null)
                            OnMarketInPlay(this);
                        m_timer.Start();
                    }
                    else
                    {
                        foreach (BetfairE.RunnerPrices runnerprices in marketPrices.runnerPrices)
                        {
                            MarketItem thisMarketItem = m_marketItems[runnerprices.selectionId] as MarketItem;
                            if (thisMarketItem != null)
                            {
                                thisMarketItem.UpdateItem(runnerprices, marketPrices.delay);
                            }
                        }
                        CalculateFavourite();
                        CalculateLeastFavourite();
                        BfBot.DumpToFile(m_marketId + "," + m_marketName + "," + m_menuPath + "," + TimeToOff() + "," + m_suspendTime + "," + m_timer.Interval.ToString());
                        if (m_leastFavourite != null)
                            BfBot.DumpToFile(m_marketId + " Least favourite : " + m_leastFavourite.Name + " - Lay Price = " + m_leastFavourite.LayPrice + " , Lay Amount = " + m_leastFavourite.LayAmount + " ' " + m_leastFavourite.BackPrice);
                        if (m_favourite != null)
                            BfBot.DumpToFile(m_marketId + " Favourite : " + m_favourite.Name + " , Back = " + m_favourite.BackPrice + " , Layed = " + m_favourite.LayPrice);
                        if (OnUpdateMarket != null)
                            OnUpdateMarket(this);
                        m_timer.Start();
                    }
                    BfBot.DumpToFile("=================================================================================");
                }
                catch (Exception ex)
                {
                    BfBot.DumpToFile("Error in Market->UpdateMarket : " + ex.Message);
                    m_timer.Start();
                }
            }
        }
    }
