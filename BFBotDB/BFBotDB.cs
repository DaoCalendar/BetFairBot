using System;
using System.Data.SqlClient;

namespace BFBotDB
    {
    public class BfBotDbWorker : IDisposable
    {
        private static System.Data.SqlClient.SqlConnection s_sqlConnection;
        private static BfBotDbWorker s_instance;

        private string ConnectionString
        {
            get
            {
                return @"Data Source=LAPTO-SENOJ\ZAGATO2008;Initial Catalog=BFBOT;Integrated Security=true";
            }
        }

        private BfBotDbWorker()
        {
            s_sqlConnection = new SqlConnection(ConnectionString);
            OpenConnection();   
        }

        public void OpenConnection()
        {
            s_sqlConnection.Open();    
        }

        public void CloseConnection()
        {
            s_sqlConnection.Close();
        }

        public SqlConnection GetSqlConnection
        {
            get { return s_sqlConnection; }
        }

        public static BfBotDbWorker Instance()
        {
            return s_instance ?? (s_instance = new BfBotDbWorker());
        }

        public SqlConnection Connection
            {
            get { return s_sqlConnection; }
            }


        
        public void AddMarket(/*int meetingID,*/ int bfMarketId, string marketName, string marketCloseTime, string marketState)
            {
            string queryString = string.Format(
                "INSERT INTO Markets(BFMarketID,MarketName,MarketCloseTime,MarketState) VALUES('{0}','{1}','{2}','{3}')", 
                bfMarketId, 
                marketName, 
                marketCloseTime, 
                marketState
                );

            SqlCommand cmd = new SqlCommand(queryString, s_sqlConnection);
            cmd.ExecuteNonQuery();
            }

        public void UpdateMarket(int meetingId, string marketState)
            {
                using (SqlCommand command = new SqlCommand(string.Format(
                    "UPDATE Markets set MarketState='{0}' WHERE MarketID='{1}'",
                    marketState, 
                    meetingId))
                    )
                {
                    command.ExecuteNonQuery();
                }
            }

        public void AddMarketItem(int marketId, string marketItemName, string marketItemState)
            {
            string queryString = string.Format(
                "INSERT INTO MarketItems(MarketID,MarketItemName,MarketItemState) VALUES('{0}','{1}','{2}')", 
                marketId, 
                marketItemName, 
                marketItemState
                );

            SqlCommand command = new SqlCommand(queryString, s_sqlConnection);
            command.ExecuteNonQuery();
            }

        public void UpdateMarketItem(string marketItemState, int marketItemID)
            {
            //System.Data.OleDb.OleDbCommand command = 
            //    new System.Data.OleDb.OleDbCommand(
            //    "UPDATE MarketItems set MarketItemState='" + marketItemState + "' WHERE MarketItemID='" + marketItemID + "'");
            //command.CommandType = System.Data.CommandType.Text;
            //command.Connection = botDataConnection;
            //command.ExecuteNonQuery();
            //command.Dispose();
            }

        public void AddBackBet(int bPackBetID, int marketItemID, decimal stake, decimal odds, decimal profit)
            {
            //System.Data.OleDb.OleDbCommand command =
            //    new System.Data.OleDb.OleDbCommand(
            //    "INSERT INTO Backed(BackBetID,MarketItemID,Stake,Odds,Profit) VALUES('"
            //    + backBetID + "','" + marketItemID + "','" + stake + "','" + odds + "'," + profit +")");
            //command.CommandType = System.Data.CommandType.Text;
            //command.Connection = botDataConnection;
            //command.ExecuteNonQuery();
            //command.Dispose();
            }

        public void AddLayBet(int layBetID, int marketItemID, decimal stake, decimal odds)
            {
            //System.Data.OleDb.OleDbCommand command =
            //    new System.Data.OleDb.OleDbCommand(
            //    "INSERT INTO Layed(LayBetID,MarketItemID,Stake,Odds) VALUES('"
            //    + layBetID + "','" + marketItemID + "','" + stake + "','" + odds + "')");
            //command.CommandType = System.Data.CommandType.Text;
            //command.Connection = botDataConnection;
            //command.ExecuteNonQuery();
            //command.Dispose();
            }

        public void Withdrawal(double amount, double balance, string description, string action)
            {
            //System.Data.OleDb.OleDbCommand command =
            //    new System.Data.OleDb.OleDbCommand(
            //    "INSERT INTO Transactions(TransactionID,TransactionTimeStamp,MarketItemID,TransactionAmount,Balance,DepositWithdrawal,TransactionAction) VALUES('"
            //    + System.Guid.NewGuid().ToString() + "','" + DateTime.Now.Ticks.ToString() + "','" + description + "'," + amount + "," + balance + ",'" + "Withdrawal" + "','" + action + "')");
            //command.CommandType = System.Data.CommandType.Text;
            //command.Connection = botDataConnection;
            //command.ExecuteNonQuery();
            //command.Dispose();
            }

        public void Deposit(double amount, double balance, string description, string action)
            {
            //System.Data.OleDb.OleDbCommand command =
            //    new System.Data.OleDb.OleDbCommand(
            //    "INSERT INTO Transactions(TransactionID,TransactionTimeStamp,MarketItemID,TransactionAmount,Balance,DepositWithdrawal,TransactionAction) VALUES('"
            //    + System.Guid.NewGuid().ToString() + "','" + DateTime.Now.Ticks.ToString() + "','" + description + "'," + amount + "," + balance + ",'" + "Deposit" + "','" + action + "')");
            //command.CommandType = System.Data.CommandType.Text;
            //command.Connection = botDataConnection;
            //command.ExecuteNonQuery();
            //command.Dispose();
            }

        public void AddMarketItemMovement(int marketId, int marketItemId, string name, double backPrice, double backAmount, double layPrice, double layAmount, int inPlay, double[] values)
        {
            string queryString = string.Format("INSERT INTO MarketMovement(" +
                                               "MarketID," +
                                               "MarketItemID," +
                                               "MarketItemName," +
                                               "MovementTicks," +
                                               "MovementDateTime," +
                                               "BackPrice," +
                                               "BackAmount," +
                                               "LayPrice," +
                                               "LayAmount," +
                                               "InPlay," +
                                               "BackHigh," +
                                               "BackAmountAvailable," +
                                               "BackLow," +
                                               "LayHigh," +
                                               "LayAmountAvailable," +
                                               "LayLow," +
                                               "BackWeight," +
                                               "LayWeight," +
                                               "LastBackPrice," +
                                               "LastLayPrice," +
                                               "BackHighLowWeight," +
                                               "LayHighLowWeight," +
                                               "BackCurrentHighDif," +
                                               "BackCurrentLowDif," +
                                               "LayCurrentHighDif," +
                                               "LayCurrentLowDif," +
                                               "BackLayDif," +
                                               "Last2BackMovements," +
                                               "Last2LayMovements)" +
                                               " VALUES('{0}','{1}','{2}','{3}','{4}','{5}',{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22},{23},{24},{25},{26},{27},{28})", 
                                               marketId, 
                                               marketItemId, 
                                               name, 
                                               System.DateTime.Now.Ticks.ToString(), 
                                               System.DateTime.Now.TimeOfDay.ToString(), 
                                               backPrice, 
                                               backAmount, 
                                               layPrice, 
                                               layAmount, 
                                               inPlay, 
                                               values[0], 
                                               values[1], 
                                               values[2], 
                                               values[3], 
                                               values[4], 
                                               values[5], 
                                               values[6], 
                                               values[7], 
                                               values[8], 
                                               values[9], 
                                               values[10],
                                               values[11], 
                                               values[12], 
                                               values[13], 
                                               values[14], 
                                               values[15], 
                                               values[16], 
                                               values[17], 
                                               values[18]);
            SqlCommand command = 
                new SqlCommand(queryString, s_sqlConnection);
            command.ExecuteNonQuery();
            command.Dispose();
        }

        public string AddMarketMovement(int marketId, int marketItemId, double backPrice, double backAmount, double layPrice, double layAmount, int inPlay)
            {
  string queryString = string.Format("INSERT INTO MarketMovements(" + 
                "MarketID," + 
                "MarketItemID," + 
                "UpdateTimeStamp," + 
                "BackPrice," + 
                "BackAmount," + 
                "LayPrice," + 
                "LayAmount," + 
                "InPlay) " + 
                "VALUES('{0}','{1}','{2}','{3}',{4},{5},{6},{7})", 
                marketId, 
                marketItemId, 
                //System.DateTime.Now.Ticks.ToString(), 
                System.DateTime.Now.TimeOfDay.ToString(), 
                backPrice, 
                backAmount, 
                layPrice, 
                layAmount, 
                inPlay);
                SqlCommand command =
                    new SqlCommand(queryString, s_sqlConnection);
                command.ExecuteNonQuery();
                return "";

            }

        public void AddClosedMarketMovements(decimal[] backMovements, decimal[] layMovements, int marketItemID)
            {
            //foreach (decimal value in backMovements)
            //    {
            //    string guid = System.Guid.NewGuid().ToString();
            //    System.Data.OleDb.OleDbCommand command =
            //        new System.Data.OleDb.OleDbCommand(
            //        "INSERT INTO MarketItemMovement(MarketMovementID,MarketItemID,MarketMovementValue,Back) VALUES('"
            //        + guid + "','" + marketItemID + "'," + value + "," + true + ")");
            //    command.CommandType = System.Data.CommandType.Text;
            //    command.Connection = botDataConnection;
            //    command.ExecuteNonQuery();
            //    command.Dispose();
            //    }
            //foreach (decimal value in layMovements)
            //    {
            //    string guid = System.Guid.NewGuid().ToString();
            //    System.Data.OleDb.OleDbCommand command =
            //        new System.Data.OleDb.OleDbCommand(
            //        "INSERT INTO MarketItemMovement(MarketMovementID,MarketItemID,MarketMovementValue,Back) VALUES('"
            //        + guid + "','" + marketItemID + "'," + value + "," + false + ")");
            //    command.CommandType = System.Data.CommandType.Text;
            //    command.Connection = botDataConnection;
            //    command.ExecuteNonQuery();
            //    command.Dispose();
            //    }
            }

        public void CloseMarket(int marketID)
            {
            //System.Data.OleDb.OleDbCommand command =
            //    new System.Data.OleDb.OleDbCommand(
            //    "DELETE * FROM MarketItems WHERE MarketID='" + marketID + "' AND MarketItemState='Closed'");
            //command.CommandType = System.Data.CommandType.Text;
            //command.Connection = botDataConnection;
            //command.ExecuteNonQuery();
            //command.Dispose();
            }

        //public List<string> GetClosedMarkets()
        //    {
        //    List<string> closedMarkets = new List<string>();

        //    System.Data.OleDb.OleDbCommand command = new System.Data.OleDb.OleDbCommand("SELECT * FROM Markets WHERE MarketState='Closed'");
        //    command.CommandType = System.Data.CommandType.Text;
        //    command.Connection = botDataConnection;
        //    System.Data.OleDb.OleDbDataReader dataReader = command.ExecuteReader();
        //    while (dataReader.Read())
        //        {
        //        closedMarkets.Add(dataReader.GetString(dataReader.GetOrdinal("MarketName")) + " " + dataReader.GetString(dataReader.GetOrdinal("MarketCloseTime")));
        //        }
        //    dataReader.Close();
        //    command.Dispose();
        //    return closedMarkets;
        //    }

        //public List<DBClosedMarket> GetClosedMarkets()
        //    {
        //    List<DBClosedMarket> closedMarkets = new List<DBClosedMarket>();

        //    System.Data.OleDb.OleDbCommand command = new System.Data.OleDb.OleDbCommand("SELECT MarketID FROM Markets WHERE MarketState='Closed'");
        //    command.CommandType = System.Data.CommandType.Text;
        //    command.Connection = botDataConnection;
        //    System.Data.OleDb.OleDbDataReader dataReader = command.ExecuteReader();
        //    while (dataReader != null && dataReader.Read())
        //        {
        //        DBClosedMarket closedMarket = new DBClosedMarket(dataReader.GetString(dataReader.GetOrdinal("MarketID")));
        //        closedMarkets.Add(closedMarket);
        //        dataReader.Close();
        //        }
        //    command.Dispose();
        //    return closedMarkets;
        //    }

        public DbMarket GetMarket(int marketID)
            {
            DbMarket dbMarket = new DbMarket(marketID);
            return dbMarket;
            }

        //public List<DBTransaction> GetTransactions()
        //    {
        //    List<DBTransaction> transactions = new List<DBTransaction>();

        //    System.Data.OleDb.OleDbCommand command = new System.Data.OleDb.OleDbCommand("SELECT * FROM Transactions");
        //    command.CommandType = System.Data.CommandType.Text;
        //    command.Connection = botDataConnection;
        //    System.Data.OleDb.OleDbDataReader dataReader = command.ExecuteReader();
        //    while (dataReader.Read())
        //        {
        //        DBTransaction transaction = new DBTransaction(dataReader.GetString(dataReader.GetOrdinal("TransactionID")));
        //        transactions.Add(transaction);
        //        }
        //    dataReader.Close();
        //    command.Dispose();
        //    return transactions;
        //    }

        #region IDisposable Members

        public void Dispose()
            {
            s_sqlConnection.Close();
            }

        #endregion
        }
    }
