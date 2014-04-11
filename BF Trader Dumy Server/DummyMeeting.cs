using System;
using System.Collections.Generic;
using System.Text;

namespace BF_Trader_Dumy_Server
    {
    public class DummyMeeting
        {
        private string[] meetings =
                {"Chepstow",
                 "Lingfield",
                "Newmarket",
                "Kempton",
                "Nottingham",
                "Ludlow"
                };
        
        private TimeSpan m_nextMeeting = new TimeSpan(0, 1, 0);

        private string m_name;
        private List<DummyRace> m_races;

        public DummyMeeting()
            {
            //System.Threading.Thread.Sleep(1000);
            double m = Helper.rand.Next(0, meetings.Length);
            this.m_name = meetings[(int)m];

            m_races = GetRaces();
            }

        public string Name()
            {
            return m_name;
            }

        public List<DummyRace> Races()
            {
            return m_races;
            }

        private List<DummyRace> GetRaces()
            {
            List<DummyRace> newRaces = new List<DummyRace>();
            Random r = new Random();
            System.Threading.Thread.Sleep(250);
            double a = r.Next(10, 59);

            double hours = DateTime.Now.Hour;//= r.Next(12, 14); 
            double minutes = DateTime.Now.Minute; //= r.Next(0, 59);

            DateTime dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute , (int)a);

            dt += m_nextMeeting;
            newRaces.Add(new DummyRace(dt));
            dt += m_nextMeeting;
            newRaces.Add(new DummyRace(dt));
            dt += m_nextMeeting;
            newRaces.Add(new DummyRace(dt));
            dt += m_nextMeeting;
            newRaces.Add(new DummyRace(dt));
            dt += m_nextMeeting;
            newRaces.Add(new DummyRace(dt));
            dt += m_nextMeeting;
            newRaces.Add(new DummyRace(dt));
            dt += m_nextMeeting;
            newRaces.Add(new DummyRace(dt));
            dt += m_nextMeeting;
            newRaces.Add(new DummyRace(dt));
            dt += m_nextMeeting;
            return newRaces;
            }

        }
    }
