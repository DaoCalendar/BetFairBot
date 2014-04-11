using System;
using System.Collections.Generic;
using System.Text;
using BetfairG = BFBot.com.betfair.api6.global;
using BetfairE = BFBot.com.betfair.api6.exchange;

namespace BFBot
    {
    class MarketItemMovement
        {
        private double m_backHigh = 0;
        private double m_backLow = 1000;
        private double m_midBack;
        private double m_layHigh = 0;
        private double m_layLow = 1000;
        private double m_midLay;
        private double m_backWeight = 0;
        private double m_layWeight = 0;
        private double m_lastBackPrice;
        private double m_lastLayPrice;
        private BetfairE.Price[] m_currentBackPrices;
        private BetfairE.Price[] m_currentLayPrices;
        private List<BetfairE.Price[]> m_backPrices;
        private List<BetfairE.Price[]> m_layPrices;
        private List<double> m_backMovement = new List<double>();
        private List<double> m_layMovement = new List<double>();

        public MarketItemMovement()
            {
            m_backPrices = new List<BetfairE.Price[]>();
            m_layPrices = new List<BetfairE.Price[]>();
            }

        public void DumpBackMovement()
            {
            foreach (double d in m_backMovement)
                {
                System.Diagnostics.Debug.WriteLine("B " + d);
                }
            }

        public void DumpLayMovement()
            {
            foreach (double d in m_layMovement)
                {
                System.Diagnostics.Debug.WriteLine("L " + d);
                }
            }

        public BetfairE.Price[] BackPrices()
        {
            return m_currentBackPrices;
        }

        public BetfairE.Price[] LayPrices()
        {
            return m_currentLayPrices;
        }

        public void AddPrices(BetfairE.Price[] backPrices, BetfairE.Price[] layPrices)
            {
            m_currentBackPrices = backPrices;
            m_currentLayPrices = layPrices;
            m_backPrices.Add(backPrices);
            m_layPrices.Add(layPrices);

            if(backPrices.Length > 0)
                m_backMovement.Add(backPrices[0].price);
            if(layPrices.Length > 0)
                m_layMovement.Add(layPrices[0].price);

            DoWeight(backPrices, layPrices);

            if (backPrices.Length > 1)
                {
                m_lastBackPrice = backPrices[0].price;
                if (m_lastBackPrice > m_backHigh)
                    m_backHigh = m_lastBackPrice;
                if (m_lastBackPrice < m_backLow)
                    m_backLow = m_lastBackPrice;
                }
            if (layPrices.Length > 1)
                {
                m_lastLayPrice = layPrices[0].price;
                if (m_lastLayPrice > m_layHigh)
                    m_layHigh = m_lastLayPrice;
                if (m_lastLayPrice < m_layLow)
                    m_layLow = m_lastLayPrice;
                }
            m_midBack = m_backLow + ((m_backHigh - m_backLow) / 2);
            m_midLay = m_layLow + ((m_layHigh - m_layLow) / 2);
            }

        public int BackMovement(int count)
            {
            int up = 0;
            int down = 0;

            if (count > m_layMovement.Count)
                count = m_layMovement.Count -1;
            if (count <= 1)
                return 0;
            for (int i = m_backMovement.Count - (count + 1); i != m_backMovement.Count - 1; i++)
                {
                if (m_backMovement[i] > m_backMovement[i + 1])
                    down++;
                else if (m_backMovement[i] < m_backMovement[i + 1])
                    up++;
                }
            return down - up;
            }


        public int LayMovement(int count)
            {
            int up = 0;
            int down = 0;

            if (count > m_layMovement.Count + 1)
                count = m_layMovement.Count -1;
            if (count <= 1)
                return 0;
            for (int i = m_layMovement.Count - (count + 1); i != m_layMovement.Count - 1; i++)
                {
                if (m_layMovement[i] > m_layMovement[i + 1])
                    down++;
                else if (m_layMovement[i] < m_layMovement[i + 1])
                    up++;
                }
            return up - down;
            }

        public int BackLayMovementCompared(int count)
            {
            return BackMovement(count) - LayMovement(count);
            }

        public double MidBack
            {
            get { return m_midBack; }
            }

        public double MidLay
            {
            get { return m_midLay; }
            }

        public double[] Report()
            {
                double[] values = new double[19];

                values[0] = m_backHigh;
                if (m_currentBackPrices.Length > 0)
                    values[1] = m_currentBackPrices[0].amountAvailable;
                else
                    values[1] = 0.0;
                values[2] = m_backLow;
                values[3] = m_layHigh;
                if (m_currentLayPrices.Length > 0)
                    values[4] = m_currentLayPrices[0].amountAvailable;
                else
                    values[4] = 0.0;
                values[5] = m_layLow;
                values[6] = m_backWeight;
                values[7] = m_layWeight;
                values[8] = m_lastBackPrice;
                values[9] = m_lastLayPrice;
                values[10] = BackHighLowWeight;
                values[11] = LayHighLowWeight;
                values[12] = BackCurrentHighDif();
                values[13] = BackCurrentLowDif();
                values[14] = LayCurrentHighDif();
                values[15] = LayCurrentLowDif();
                values[16] = BackLayDifference();
                values[17] = Last2BackMovements();
                values[18] = Last2LayMovements();

                return values;
            //string report;

                
            //    //report = m_backHigh.ToString() + "," + m_currentBackPrices[0].amountAvailable + "," + m_backLow;
            //    if (m_currentBackPrices.Length > 0)
            //        report = m_backHigh.ToString() + "," + m_currentBackPrices[0].amountAvailable + "," + m_backLow;
            //    else
            //        report = m_backHigh.ToString() + ",0.0," + m_backLow;
            //    if (m_currentLayPrices.Length > 0)
            //        report += "," + m_layHigh + "," + m_currentLayPrices[0].amountAvailable;
            //    else
            //        report += "," + m_layHigh + ",0.0";

            //    report += "," + m_layLow;
            //    report += "," + m_backWeight;
            //    report += "," + m_layWeight;
            //    report += "," + m_lastBackPrice;
            //    report += "," + m_lastLayPrice;

            //    report += "," + BackHighLowWeight;
            //    report += "," + LayHighLowWeight;
            //    report += "," + BackCurrentHighDif().ToString();
            //    report += "," + BackCurrentLowDif().ToString();
            //    report += "," + LayCurrentHighDif().ToString();
            //    report += "," + LayCurrentLowDif().ToString();

            //    report += "," + BackLayDifference().ToString();

            //    report += "," + Last2BackMovements().ToString();
            //    report += "," + Last2LayMovements().ToString() + Environment.NewLine;

            //    return report;
            //string report;

            //report = "==============================================================================================";
            //report += Environment.NewLine + "Back High = " + m_backHigh.ToString() + " Amount Available £" + m_currentBackPrices[0].amountAvailable + Environment.NewLine;
            //report += "Back Low = " + m_backLow + Environment.NewLine;
            //if (m_currentLayPrices.Length > 0)
            //    report += "Lay High = " + m_layHigh + " Amount Available £" + m_currentLayPrices[0].amountAvailable + Environment.NewLine;
            //else
            //    report += "Lay High = " + m_layHigh + Environment.NewLine;

            //report += "Lay Low = " + m_layLow + Environment.NewLine;
            //report += "Back Weight = " + m_backWeight + Environment.NewLine;
            //report += "Lay Weight = " + m_layWeight + Environment.NewLine;
            //report += "Last Back Price = " + m_lastBackPrice + Environment.NewLine;
            //report += "Last Lay Price = " + m_lastLayPrice + Environment.NewLine;

            //report += "Back High Low Weight = " + BackHighLowWeight + Environment.NewLine;
            //report += "Lay High Low Weight = " + LayHighLowWeight + Environment.NewLine;
            //report += "Back Current High Dif = " + BackCurrentHighDif().ToString() + Environment.NewLine;
            //report += "Back Current Low Dif = " + BackCurrentLowDif().ToString() + Environment.NewLine;
            //report += "Lay Current High Dif = " + LayCurrentHighDif().ToString() + Environment.NewLine;
            //report += "Lay Current Low Dif = " + LayCurrentLowDif().ToString() + Environment.NewLine;

            //report += "Back Lay Dif = " + BackLayDifference().ToString() + Environment.NewLine;

            //report += "Last 2 Back Movements = " + Last2BackMovements().ToString() + Environment.NewLine;
            //report += "Last 2 Lay Movements = " + Last2LayMovements().ToString() + Environment.NewLine;

            //return report;
            }

        private void DoWeight(BetfairE.Price[] backPrices, BetfairE.Price[] layPrices)
            {
            double r1;
            double r2;

            try
                {
                if (backPrices.Length == 2)
                    {
                    r1 = backPrices[0].price - backPrices[1].price;
                    m_backWeight += r1;
                    }
                else if (backPrices.Length == 3)
                    {
                    r1 = backPrices[0].price - backPrices[1].price;
                    r2 = backPrices[1].price - backPrices[2].price;
                    m_backWeight += r1;
                    m_backWeight += r2;
                    }

                if (layPrices.Length == 2)
                    {
                    r1 = layPrices[0].price - layPrices[1].price;
                    m_layWeight += r1;
                    }
                else if (layPrices.Length == 3)
                    {
                    r1 = layPrices[0].price - layPrices[1].price;
                    r2 = layPrices[1].price - layPrices[2].price;
                    m_layWeight += r1;
                    m_layWeight += r2;
                    }
                }
            catch (Exception ex)
                {
                BfBot.DumpToFile("**** Error in MarketItemMovement->DoWeight ****");
                BfBot.DumpToFile(ex.Message);
                }
            }

        public double BackHighLowWeight
            {
            get { return m_backHigh - m_backLow; }
            }

        public double LayHighLowWeight
            {
            get { return m_layHigh - m_layLow; }
            }

        public double BackWeight
            {
            get { return m_backWeight; }
            }

        public double LayWeight
            {
            get { return m_layWeight; }
            }

        public double BackHigh
            {
            get { return m_backHigh; }
            }

        public double BackLow
            {
            get { return m_backLow; }
            }

        public double LayHigh
            {
            get { return m_layHigh; }
            }

        public double LayLow
            {
            get { return m_layLow; }
            }

        public double BackCurrentHighDif()
            {
            return m_backHigh - m_lastBackPrice;
            }

        public double BackCurrentLowDif()
            {
            return m_lastBackPrice - m_backLow;
            }

        public double LayCurrentHighDif()
            {
            return m_layHigh - m_lastLayPrice;
            }

        public double LayCurrentLowDif()
            {
            return m_lastLayPrice - m_layLow;
            }

        public double BackPrice
            {
            get { return m_lastBackPrice; }
            }

        public double LayPrice
            {
            get { return m_lastLayPrice; }
            }

        public double BackLayDifference()
            {
            double result = m_lastLayPrice - m_lastBackPrice;

            return m_lastLayPrice - m_lastBackPrice;
            }

        public double LastBackMovement()
            {
            return m_currentBackPrices[0].price - m_currentBackPrices[1].price;
            }

        public double LastLayMovement()
            {
            return m_currentLayPrices[0].price - m_currentLayPrices[1].price;
            }

        public double Last2BackMovements()
            {
            if(m_currentBackPrices.Length == 3)
                return (m_currentBackPrices[0].price - m_currentBackPrices[1].price) + (m_currentBackPrices[1].price - m_currentBackPrices[2].price);
            return 0.0;
            }

        public double Last2LayMovements()
            {
            if(m_currentLayPrices.Length == 3)
                return (m_currentLayPrices[0].price - m_currentLayPrices[1].price) + (m_currentLayPrices[1].price - m_currentLayPrices[2].price);
            return 0.0;
            }

        public double Last5BackMovements()
            {
            double r1;
            double r2;
            double r3;
            double r4;
            double r5;

            try
                {
                BetfairE.Price[] price1 = m_backPrices[m_backPrices.Count];
                BetfairE.Price[] price2 = m_backPrices[m_backPrices.Count - 1];

                r1 = price1[0].price - price1[1].price;
                r2 = price1[1].price - price1[2].price;
                r3 = price1[2].price - price2[0].price;
                r4 = price2[0].price - price2[1].price;
                r5 = price2[1].price - price2[2].price;

                return r1 + r2 + r3 + r4 + r5;
                }
            catch (Exception ex)
                {
                BfBot.DumpToFile("**** Error in MarketItemMovement->Last5BackMovements ****");
                BfBot.DumpToFile(ex.Message + "InnerException=[" + ex.InnerException.Message + "]");
                return 0.0;
                }
            }

        public double Last5LayMovements()
            {
            double r1;
            double r2;
            double r3;
            double r4;
            double r5;

            try
                {
                BetfairE.Price[] price1 = m_layPrices[m_layPrices.Count];
                BetfairE.Price[] price2 = m_layPrices[m_layPrices.Count - 1];

                r1 = price1[0].price - price1[1].price;
                r2 = price1[1].price - price1[2].price;
                r3 = price1[2].price - price2[0].price;
                r4 = price2[0].price - price2[1].price;
                r5 = price2[1].price - price2[2].price;

                return r1 + r2 + r3 + r4 + r5;
                }
            catch (Exception ex)
                {
                BfBot.DumpToFile("**** Error in MarketItemMovement->Last5LayMovements ****");
                BfBot.DumpToFile(ex.Message + "InnerException=[" + ex.InnerException.Message + "]");
                return 0.0;
                }
            }

        public double Last10BackMovements()
            {
            double r1;
            double r2;
            double r3;
            double r4;
            double r5;
            double r6;
            double r7;
            double r8;

            try
                {
                BetfairE.Price[] price1 = m_backPrices[m_backPrices.Count];
                BetfairE.Price[] price2 = m_backPrices[m_backPrices.Count - 1];
                BetfairE.Price[] price3 = m_backPrices[m_backPrices.Count - 2];

                r1 = price1[0].price - price1[1].price;
                r2 = price1[1].price - price1[2].price;
                r3 = price1[2].price - price2[0].price;
                r4 = price2[0].price - price2[1].price;
                r5 = price2[1].price - price2[2].price;
                r6 = price2[2].price - price3[0].price;
                r7 = price3[0].price - price3[1].price;
                r8 = price3[1].price - price3[2].price;

                return r1 + r2 + r3 + r4 + r5 + r6 + r7 + r8;
                }
            catch (Exception ex)
                {
                BfBot.DumpToFile("**** Error in MarketItemMovement->Last10BackMovements ****");
                BfBot.DumpToFile(ex.Message + "InnerException=[" + ex.InnerException.Message + "]");
                return 0.0;
                }
            }

        public double Last10LayMovements()
            {
            double r1;
            double r2;
            double r3;
            double r4;
            double r5;
            double r6;
            double r7;
            double r8;

            try
                {
                BetfairE.Price[] price1 = m_layPrices[m_layPrices.Count];
                BetfairE.Price[] price2 = m_layPrices[m_layPrices.Count - 1];
                BetfairE.Price[] price3 = m_layPrices[m_layPrices.Count - 2];

                r1 = price1[0].price - price1[1].price;
                r2 = price1[1].price - price1[2].price;
                r3 = price1[2].price - price2[0].price;
                r4 = price2[0].price - price2[1].price;
                r5 = price2[1].price - price2[2].price;
                r6 = price2[2].price - price3[0].price;
                r7 = price3[0].price - price3[1].price;
                r8 = price3[1].price - price3[2].price;

                return r1 + r2 + r3 + r4 + r5 + r6 + r7 + r8;
                }
            catch (Exception ex)
                {
                BfBot.DumpToFile("**** Error in MarketItemMovement->Last10LayMovements ****");
                BfBot.DumpToFile(ex.Message + "InnerException=[" + ex.InnerException.Message + "]");
                return 0.0;
                }
            }

        public double Prediction()
            {
            double prediction = 0.0;

            return prediction;
            }
        //public double OverallBackMovement()
        //    {
        //    double weight = 0;

        //    foreach (BetfairE.Price[] price in m_backPrices)
        //        {
                
        //        }
        //    }

        //public double OverallLayMovement()
        //    {
        //    double weight = 0;

        //    foreach (BetfairE.Price[] price in m_backPrices)
        //        {

        //        }
        //    }
        }
    }
