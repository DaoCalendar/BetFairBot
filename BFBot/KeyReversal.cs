using System;
using System.Collections.Generic;
using System.Text;

namespace BFBot
    {
    public class KeyReversal : IPattern
        {
        private List<Bar> m_bars = new List<Bar>();
        private int m_minimumBars = 2;
        private int m_maximumBars = 2;
        private Sentiment m_sentiment = Sentiment.INVALID;

        public KeyReversal()
            {
            }

        #region IPattern Members

        public void init(Security security)
            {
            m_bars = new List<Bar>();
            m_sentiment = Sentiment.INVALID;
            }

        public void add(Bar bar)
            {
            m_bars.Add(bar);
            if (m_bars.Count > m_maximumBars)
                m_bars.Remove(m_bars[0]);

            if (m_bars.Count >= m_minimumBars)
                {
                m_sentiment = Sentiment.NEUTRAL;

                if (m_bars[0].High < m_bars[1].High && m_bars[0].Low > m_bars[1].Low)
                    {
                    if (m_bars[1].Close >= m_bars[0].High)
                        m_sentiment = Sentiment.BULLISH;
                    else if (m_bars[1].Close <= m_bars[0].Low)
                        m_sentiment = Sentiment.BEARISH;
                    }
                }
            }

        public Sentiment getSentiment()
            {
            return m_sentiment;
            }

        #endregion
        }
    }
