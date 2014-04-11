using System;
using System.Collections.Generic;
using System.Text;

namespace BFBot
    {
    public class DoubleReversalRule : IPattern
        {
        private bool[] m_reversals = new bool[3];
        private List<Bar> m_bars = new List<Bar>();
        private int m_minimumBars = 6;
        private int m_maximumBars = 6;
        Sentiment m_sentiment = Sentiment.INVALID;

        public DoubleReversalRule()
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

                bool[] reversals = { false, false, false, false, false, false };

                int end = (m_bars.Count < 6 ? m_bars.Count : 6) -1;
                int[] complete = { 0, 0 };

                for(int n = 0; n < end; ++n)
                    {
                    Bar rn = m_bars[n];
                    Bar rn1 = m_bars[n + 1];
                    double[] high = { rn.High, rn1.High };
                    double[] low = { rn.Low, rn1.Low };
                    double[] close = { rn.Close, rn1.Close };

                    if (close[1] >= high[1] - 0.05 && close[0] <= low[0] + 0.05)
                        {
                        reversals[0] = true;
                        if (n + 1 > complete[0])
                            complete[0] = n + 1;
                        }
                    else if(close[0] >= high[0] - 0.05 && close[1] <= low[0] + 0.05)
                        {
                        reversals[3] = true;
                        if (n + 1 > complete[1])
                            complete[1] = n + 1;
                        }

                    if (low[1] < low[0] && close[1] > close[0])
                        {
                        reversals[1] = true;
                        if(n + 1 > complete[0])
                            complete[0] = n + 1;
                        }
                    else if(high[1] >= high[0] && close[1] <= close[0])
                        {
                        reversals[4] = true;
                        if (n + 1 > complete[1])
                            complete[1] = n + 1;
                        }

                    if (high[0] < high[1] && low[0] > low[1])
                        {
                        if (close[1] >= high[0])
                            {
                            reversals[2] = true;
                            if (n + 1 > complete[0])
                                complete[0] = n + 1;
                            }
                        }
                    else if (high[0] < high[1] && low[0] > low[1])
                        {
                        if (close[1] <= low[0])
                            {
                            reversals[5] = true;
                            if (n + 1 > complete[1])
                                complete[1] = n + 1;
                            }
                        }

                    if ((reversals[0] && (reversals[1] || reversals[2])) || (reversals[1] && (reversals[0] || reversals[2])) || (reversals[2] && (reversals[0] || reversals[1])))
                        {
                        reversals[0] = reversals[3];
                        reversals[1] = reversals[1];
                        reversals[2] = reversals[2];
                        m_sentiment = Sentiment.BULLISH;
                        return;
                        }
                    else if ((reversals[3] && (reversals[4] || reversals[5])) || (reversals[4] && (reversals[3] || reversals[5])) || (reversals[5] && (reversals[3] || reversals[4])))
                        {
                        reversals[0] = reversals[3];
                        reversals[1] = reversals[4];
                        reversals[2] = reversals[5];
                        m_sentiment = Sentiment.BEARISH;
                        return;
                        }
                    else
                        reversals[0] = reversals[1] = reversals[2] = false;
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
