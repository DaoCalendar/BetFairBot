using System;
using System.Collections.Generic;
using System.Text;

namespace BFBot
    {
    public class Bar
        {
        private DateTime m_date;
        private double m_open;
        private double m_high = -99999999;
        private double m_low = 99999999;
        private double m_close;
        private long m_volume;

        public Bar()
            {
            }

        public Bar(Bar bar)
            {
            
            }

        public Bar(double open, double high, double low, double close)
            {
            this.Open = open;
            this.High = high;
            this.Low = low;
            this.Close = close;
            }

        public Bar(double open, double high, double low, double close, long volume)
            {
            this.Open = open;
            this.High = high;
            this.Low = low;
            this.Close = close;
            this.Volume = volume;
            }

        public Bar(DateTime date, double open, double high, double low, double close, long volume)
            {
            this.Date = date;
            this.Open = open;
            this.High = high;
            this.Low = low;
            this.Close = close;
            this.Volume = volume;
            }

        public double Close
            {
            get { return m_close; }
            set { m_close = value; }
            }

        public DateTime Date
            {
            get { return m_date; }
            set { m_date = value; }
            }

        public double High
            {
            get { return m_high; }
            set { m_high = value; }
            }

        public double Low
            {
            get { return m_low; }
            set { m_low = value; }
            }

        public double Open
            {
            get { return m_open; }
            set { m_open = value; }
            }

        public long Volume
            {
            get { return m_volume; }
            set { m_volume = value; }
            }

        public void Update(double open, double high, double low, double close, long volume)
            {
            this.Open = open;
            if (high > this.High)
                this.High = high;
            if (low < this.Low)
                this.Low = low;
            this.Close = close;
            this.Volume += volume;
            }

        public void Update(Bar bar)
            {
            if (bar.High > this.High)
                this.High = bar.High;
            if (bar.Low < this.Low)
                this.Low = bar.Low;
            this.Close = bar.Close;
            this.Volume += bar.Volume;
            }

        }
    }
