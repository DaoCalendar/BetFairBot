using System;
using System.Collections.Generic;
using System.Text;

namespace BFBotDB
    {
    public class DBTransaction
    {
        private int m_transactionID;
        private string m_transactionTimeStamp;
        private int m_marketItemID;
        private double m_transactionAmount;
        private double m_balance;
        private string m_depositWithdrawal;
        private string m_transactionAction;

        public DBTransaction(string TransactionID)
        {
            //System.Data.OleDb.OleDbCommand command =
            //    new System.Data.OleDb.OleDbCommand("SELECT * FROM Transactions WHERE TransactionID='" + TransactionID +
            //                                       "'");
            //command.CommandType = System.Data.CommandType.Text;
            //command.Connection = BFBotDB.BfBotDbWorker.Instance().Connection;
            //System.Data.OleDb.OleDbDataReader dataReader = command.ExecuteReader();
            //while (dataReader != null && dataReader.Read())
            //{
            //    m_transactionID = dataReader.GetOrdinal("TransactionID");
            //    //m_transactionID = dataReader.GetString(dataReader.GetOrdinal("TransactionID"));
            //    m_transactionTimeStamp = dataReader.GetString(dataReader.GetOrdinal("TransactionTimeStamp"));
            //    m_marketItemID = dataReader.GetOrdinal("MarketItemID");
            //    m_transactionAmount = dataReader.GetDouble(dataReader.GetOrdinal("TransactionAmount"));
            //    m_balance = dataReader.GetDouble(dataReader.GetOrdinal("Balance"));
            //    m_depositWithdrawal = dataReader.GetString(dataReader.GetOrdinal("DepositWithdrawal"));
            //    m_transactionAction = dataReader.GetString(dataReader.GetOrdinal("TransactionAction"));
            //    dataReader.Close();
            //}

            //command.Dispose();
        }

        public System.Windows.Forms.ListViewItem GetListViewItem()
        {
            System.Windows.Forms.ListViewItem listViewItem = new System.Windows.Forms.ListViewItem(m_transactionID.ToString());
            listViewItem.SubItems.Add(m_transactionTimeStamp);
            listViewItem.SubItems.Add(m_marketItemID.ToString());
            listViewItem.SubItems.Add(m_transactionAmount.ToString("0.00"));
            listViewItem.SubItems.Add(m_balance.ToString("0.00"));
            listViewItem.SubItems.Add(m_depositWithdrawal);
            listViewItem.SubItems.Add(m_transactionAction);
            return listViewItem;
        }

        public string TransactionAction
        {
            get { return m_transactionAction; }
        }

        public int TransactionID
        {
            get { return m_transactionID; }
        }

        public string TransactionTimeStamp
        {
            get { return m_transactionTimeStamp; }
        }

        public int MarketItemID
        {
            get { return m_marketItemID; }
        }

        public double TransactionAmount
        {
            get { return m_transactionAmount; }
        }

        public double Balance
        {
            get { return m_balance; }
        }

        public string DepositWithdrawal
        {
            get { return m_depositWithdrawal; }
        }
    }
    }
