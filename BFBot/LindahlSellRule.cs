using System;
using System.Collections.Generic;
using System.Text;

namespace BFBot
    {
    public class LindahlSellRule : IPattern
        {
        private List<Bar> m_bars = new List<Bar>();
        private int m_minimumBars = 9;
        private int m_maximumBars = 9;
        private Sentiment m_sentiment = Sentiment.INVALID;

        public LindahlSellRule()
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

                double ahigh = m_bars[a].High;
                int size = Math.Min(8, m_bars.Count);

                while(b < size)
                    {
                    if (m_bars[a].Low > m_bars[b].Low && m_bars[b].High < ahigh)
                        break;
                    ++b;
                    }
                            // d must take out the high the preceeding bar
                    d = b + 1; // start at b
                    while (d < size)
                    {
                        if (m_bars[d].High < ahigh && m_bars[d - 1].High < ahigh && m_bars[d - 1].High < m_bars[d].High)
                            break;
                        ++d;
                    }

                    // e must take out the low of the preceeding bar
                    // and close below the previous bar's close
                    // and close below its own open price

                    e = d + 1;

                    while (e < size)
                    {
                        Bar rece = m_bars[e];
                        Bar recf = m_bars[e - 1];
                        if (rece.Low < recf.Low // take low of prev bare
                                && rece.Close < recf.Close // close below prev bar
                                && rece.Close < rece.Open // close down
                                && rece.High < ahigh && recf.High < ahigh)
                        {
                            m_sentiment = Sentiment.BEARISH;
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
