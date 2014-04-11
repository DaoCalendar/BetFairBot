using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BFBotLauncher
    {
    public partial class frmAccounts : Form
        {

        public frmAccounts()
            {
            InitializeComponent();
            listView1.Columns.Add("Transaction ID");
            listView1.Columns.Add("Time Stamp");
            listView1.Columns.Add("Market Item ID");
            listView1.Columns.Add("Transaction Amount");
            listView1.Columns.Add("Balance");
            listView1.Columns.Add("Deposit Withdrawal");
            listView1.Columns.Add("Transaction Action");
            UpdateData();
            }

        private void UpdateData()
            {
            int counter = 0;
            List<BFBotDB.DBTransaction> transactions = BFBotDB.BFBotDBWorker.Instance().GetTransactions();

            foreach (BFBotDB.DBTransaction transaction in transactions)
                {
                listView1.Items.Add(transaction.GetListViewItem());
                if ((counter++ % 2) == 0)
                    listView1.Items[listView1.Items.Count - 1].BackColor = Color.LightBlue;
                }
            }

        private void timer1_Tick(object sender, EventArgs e)
            {
            //listView1.Items.Clear();
            //UpdateData();
            }

        private void buttonRefreshAccounts_Click(object sender, EventArgs e)
            {
            listView1.Items.Clear();
            UpdateData();
            }
        }
    }