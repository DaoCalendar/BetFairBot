using System;
using System.Collections.Generic;
using System.Text;

namespace BFBotDB
    {
    public class DbMarketItem
        {
        public int MarketItemID { get; set; }

        public int MarketID { get; set; }

        public string MarketItemName { get; set; }

        public string MarketItemState { get; set; }

        public DbMarketItem(int marketID)
            {
            MarketID = marketID;

            //System.Data.OleDb.OleDbCommand command = new System.Data.OleDb.OleDbCommand("SELECT * FROM MarketItems WHERE MarketID='" + marketID + "' AND MarketState='Equalised'");
            //command.CommandType = System.Data.CommandType.Text;
            //command.Connection = BFBotDB.BfBotDbWorker.Instance().Connection;
            //System.Data.OleDb.OleDbDataReader dataReader = command.ExecuteReader();
            //while (dataReader.Read())
            //    {
            //    m_marketItemId = dataReader.GetOrdinal("MarketItemID");
            //    m_marketItemName = dataReader.GetString(dataReader.GetOrdinal("MarketItemName"));
            //    m_marketItemState = dataReader.GetString(dataReader.GetOrdinal("MarketItemState"));
            //    }
            //dataReader.Close();
            //command.Dispose();
            }
        }
    }
