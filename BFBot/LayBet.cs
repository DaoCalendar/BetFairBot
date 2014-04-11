using System;
using System.Collections.Generic;
using System.Text;
using BetfairG = BFBot.com.betfair.api6.global;
using BetfairE = BFBot.com.betfair.api6.exchange;

namespace BFBot
    {
    public class LayBet : IBet
        {
        private double m_stake;
        private double m_odds;
        private readonly string m_layBetGuid;
        private BetfairE.PlaceBetsResult m_placeResult = null;
        private int m_selectionId;
        private int m_exchangeId;

        public LayBet(int selectionId, double stake, double odds, int exchangeId, int marketId/*, BetfairE.PlaceBetsResult placeResult*/)
            {
            m_stake = CalculateBestLayStake(stake, odds);  //stake;
            m_odds = odds;
            m_layBetGuid = System.Guid.NewGuid().ToString();
            m_selectionId = selectionId;
            ExchangeId = exchangeId;
            //this.m_placeResult = placeResult;


            BetfairE.PlaceBets placeBet = new BetfairE.PlaceBets();
            placeBet.asianLineId = 0;
            placeBet.betCategoryType = BetfairE.BetCategoryTypeEnum.E;
            placeBet.betPersistenceType = BetfairE.BetPersistenceTypeEnum.NONE;
            placeBet.betType = BetfairE.BetTypeEnum.L;
            placeBet.bspLiability = 0;
            placeBet.marketId = marketId;
            placeBet.price = odds;//(double)Exchange.MINIMUM_PRICE;
            placeBet.selectionId = selectionId;
            placeBet.size = stake;
            }

        private double CalculateBestLayStake(double stake, double odds)
            {
            double backProfit = (stake * (odds + 0.1)) - stake;

            double freeProfit = (stake * odds) - stake;

            double ls = (backProfit - freeProfit) / odds;

            double newStake = (int)stake + (int)ls;

            return newStake;
            }

        public bool PlaceBet()
            {
            //placeResult = MarketTracker.exchange.PlaceBet(m_exchangeID, placeBet);
            //if (!placeResult.success)
            //    {
                return false;
            //    }
            //return true;
            }

        public string Id
            {
            get { return m_layBetGuid; }
            }

        #region IBet Members

        public double Stake
            {
            get { return m_stake; }
            set { m_stake = value; }
            }

        public double Odds
            {
            get { return m_odds; }
            set { m_odds = value; }
            }

        public double Returns
            {
            get { return (m_stake * m_odds) + m_stake; }
            }

        public double Profit
            {
            get { return (m_stake * m_odds) - m_stake; }
            }
        #endregion

        public double Liability
            {
            get { return (m_stake * m_odds) - m_stake; }
            }

        public int ExchangeId
        {
            get { return m_exchangeId; }
            set { m_exchangeId = value; }
        }
        }
    }
