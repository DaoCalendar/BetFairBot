using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataLayer;

namespace DesktopInterface
{
    public partial class DesktopInterface : Form
    {
        private SqlConnection conn;
        private List<MarketDetails> m_marketDetails;
 
        public DesktopInterface()
        {
            InitializeComponent();

            DataSet ds = DataLayer.DB.Instance.GetMarketNames();

            comboBox1.DataSource = ds.Tables[0];
            comboBox1.ValueMember = "MarketID";
            comboBox1.DisplayMember = "MarketName";
        }

        private void DesktopInterface_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bFBOTDataSet.Markets' table. You can move, or remove it, as needed.
            DataLayer.DB.Instance.Open ();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            PopulateMarketDetails ();
        }

        private void PopulateMarketDetails ()
        {
            //dataGridView1.ReadOnly = true;
            //dataGridView1.DataSource = DataLayer.DataLayer.Instance.GetMarkets();

            DataSet ds = DataLayer.DB.Instance.GetMarkets();

            foreach (DataTable dataTable in ds.Tables)
            {
                MarketDetails.Instance.MarketDetailsPopulate(dataTable);
            }
        }

        private void DesktopInterface_FormClosing(object sender, FormClosingEventArgs e)
        {
            //conn.Close();
            DataLayer.DB.Instance.Close();
        }

        private void comboBox1_ValueMemberChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.ValueMember != "")
            {
                DataSet ds = DataLayer.DB.Instance.GetMarketItems(int.Parse(comboBox1.SelectedValue.ToString()));

                listBoxMarketItems.DataSource = ds.Tables[0];
                listBoxMarketItems.ValueMember = "MarketID";
                listBoxMarketItems.DisplayMember = "MarketName";
            }
        }
    }
}
