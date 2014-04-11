using System;
using System.Collections.Generic;
using System.Text;

namespace BFBotDB
    {
    public class DBClosedMarket
        {
        private string m_marketName;
        private string m_marketDate;
        private string m_marketTime;
        private string m_marketItemName;
        private string m_marketItemBackStake;
        private string m_marketItemBackOdds;
        //private string m_marketItemBackReturns;
        private string m_marketItemLayStake;
        private string m_marketItemLayOdds;
        //private string m_marketItemLayReturns;
        //private string m_winLoseProfit;

        private List<DBTransaction> m_transactions;

        public DBClosedMarket(string marketGUID)
            {
            //m_transactions = new List<DBTransaction>();

            //System.Data.OleDb.OleDbCommand command = new System.Data.OleDb.OleDbCommand("SELECT * FROM Markets WHERE MarketID='" + marketGUID + "' AND MarketState='Closed'");
            //command.CommandType = System.Data.CommandType.Text;
            //command.Connection = BFBotDB.BfBotDbWorker.Instance().Connection;
            //System.Data.OleDb.OleDbDataReader dataReader = command.ExecuteReader();
            //while (dataReader.Read())
            //    {
            //    m_marketName = dataReader.GetString(dataReader.GetOrdinal("MarketName"));
            //    string[] dateTime = dataReader.GetString(dataReader.GetOrdinal("MarketCloseTime")).Split(' ');
            //    m_marketDate = dateTime[0];
            //    m_marketTime = dateTime[1];
            //    }
            //dataReader.Close();
            //command.Dispose();
            //MarketDetails(marketGUID);
            }

        public DBClosedMarket(string name, string date, string time)
            {
            //string marketGUID = "";
            //string marketCloseTime = date + " " + time;

            //m_transactions = new List<DBTransaction>();

            //System.Data.OleDb.OleDbCommand command = new System.Data.OleDb.OleDbCommand("SELECT * FROM Markets WHERE MarketName='" + name + "' AND MarketCloseTime='" + marketCloseTime + "'");
            //command.CommandType = System.Data.CommandType.Text;
            //command.Connection = BFBotDB.BfBotDbWorker.Instance().Connection;
            //System.Data.OleDb.OleDbDataReader dataReader = command.ExecuteReader();
            //while (dataReader.Read())
            //    {
            //    marketGUID = dataReader.GetString(dataReader.GetOrdinal("MarketID"));
            //    m_marketName = name;
            //    m_marketDate = date;
            //    m_marketTime = time;
            //    }
            //dataReader.Close();
            //command.Dispose();
            //MarketDetails(marketGUID);
            }

        public string WinLoseProfit
            {
            get
                {
                double value = double.Parse(m_marketItemLayStake) - double.Parse(m_marketItemBackStake);
                return value.ToString("0.00");
                }
            }

        public string Name
            {
            get { return m_marketName; }
            }

        public string Date
            {
            get { return m_marketDate; }
            }

        public string Time
            {
            get { return m_marketTime; }
            }

        public string MarketItemName
            {
            get { return m_marketItemName; }
            }

        public string MarketItemBackStake
            {
            get { return m_marketItemBackStake; }
            }

        public string MarketItemBackOdds
            {
            get { return m_marketItemBackOdds; }
            }

        public string marketItemLayStake
            {
            get { return m_marketItemLayStake; }
            }

        public string MarketItemLayOdds
            {
            get { return m_marketItemLayOdds; }
            }

        public string MarketItemBackReturns
            {
            get
                {
                double backReturns = (double.Parse(m_marketItemBackStake) * double.Parse(m_marketItemBackOdds)) - double.Parse(m_marketItemBackStake);
                return backReturns.ToString("0.00");
                }
            }

        public string MarketItemLayReturns
            {
            get
                {
                double layReturns = (double.Parse(m_marketItemLayStake) * double.Parse(m_marketItemLayOdds)) - double.Parse(m_marketItemLayStake);
                return layReturns.ToString("0.00");
                }
            }

        public List<DBTransaction> Transactions
            {
            get { return m_transactions; }
            }

        private void MarketDetails(int marketID)
            {
            //int marketItemID = "";

            //System.Data.OleDb.OleDbCommand command = new System.Data.OleDb.OleDbCommand("SELECT * FROM MarketItems WHERE MarketID='" + marketID + "' AND MarketItemState='Equalised'");
            //command.CommandType = System.Data.CommandType.Text;
            //command.Connection = BFBotDB.BfBotDbWorker.Instance().Connection;
            //System.Data.OleDb.OleDbDataReader dataReader = command.ExecuteReader();
            //while (dataReader.Read())
            //    {
            //    marketItemID = dataReader.GetString(dataReader.GetOrdinal("MarketItemID"));
            //    m_marketItemName = dataReader.GetString(dataReader.GetOrdinal("MarketItemName"));
            //    }
            //dataReader.Close();
            //command.Dispose();
            //MarketDetailsBack(marketItemID);
            //MarketDetailsLay(marketItemID);
            //MarketDetailsTransactions(marketItemID);
            }

        private void MarketDetailsBack(string id)
            {
            //System.Data.OleDb.OleDbCommand command = new System.Data.OleDb.OleDbCommand("SELECT * FROM Backed WHERE MarketItemID='" + id + "'");
            //command.CommandType = System.Data.CommandType.Text;
            //command.Connection = BFBotDB.BfBotDbWorker.Instance().Connection;
            //System.Data.OleDb.OleDbDataReader dataReader = command.ExecuteReader();
            //while (dataReader.Read())
            //    {
            //    m_marketItemBackStake = dataReader.GetDouble(dataReader.GetOrdinal("Stake")).ToString("0.00");
            //    m_marketItemBackOdds = dataReader.GetDouble(dataReader.GetOrdinal("Odds")).ToString("0.00");
            //    }
            //dataReader.Close();
            //command.Dispose();
            }

        private void MarketDetailsLay(string id)
            {
            //System.Data.OleDb.OleDbCommand command = new System.Data.OleDb.OleDbCommand("SELECT * FROM Layed WHERE MarketItemID='" + id + "'");
            //command.CommandType = System.Data.CommandType.Text;
            //command.Connection = BFBotDB.BfBotDbWorker.Instance().Connection;
            //System.Data.OleDb.OleDbDataReader dataReader = command.ExecuteReader();
            //while (dataReader.Read())
            //    {
            //    m_marketItemLayStake = dataReader.GetDouble(dataReader.GetOrdinal("Stake")).ToString("0.00");
            //    m_marketItemLayOdds = dataReader.GetDouble(dataReader.GetOrdinal("Odds")).ToString("0.00");
            //    }
            //dataReader.Close();
            //command.Dispose();
            }

        private void MarketDetailsTransactions(string id)
            {
            
            //System.Data.OleDb.OleDbCommand command = new System.Data.OleDb.OleDbCommand("SELECT TransactionID FROM Transactions WHERE MarketItemID='" + id + "' ORDER BY TransactionTimeStamp");
            //command.CommandType = System.Data.CommandType.Text;
            //command.Connection = BFBotDB.BfBotDbWorker.Instance().Connection;
            //System.Data.OleDb.OleDbDataReader dataReader = command.ExecuteReader();
            //while (dataReader.Read())
            //    {
            //    m_transactions.Add(new DBTransaction(dataReader.GetString(dataReader.GetOrdinal("TransactionID"))));
            //    }
            //dataReader.Close();
            //command.Dispose();
            }
        }
    }
