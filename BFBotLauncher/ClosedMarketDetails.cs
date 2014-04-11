using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BFBotLauncher
    {
    public partial class ClosedMarketDetails : Form
        {
        public ClosedMarketDetails()
            {
            InitializeComponent();
            }

        public ClosedMarketDetails(string marketID)
            {
            InitializeComponent();
            listViewTransactions.Columns.Add(@"Market");
            listViewTransactions.Columns.Add(@"Date");
            listViewTransactions.Columns.Add(@"Time");
            listViewTransactions.Columns.Add(@"Action");
            listViewTransactions.Columns.Add(@"Amount");
            listViewTransactions.Columns.Add(@"Deposit");
            listViewTransactions.Columns.Add(@"Withdrawal");
            listViewTransactions.Columns.Add(@"Balance");

            BFBotDB.DBClosedMarket closedMarket = new BFBotDB.DBClosedMarket(marketID);

            List<BFBotDB.DBTransaction> transactions = closedMarket.Transactions;
            foreach (BFBotDB.DBTransaction transaction in transactions)
                {

                ListViewItem listViewItem = new ListViewItem(closedMarket.Name);
                listViewItem.SubItems.Add(closedMarket.Date);
                listViewItem.SubItems.Add(closedMarket.Time);
                listViewItem.SubItems.Add(transaction.TransactionAction);
                listViewItem.SubItems.Add(transaction.TransactionAmount.ToString("0.00"));
                if (transaction.DepositWithdrawal == "Deposit")
                    listViewItem.SubItems.Add(transaction.TransactionAmount.ToString("0.00"));
                else
                    listViewItem.SubItems.Add("0.00");

                if (transaction.DepositWithdrawal == "Withdrawal")
                    listViewItem.SubItems.Add(transaction.TransactionAmount.ToString("0.00"));
                else
                    listViewItem.SubItems.Add("0.00");

                listViewItem.SubItems.Add(transaction.Balance.ToString("0.00"));
                listViewTransactions.Items.Add(listViewItem);
                }
            //foreach (BFBotDB.DBTransaction transaction in transactions)
            //    {
            //    ListViewItem listViewItem = new ListViewItem(transaction.TransactionAmount.ToString("0.00"));
            //    listViewItem.SubItems.Add(transaction.Balance.ToString("0.00"));
            //    listViewItem.SubItems.Add(transaction.DepositWithdrawal);
            //    listViewTransactions.Items.Add(listViewItem);
            //    }

            labelMarket.Text = closedMarket.Name;
            labelMarketDate.Text = closedMarket.Date;
            labelMarketTime.Text = closedMarket.Time;

            labelMarketItemName.Text = closedMarket.MarketItemName;

            labelBackedStake.Text = closedMarket.MarketItemBackStake;
            labelBackOdds.Text = closedMarket.MarketItemBackOdds;
            labelBackReturns.Text = closedMarket.MarketItemBackReturns;

            labelLayedStake.Text = closedMarket.marketItemLayStake;
            lblLayOdds.Text = closedMarket.MarketItemLayOdds;
            labelLayReturns.Text = closedMarket.MarketItemLayReturns;

            labelWinLoseProfit.Text = closedMarket.WinLoseProfit;
            }

        public ClosedMarketDetails(string name, string date, string time)
            {
            InitializeComponent();
            listViewTransactions.Columns.Add(@"Market");
            listViewTransactions.Columns.Add(@"Date");
            listViewTransactions.Columns.Add(@"Time");
            listViewTransactions.Columns.Add(@"Action");
            listViewTransactions.Columns.Add(@"Amount");
            listViewTransactions.Columns.Add(@"Deposit");
            listViewTransactions.Columns.Add(@"Withdrawal");
            listViewTransactions.Columns.Add(@"Balance");
            
            BFBotDB.DBClosedMarket closedMarket = new BFBotDB.DBClosedMarket(name, date, time);

            List<BFBotDB.DBTransaction> transactions = closedMarket.Transactions;
            foreach (BFBotDB.DBTransaction transaction in transactions)
                {

                ListViewItem listViewItem = new ListViewItem(closedMarket.Name);
                listViewItem.SubItems.Add(closedMarket.Date);
                listViewItem.SubItems.Add(closedMarket.Time);
                listViewItem.SubItems.Add(transaction.TransactionAction);
                listViewItem.SubItems.Add(transaction.TransactionAmount.ToString("0.00"));
                if(transaction.DepositWithdrawal == "Deposit")
                    listViewItem.SubItems.Add(transaction.TransactionAmount.ToString("0.00"));
                else
                    listViewItem.SubItems.Add("0.00");

                if (transaction.DepositWithdrawal == "Withdrawal")
                    listViewItem.SubItems.Add(transaction.TransactionAmount.ToString("0.00"));
                else
                    listViewItem.SubItems.Add("0.00");

                listViewItem.SubItems.Add(transaction.Balance.ToString("0.00"));
                listViewTransactions.Items.Add(listViewItem);
                }

            labelMarket.Text = closedMarket.Name;
            labelMarketDate.Text = closedMarket.Date;
            labelMarketTime.Text = closedMarket.Time;

            labelMarketItemName.Text = closedMarket.MarketItemName;

            labelBackedStake.Text = closedMarket.MarketItemBackStake;
            labelBackOdds.Text = closedMarket.MarketItemBackOdds;
            labelBackReturns.Text = closedMarket.MarketItemBackReturns;

            labelLayedStake.Text = closedMarket.marketItemLayStake;
            lblLayOdds.Text = closedMarket.MarketItemLayOdds;
            labelLayReturns.Text = closedMarket.MarketItemLayReturns;

            labelWinLoseProfit.Text = closedMarket.WinLoseProfit;
            }
        }
    }