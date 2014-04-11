using System;
using System.Collections.Generic;
using System.Text;

namespace BFBot
    {
    public class HighLowReversal : IPattern
        {
        private List<Bar> m_bars = new List<Bar>();
        private int m_minimumBars = 2;
        private int m_maximumBars = 2;
        private Sentiment m_sentiment = Sentiment.INVALID;
        private double m_difference = 0.05;

        public HighLowReversal()
            {
            }

        #region IPattern Members

        public void init(Security security)
            {
            m_bars = new List<Bar>();
            }

        public void add(Bar bar)
            {
            m_bars.Add(bar);
            if (m_bars.Count > m_maximumBars)
                m_bars.Remove(m_bars[0]);

            if (m_bars.Count >= m_minimumBars)
                {
                m_sentiment = Sentiment.NEUTRAL;
                if (m_bars[0].Close >= m_bars[0].High - m_difference && m_bars[1].Close <= m_bars[1].Low + m_difference)
                    m_sentiment = Sentiment.BEARISH;
                else if (m_bars[1].Close >= m_bars[1].High - m_difference && m_bars[0].Close <= m_bars[0].Low + m_difference)
                    m_sentiment = Sentiment.BULLISH;
                }
            }

        public Sentiment getSentiment()
            {
            return m_sentiment;
            }

        #endregion
        }
    }
