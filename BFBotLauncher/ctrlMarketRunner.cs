using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace BFBot
    {
    public partial class ctrlMarketRunner : UserControl
        {
        private List<decimal> backPrices = new List<decimal>(5);
        private List<Decimal> layPrices = new List<decimal>(5);
        private MarketRunner m_runner;

        public enum PriceMovement
            {
            Static = 1,
            Up = 2,
            Down = 3
            }

        public ctrlMarketRunner()
            {
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            }

        public ctrlMarketRunner(MarketRunner runner)
            {
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            m_runner = runner;
            lblName.Text = m_runner.Name;
            m_runner.OnUpdateRunner += new MarketRunner.RunnerUpdateDelegate(runner_OnUpdateRunner);
            }

        void runner_OnUpdateRunner()
            {
            if (m_runner.MarketState != BFBot.MarketState.Closed)
                {
                //return;
                if (m_runner.MarketRunnerState == BFBot.MarketItemState.Equalised)
                    {
                    this.BackColor = Color.Magenta;
                    return;
                    }
                if (m_runner.MarketRunnerState != BFBot.MarketItemState.Backed)
                    AddNewBackPrice(m_runner.CurrentBackPrice);
                if (m_runner.MarketRunnerState != BFBot.MarketItemState.Equalised)
                    AddNewLayPrice(m_runner.CurrentLayPrice);
                if (m_runner.MarketRunnerState == BFBot.MarketItemState.Analysing &&
                    m_runner.MarketState != BFBot.MarketState.Backed)
                    this.BackColor = Color.White;
                if (m_runner.MarketRunnerState == BFBot.MarketItemState.Backed &&
                    m_runner.MarketState != BFBot.MarketState.Equalised)
                    this.BackColor = Color.LightGreen;
                UpdateBackPrices();
                UpdateLayPrices();
                }
            else
                {
                this.Parent.Controls.Remove(this);
                }
            }
        
        public void AddNewBackPrice(decimal value)
            {
            if (backPrices.Count == 5)
                backPrices.Remove(backPrices[0]);
            backPrices.Add(value);
            }

        public void AddNewLayPrice(decimal value)
            {
            if (layPrices.Count == 5)
                layPrices.Remove(layPrices[0]);
            layPrices.Add(value);
            }

        private void UpdateBackPrices()
            {
            if (backPrices.Count >= 1)
                {
                lblBack5.Text = backPrices[0].ToString("0.00");
                lblBack5.BackColor = IndicatorColor(GetPriceMovement(backPrices, 0));
                }
            if (backPrices.Count >= 2)
                {
                lblBack4.Text = backPrices[1].ToString("0.00");
                lblBack4.BackColor = IndicatorColor(GetPriceMovement(backPrices, 1));
                }
            if (backPrices.Count >= 3)
                {
                lblBack3.Text = backPrices[2].ToString("0.00");
                lblBack3.BackColor = IndicatorColor(GetPriceMovement(backPrices, 2));
                }
            if (backPrices.Count >= 4)
                {
                lblBack2.Text = backPrices[3].ToString("0.00");
                lblBack2.BackColor = IndicatorColor(GetPriceMovement(backPrices, 3));
                }
            if (backPrices.Count == 5)
                {
                lblBack1.Text = backPrices[4].ToString("0.00");
                lblBack1.BackColor = IndicatorColor(GetPriceMovement(backPrices, 4));
                }            
            }

        private void UpdateLayPrices()
            {
            if (layPrices.Count >= 1)
                {
                lblLay5.Text = layPrices[0].ToString("0.00");
                lblLay5.BackColor = IndicatorColor(GetPriceMovement(layPrices, 0));
                }
            if (layPrices.Count >= 2)
                {
                lblLay4.Text = layPrices[1].ToString("0.00");
                lblLay4.BackColor = IndicatorColor(GetPriceMovement(layPrices, 1));
                }
            if (layPrices.Count >= 3)
                {
                lblLay3.Text = layPrices[2].ToString("0.00");
                lblLay3.BackColor = IndicatorColor(GetPriceMovement(layPrices, 2));
                }
            if (layPrices.Count >= 4)
                {
                lblLay2.Text = layPrices[3].ToString("0.00");
                lblLay2.BackColor = IndicatorColor(GetPriceMovement(layPrices, 3));
                }
            if (layPrices.Count == 5)
                {
                lblLay1.Text = layPrices[4].ToString("0.00");
                lblLay1.BackColor = IndicatorColor(GetPriceMovement(layPrices, 4));
                }  
            }

        private Color IndicatorColor(PriceMovement priceMovement)
            {
            Color returnColor;

            switch (priceMovement)
                {
                case(PriceMovement.Up):
                    returnColor = Color.Red;
                    break;
                case(PriceMovement.Down):
                    returnColor = Color.LightGreen;
                    break;
                default:
                    returnColor = Color.Orange;
                    break;
                }
            return returnColor;
            }

        private PriceMovement GetPriceMovement(List<decimal> list, int thisIndex)
            {
            if (thisIndex >= 1)
                {
                if (list[thisIndex] > list[thisIndex - 1])
                    return PriceMovement.Up;
                else if (list[thisIndex] < list[thisIndex - 1])
                    return PriceMovement.Down;
                else
                    return PriceMovement.Static;
                }
            return PriceMovement.Static;
            }
        }
    }
