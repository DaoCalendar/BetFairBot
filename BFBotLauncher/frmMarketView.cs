using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BFBotLauncher
    {
    public partial class frmMarketView : Form
        {
        public frmMarketView(BFBot.Market market)
            {
            InitializeComponent();
            ctrlMarket marketControl = new ctrlMarket(market);
            marketControl.Dock = DockStyle.Fill;
            this.Controls.Add(marketControl);
            }
        }
    }