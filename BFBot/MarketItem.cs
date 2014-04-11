using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using System.Threading;
using BetfairG = BFBot.com.betfair.api6.global;
using BetfairE = BFBot.com.betfair.api6.exchange;

namespace BFBot
    {
    public class MarketItem
        {
        private string m_name;
        private int m_itemID;
        private MarketItemState m_marketItemState;
        private double m_backedOdds;
        private double m_layOdds;
        public double m_layAmount;
        public double m_backAmount;
        private BackBet m_backBet;
        private LayBet m_layBet;
        private int m_exchangeID;
        private int m_marketID;
        private Market m_market;
        private MarketItemMovement m_marketItemMovement;
        
        public enum MarketItemState
            {
            Unknown,
            Backed,
            Equalised
            }

        public enum MarketSentiment
            {
            VeryGood,
            Good,
            Poor,
            VeryPoor
            }

        public delegate void MarketItemUpdateDelegate();
        public event MarketItemUpdateDelegate OnMarketItemUpdate;
        public delegate void MarketItemBacked(MarketItem marketItem);
        public event MarketItemBacked OnMarketItemBacked;
        public delegate void MarketItemEqualised(MarketItem marketItem);
        public event MarketItemEqualised OnMarketItemEqualised;
        public delegate void MarketItemLayed();
        public event MarketItemLayed OnMarketItemLayed;

        public MarketItem(BetfairE.Runner runner, int exchangeID, Market market)
            {
                try
                {
                    m_name = runner.name;
                    m_itemID = runner.selectionId;
                    m_exchangeID = exchangeID;
                    m_marketID = market.MarketID;
                    m_market = market;
                    m_marketItemMovement = new MarketItemMovement();
                    m_marketItemState = MarketItemState.Unknown;

                    BFBotDB.BfBotDbWorker.Instance().AddMarketItem(m_marketID, m_name, m_marketItemState.ToString());
                    //BFBotDB.BFBotDBWorker.Instance().AddMarketItem(m_itemID.ToString(), m_marketID.ToString(), m_name, m_marketItemState.ToString());
                }
                catch (Exception ex)
                {
                    BfBot.DumpToFile("MarketItem->MarketItem : " + ex.Message);
                }
            }

        public MarketItemState GetMarketItemState
        {
            get { return m_marketItemState; }
        }

        public double LayAmount
        {
            get { return m_layAmount; }
        }

        public int ItemID
            {
            get { return m_itemID; }
            set { m_itemID = value; }
            }

        public string Name
            {
            get { return m_name; }
            set { m_name = value; }
            }

        public void UpdateItem(BetfairE.RunnerPrices runnerprices, int inPlay)
            {
                double backPrice;
                double backAmount;
                double layPrice;
                double layAmount;
                double[] values;

                try
                {
                    m_marketItemMovement.AddPrices(runnerprices.bestPricesToBack, runnerprices.bestPricesToLay);
                    if (runnerprices.bestPricesToLay.Length > 0)
                        layAmount = runnerprices.bestPricesToLay[0].amountAvailable;
                    else
                        layAmount = 0.0;
                    if (runnerprices.bestPricesToLay.Length > 0)
                        layPrice = runnerprices.bestPricesToLay[0].price;
                    else
                        layPrice = 0.0;
                    if (runnerprices.bestPricesToBack.Length > 0)
                        backAmount = runnerprices.bestPricesToBack[0].amountAvailable;
                    else
                        backAmount = 0.0;
                    if (runnerprices.bestPricesToBack.Length > 0)
                        backPrice = runnerprices.bestPricesToBack[0].price;
                    else
                        backPrice = 0.0;
                    m_layAmount = layAmount;
                    m_backAmount = backAmount;
                    //BFBot.DumpToFile("[" + m_marketID + "],[" + m_itemID.ToString() + "] " + m_name.PadRight(20) + " : B[" + runnerprices.bestPricesToBack[0].price + " £" + runnerprices.bestPricesToBack[0].amountAvailable + "] - L[" + runnerprices.bestPricesToLay[0].price + " £" + runnerprices.bestPricesToLay[0].amountAvailable + "]");
                    BfBot.DumpToFile("[" + m_marketID + "],[" + m_itemID.ToString() + "], " + m_name.PadRight(20) + " : B[" + backPrice + ", £" + backAmount + "] : L[" + layPrice + ", £" + layAmount + "]");
                    //BFBot.DumpDetails(m_marketID + "," + m_itemID.ToString() + "," + m_name + "," + backPrice + "," + backAmount + "," + layPrice + "," + layAmount + "," + m_marketItemMovement.Report());
                    values = m_marketItemMovement.Report();
                    //BFBotDB.BfBotDbWorker.Instance().AddMarketItemMovement(m_marketID, m_itemID, m_name, backPrice, backAmount, layPrice, layAmount, inPlay, values);
                    //BFBotDB.BFBotDBWorker.Instance().AddMarketItemMovement(m_marketID.ToString(), m_itemID.ToString(), m_name, backPrice, backAmount, layPrice, layAmount, inPlay, values);
                    if (OnMarketItemUpdate != null)
                        OnMarketItemUpdate();
                    BFBotDB.BfBotDbWorker.Instance().AddMarketMovement(m_marketID, m_itemID, backPrice, backAmount, layPrice, layAmount, inPlay);
                    //BFBotDB.BFBotDBWorker.Instance().AddMarketMovement(m_marketID, m_itemID, backPrice, backAmount, layPrice, layAmount, inPlay);
                    //BFBot.DumpDetails(m_name + " - " + m_itemID + m_marketItemMovement.Report());
                }
                catch (Exception ex)
                {
                    BfBot.DumpToFile("Error in MarketItem->UpdateItem : " + ex.Message);
                    BfBot.DumpToFile(" : " + ex.Message);
                }
            }

        public BetfairE.Price[] BackPrices()
        {
            return m_marketItemMovement.BackPrices();
        }

        public BetfairE.Price[] LayPrices()
        {
            return m_marketItemMovement.LayPrices();
        }

        public double BackLayDif
            {
            get { return LayPrice - BackPrice; }
            }

        public double LayPrice
            {
            get { return m_marketItemMovement.LayPrice; }
            }

        public double BackPrice
            {
            get { return m_marketItemMovement.BackPrice; }
            }

        public bool Back()
            {
                try
                {
                    double tempBet = BfBot.Balance / 8;
                    //m_backBet = new BackBet(m_itemID, BFBot.GetAccount.AllowedStake, m_backPrice[0].price, m_exchangeID, m_marketID);
                    //m_backBet = new BackBet(m_itemID, tempBet, m_marketItemMovement.BackPrice, m_exchangeID, m_marketID);
                    m_backBet = new BackBet(m_itemID, tempBet, 1.01, m_exchangeID, m_marketID);
                    m_backedOdds = m_marketItemMovement.BackPrice;
                    if (m_backBet.PlaceBet())
                    {
                        m_marketItemState = MarketItemState.Backed;
                        //BFBotDB.BFBotDBWorker.Instance().AddBackBet(System.Guid.NewGuid().ToString(), m_itemID.ToString(), (decimal)m_backBet.Stake, (decimal)m_backBet.Odds, (decimal)m_backBet.Profit);
                        BfBot.Balance += m_backBet.Profit;
                        BfBot.DumpToFile("******************** Backed -> " + m_name + " - " + tempBet + " - Back Price : " + m_marketItemMovement.BackPrice + " Available = " + m_backAmount + " Balance = £ " + BfBot.Balance);
                        //BFBotDB.BFBotDBWorker.Instance().AddBackBet(System.Guid.NewGuid().ToString(), m_itemID.ToString(), (decimal)tempBet, (decimal)m_backBet.Odds);
                        //BFBot.SendMailMessage("******************** Backed -> ", m_name + " - " + tempBet + " - " + m_marketItemMovement.BackPrice + " Available = " + m_backAmount + " Balance = £ " + BFBot.Balance);
                        if (OnMarketItemBacked != null)
                            OnMarketItemBacked(this);
                        m_marketItemState = MarketItemState.Backed;
                    }
                }
                catch (Exception ex)
                {
                    BfBot.DumpToFile("Error in MarketItem->Back  : " + ex.Message);
                }
                return true;
            }

        public void DumpMovement()
            {
            m_marketItemMovement.DumpBackMovement();
            m_marketItemMovement.DumpLayMovement();
            }

        public double BackWeight()
            {
            return m_marketItemMovement.BackWeight;
            }

        public double LayWeight()
            {
            return m_marketItemMovement.LayWeight;
            }

        public bool LayBet()
        {
            try
            {
                if (m_marketItemMovement.LayPrices().Length > 0)
                {
                    double amount;
                    if (m_marketItemMovement.LayPrices()[0].amountAvailable > 2)
                    {
                        amount = m_marketItemMovement.LayPrices()[0].amountAvailable;
                    }
                    else
                    {
                        amount = 2.0;
                    }
                    //public LayBet(int selectionID, double stake, double odds, int exchangeId, int marketId, BetfairE.PlaceBetsResult placeResult)
                    LayBet free = new LayBet(m_itemID, amount, m_marketItemMovement.LayPrice, m_exchangeID, m_marketID);
                    //free.PlaceBet();
                    BfBot.DumpToFile("******************** Layed -> " + m_name + " - " + free.Stake + " - " + free.Odds);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                BfBot.DumpToFile("Error in MarketItem.LayBet : " + ex.Message);
                return false;
            }

        }

        public bool Equalise()
            {
            try
                {
                if (m_marketItemMovement.LayPrice < m_backBet.Odds)
                    {
                    m_layOdds = m_marketItemMovement.LayPrice;
                    LayBet free = new LayBet(m_itemID, m_backBet.Stake, m_marketItemMovement.LayPrice, m_exchangeID, m_marketID);
                    //free.PlaceBet();
                    m_layBet = free;

                    ////Used to equalise the bet.
                    //double ls = (m_backBet.Profit - free.Profit) / m_layPrice[0].price;
                    //// cast to int(not sure on BF policy on pence?
                    //LayBet equaliser = new LayBet(m_itemID, m_backBet.Stake, m_layPrice[0].price, m_exchangeID, m_marketID);
                    //m_layBet = equaliser;
                    //m_layBet.PlaceBet();
                    //m_state = BFBot.MarketItemState.Equalised;
                    BfBot.DumpToFile("******************** Layed -> " + m_name + " - " + m_layBet.Stake + " - " + m_layBet.Odds);
                    //BFBot.AddMessage("******************** Layed -> " + m_name + " - " + m_layBet.Stake + " - " + m_layBet.Odds);
                    //BFBot.SendMailMessage("******************** Layed -> ", m_name + " - " + m_layBet.Stake + " - " + m_layBet.Odds);
                    if (OnMarketItemEqualised != null)
                        OnMarketItemEqualised(this);
                    m_marketItemState = MarketItemState.Equalised;
                    return true;
                    }
                return false;
                }
            catch (Exception ex)
                {
                    BfBot.DumpToFile("Error in MarketItem->Equalise : " + ex.Message);
                    return false;
                }
            }

        public bool Sentiment()
            {
            if (m_marketItemMovement.BackMovement(5) > 0 & m_marketItemMovement.LayMovement(5) < 0)
                {
                if ((m_marketItemMovement.LayPrice - m_marketItemMovement.BackPrice) <= 1)
                    return true;
                return false;
                }
            else
                return false;
            }
        }
    }
