using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace BF_Trader_Dumy_Server
    {
    public class DummyRunner
        {
        //private Timer m_timer = new Timer(500);
        private string m_name;
        private decimal m_currentBackPrice;
        private decimal m_currentLayPrice;
        private List<decimal> m_backMarket;
        private List<decimal> m_layMarket;
        //private static Random rand = new Random();
        private decimal m_LargestPrice;
        private decimal m_LowestPrice;

        public DummyRunner(string name)
            {
            m_name = name;
            m_currentBackPrice = Helper.rand.Next(3, 5);
            m_currentLayPrice = m_currentBackPrice + 0.1m;
            m_LargestPrice = m_currentBackPrice;
            m_LowestPrice = m_currentLayPrice;
            m_backMarket = new List<decimal>();
            m_layMarket = new List<decimal>();
            }



        public decimal AverageBack()
            {
            List<decimal> list = m_backMarket;
            return Helper.Average(list);
            }

        public decimal AverageLay()
            {
            List<decimal> list = m_layMarket;
            return Helper.Average(list);
            }

        public decimal BackMovement()
            {
            List<decimal> list = m_backMarket;
            return Helper.UpMovement(list);
            }

        public decimal LayMovement()
            {
            List<decimal> list = m_layMarket;
            return Helper.DownMovement(list);
            }

        public int BackCount()
            {
            return m_backMarket.Count;
            }

        public int LayCount()
            {
            return m_layMarket.Count;
            }

        public decimal High()
            {
            return m_LargestPrice;
            }

        public decimal Low()
            {
            return m_LowestPrice;
            }

        //public void StartTracking()
        //    {
        //    m_timer.Start();
        //    }

        //public void StopTracking()
        //    {
        //    m_timer.Stop();
        //    }

        public List<decimal> BackList()
            {
            return m_backMarket;
            }

        public List<decimal> LayList()
            {
            return m_layMarket;
            }

        //void m_timer_Elapsed(object sender, ElapsedEventArgs e)
        //    {
        //    m_currentBackPrice += Helper.Movement();
        //    m_currentLayPrice = m_currentBackPrice - 0.01; //+= Helper.Movement();
        //    //if (m_currentLayPrice > m_currentBackPrice)
        //    //    m_currentLayPrice = m_currentBackPrice - 0.1;
        //    //if (m_LargestPrice < m_currentBackPrice)
        //    //    m_LargestPrice = m_currentBackPrice;
        //    //if (m_LowestPrice > m_currentLayPrice)
        //    //    m_LowestPrice = m_currentLayPrice;
        //    //m_backMarket.Add(m_currentBackPrice);
        //    //m_layMarket.Add(m_currentLayPrice);
        //    ////System.Diagnostics.Debug.WriteLine(m_name + " -> " + m_currentBackPrice.ToString() + " - " + m_currentLayPrice.ToString());
        //    }

        public void Pause()
            {
            }

        public string Name()
            {
            return m_name;
            }

        public decimal CurrentPrice()
            {
            return m_currentBackPrice;
            }

        }
    }
