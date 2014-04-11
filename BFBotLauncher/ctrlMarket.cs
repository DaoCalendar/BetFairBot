using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace BFBotLauncher
    {
    public partial class ctrlMarket : UserControl
        {
        private BFBot.Market m_market;
        
        public ctrlMarket()
            {
            InitializeComponent();
            }

        public ctrlMarket(BFBot.Market market)
            {
            InitializeComponent();
            m_market = market;
            foreach(BFBot.MarketItem marketItem in m_market.Runners)
                {
                ctrlMarketItem controlMarketItem = new ctrlMarketItem(marketItem);
                this.flowLayoutPanel1.Controls.Add(controlMarketItem);
                }
            }
        }
    }
