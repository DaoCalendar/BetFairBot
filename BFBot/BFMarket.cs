using System;
using System.Collections.Generic;
using System.Text;

namespace BetFairInterface
    {
    public class BFMarket
        {
        private System.Collections.Generic.List<BFRunnerInfo> m_runners = new List<BFRunnerInfo>();

        private string m_marketID;

        public string MarketID
            {
            get { return m_marketID; }
            set { m_marketID = value; }
            }
        private string m_currency;

        public string Currency
            {
            get { return m_currency; }
            set { m_currency = value; }
            }
        private string m_marketStatus;

        public string MarketStatus
            {
            get { return m_marketStatus; }
            set { m_marketStatus = value; }
            }
        private string m_delay;

        public string Delay
            {
            get { return m_delay; }
            set { m_delay = value; }
            }
        private string m_numberOfWinners;

        public string NumberOfWinners
            {
            get { return m_numberOfWinners; }
            set { m_numberOfWinners = value; }
            }
        private string m_marketInformation;

        public string MarketInformation
            {
            get { return m_marketInformation; }
            set { m_marketInformation = value; }
            }
        private string m_discount;

        public string Discount
            {
            get { return m_discount; }
            set { m_discount = value; }
            }
        private string m_baseRate;

        public string BaseRate
            {
            get { return m_baseRate; }
            set { m_baseRate = value; }
            }
        private string m_refresh;

        public string Refresh
            {
            get { return m_refresh; }
            set { m_refresh = value; }
            }

        public List<BFRunnerInfo> Runners()
            {
            return m_runners;
            }


        public BFMarket(string marketInfo)
            {

            string tempMarket = marketInfo.Replace(@"\:", @"\;");

            string[] result = tempMarket.Split(':');

            string[] marketInfoParts = result[0].Split('~');

            m_marketID = marketInfoParts[0];
            m_currency = marketInfoParts[1];
            m_marketStatus = marketInfoParts[2];
            m_delay = marketInfoParts[3];
            m_numberOfWinners = marketInfoParts[4];
            m_marketInformation = marketInfoParts[5];
            m_discount = marketInfoParts[6];
            m_baseRate = marketInfoParts[7];
            m_refresh = marketInfoParts[8];

            for (int i = 1; i < result.Length - 1; i++)
                {
                BFRunnerInfo runnerInfo = new BFRunnerInfo(result[i]);
                m_runners.Add(runnerInfo);
                }
            }

        }
    }
