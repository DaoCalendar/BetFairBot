using System;
using System.Collections.Generic;
using System.Text;

namespace BF_Trader_Dumy_Server
    {
    public class DummyDay
        {
        private DateTime m_dateTime;
        private IList<DummyMeeting> m_meetings;

        public DummyDay(DateTime dateTime)
            {
            m_dateTime = dateTime;
            m_meetings = GetMeetings();
            }

        public DateTime Date()
            {
            return m_dateTime;
            }

        public int NumberOfMeetings
            {
            get { return m_meetings.Count; }
            }
            
        public DummyMeeting GetMeeting(int index)
            {
            return m_meetings[index];
            }

        public List<DummyRace> Markets()
            {
            List<DummyRace> rtList = new List<DummyRace>();

            for (int i = 0; i < m_meetings.Count; i++)
                {
                for (int j = 0; j < m_meetings[j].Races().Count; j++)
                    {
                    rtList.Add(m_meetings[i].Races()[j]);
                    }
                }
            return rtList;
            }

        public List<DummyMeeting> GetMeetings()
            {
            //Random r = new Random();
            List<DummyMeeting> newMeetings = new List<DummyMeeting>();

            double numberOfMeetings = 3;// r.Next(3, 15);

            for (int i = 0; i < (int)numberOfMeetings; i++)
                newMeetings.Add(new DummyMeeting());

            //newMeetings.Add(new DummyMeeting("Kempton"));
            //newMeetings.Add(new DummyMeeting("Chepstow"));
            //newMeetings.Add(new DummyMeeting("Carlisle"));

            return newMeetings;
            }
        }
    }
