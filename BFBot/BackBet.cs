using System;
using System.Collections.Generic;
using System.Text;
using BetfairG = BFBot.com.betfair.api6.global;
using BetfairE = BFBot.com.betfair.api6.exchange;

namespace BFBot
    {
    public class BackBet : IBet
        {
        private readonly string m_backBetGuid;
        private double m_stake;
        private double m_odds;
        private BetfairE.PlaceBets placeBet = null;
        private BetfairE.PlaceBetsResult placeResult = null;
        private int m_selectionId;
        private int m_exchangeId;
        private int m_marketId;

        public BackBet(int selectionId, double stake, double odds, int exchangeId, int marketId)
            {
            m_odds = odds;
            m_stake = stake;
            m_backBetGuid = System.Guid.NewGuid().ToString();
            m_selectionId = selectionId;
            m_exchangeId = exchangeId;
            m_marketId = marketId;

            placeBet = new BetfairE.PlaceBets
            {
                asianLineId = 0,
                betCategoryType = BetfairE.BetCategoryTypeEnum.E,
                betPersistenceType = BetfairE.BetPersistenceTypeEnum.NONE,
                betType = BetfairE.BetTypeEnum.B,
                bspLiability = 0,
                marketId = m_marketId,
                price = odds,
                selectionId = selectionId,
                size = stake
            };

            //BetfairE.BFExchangeService service = serviceExchanges[exchangeId];

            //BetfairE.PlaceBetsReq placeBetsReq = new BetfairE.PlaceBetsReq();
            //placeBetsReq.header = headerExchange;
            //placeBetsReq.bets = new List<BetfairE.PlaceBets>(bets).ToArray();

            //BetfairE.PlaceBetsResp placeBetsResp = service.placeBets(placeBetsReq);
            //ResetSessionToken(placeBetsResp.header);

            //if (placeBetsResp.errorCode != BetfairE.PlaceBetsErrorEnum.OK)
            //    {
            //    if (ExchangeThrottleException.WasThrottled(placeBetsResp))
            //        {
            //        throw new ExchangeThrottleException("placeBets", placeBetsResp);
            //        }
            //    else
            //        {
            //        throw new ExchangeException("placeBets", placeBetsResp);
            //        }
            //    }
            }

        public bool PlaceBet()
            {
            //placeResult = MarketTracker.exchange.PlaceBet(m_exchangeID, placeBet);
            //if (!placeResult.success)
            //    {
                //return false;
            //    }
                return true;
            }

        public double EstimatedLayStake(double odds)
            {
            return Profit / (odds * 2);
            }

        public string Id
            {
            get { return m_backBetGuid; }
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
            get { return (m_stake * m_odds); }
            }

        public double Profit
            {
            get { return (m_stake * m_odds) - m_stake; }
            }
        #endregion
        }
    }
