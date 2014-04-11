using System;
using System.Collections.Generic;
using System.Text;

namespace BFBot
    {
    public class LindahlBuyRule : IPattern
        {
        private List<Bar> m_bars = new List<Bar>();
        private int m_minimumBars = 9;
        private int m_maximumBars = 9;
        private Sentiment m_sentiment = Sentiment.INVALID;

        public LindahlBuyRule()
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
                
                int a = 0, b = 1, d = 1, e = 1;

                while (b < 9 && b < m_bars.Count)
                    {
                    if (m_bars[1].High < m_bars[b].High && m_bars[b].Low > m_bars[a].Low)
                        break;
                    ++b;
                    }

                d = b + 1;
                while (d < 9 && d < m_bars.Count)
                    {
                    if (m_bars[d - 1].Low > m_bars[d].Low && m_bars[d].Low > m_bars[a].Low && m_bars[d - 1].Low > m_bars[a].Low)
                        break;
                    ++d;
                    }

                e = d + 1;
                while (e < 9 && e < m_bars.Count)
                    {
                    if (m_bars[e].High > m_bars[e - 1].High && m_bars[e].Close > m_bars[e - 1].Close && m_bars[e].Close > m_bars[e].Open && m_bars[e].Low > m_bars[a].Low && m_bars[e - 1].Low > m_bars[a].Low)
                        {
                        m_sentiment = Sentiment.BULLISH;
                        return;
                        }
                    ++e;
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
