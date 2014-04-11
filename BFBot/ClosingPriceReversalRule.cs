using System;
using System.Collections.Generic;
using System.Text;

namespace BFBot
    {
    public class ClosingPriceReversalRule : IPattern
        {
        private List<Bar> m_bars = new List<Bar>();
        private int m_minimumBars = 3;
        private int m_maximumBars = 3;
        private Sentiment m_sentiment = Sentiment.INVALID;

        public ClosingPriceReversalRule()
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
                if (m_bars[1].Low < m_bars[0].Low
                    && m_bars[1].Close > m_bars[0].Close)
                    {
                    if (ClosesInTopQuarter(m_bars[2]))
                        m_sentiment = Sentiment.BULLISH;
                    }
                else if (m_bars[1].High >= m_bars[0].High
                         && m_bars[1].Close <= m_bars[0].Close)
                    if (ClosesInBottomQuarter(m_bars[2]))
                        m_sentiment = Sentiment.BEARISH;
                }
            }

        public Sentiment getSentiment()
            {
            return m_sentiment;
            }

        #endregion

        private bool ClosesInTopQuarter(Bar bar)
            {
            return bar.Close >= (bar.Low + (bar.High - bar.Low) * 3 / 4);
            }

        private bool ClosesInBottomQuarter(Bar bar)
            {
            return bar.Close <= (bar.Low + (bar.High - bar.Low) / 4);
            }

        }
    }
