using System;
using System.Collections.Generic;
using System.Text;

namespace BFBotDB
    {
    public class DbMarket
        {
        public int MarketId { get; set; }

        public int BfMarketId { get; set; }

        public string MarketName { get; set; }

        public string MarketCloseTime { get; set; }

        public string MarketState { get; set; }

        public DbMarket(int marketId)    //, string bfMarketID, string marketName, string marketCloseTime, string marketState)
            {
            MarketId = marketId;

            //System.Data.OleDb.OleDbCommand command = new System.Data.OleDb.OleDbCommand("SELECT * FROM Markets WHERE MarketID='" + marketID + "'");
            //command.CommandType = System.Data.CommandType.Text;
            //command.Connection = BFBotDB.BfBotDbWorker.Instance().Connection;
            //System.Data.OleDb.OleDbDataReader dataReader = command.ExecuteReader();
            //while (dataReader.Read())
            //    {
            //    m_bfMarketId = dataReader.GetOrdinal("BFMarketID");
            //    m_marketName = dataReader.GetString(dataReader.GetOrdinal("MarketName"));
            //    m_marketCloseTime = dataReader.GetString(dataReader.GetOrdinal("MarketCloseTime"));
            //    m_marketState = dataReader.GetString(dataReader.GetOrdinal("MarketState"));
            //    }
            //dataReader.Close();
            //command.Dispose();
            }

        }
    }
