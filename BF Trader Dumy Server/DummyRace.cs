using System;
using System.Collections.Generic;
using System.Text;

namespace BF_Trader_Dumy_Server
    {
    public class DummyRace
        {
        private DateTime m_time;
        private List<DummyRunner> m_runners;
        private Random rand = new Random();

        public DummyRace(DateTime dateTime)
            {
            m_runners = new List<DummyRunner>();
            m_time = dateTime;


            double runners = Helper.rand.Next(4, 18);
            int numRunners = (int)(runners);// * 100) / 5);
            for (int i = 0; i != numRunners; i++)
                {
                DummyRunner runner = new DummyRunner("Item " + i.ToString());
                m_runners.Add(runner);
                }           
            }

        public DateTime RaceDateTime
            {
            get { return m_time; }
            }

        public List<DummyRunner> Runners()
            {
            return m_runners;
            }

        public string Time()
            {
            return m_time.ToString();
            }
        }
    }
