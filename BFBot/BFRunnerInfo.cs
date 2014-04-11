using System;
using System.Collections.Generic;
using System.Text;

namespace BetFairInterface
    {
    class BFRunnerInfo
        {
        private string m_runnerID;
        private string m_orderIndex;
        private string m_totalAmountmatched;
        private string m_lastPriceMatched;
        private string m_handicap;
        private string m_reductionFactor;
        private string m_vacant;

        public string RunnerID
            {
            get { return m_runnerID; }
            set { m_runnerID = value; }
            }
        
        public string OrderIndex
            {
            get { return m_orderIndex; }
            set { m_orderIndex = value; }
            }
        
        public string TotalAmountmatched
            {
            get { return m_totalAmountmatched; }
            set { m_totalAmountmatched = value; }
            }
        
        public string LastPriceMatched
            {
            get { return m_lastPriceMatched; }
            set { m_lastPriceMatched = value; }
            }
        
        public string Handicap
            {
            get { return m_handicap; }
            set { m_handicap = value; }
            }

        public string ReductionFactor
            {
            get { return m_reductionFactor; }
            set { m_reductionFactor = value; }
            }
        
        public string Vacant
            {
            get { return m_vacant; }
            set { m_vacant = value; }
            }
        
        private BFBackPrices m_backPrices;
        private BFLayPrices m_layPrices;

        public BFRunnerInfo(string runnerInfo)
            {
            string[] runnerInfoParts = runnerInfo.Split('|');
            string[] runner = runnerInfoParts[0].Split('~');

            RunnerID = runner[0];
            OrderIndex = runner[1];
            TotalAmountmatched = runner[2];
            LastPriceMatched = runner[3];
            Handicap = runner[4];
            ReductionFactor = runner[5];
            Vacant = runner[6];

            m_backPrices = new BFBackPrices(runnerInfoParts[1]);
            m_layPrices = new BFLayPrices(runnerInfoParts[2]);
            }
        }
    }
