using System;
using System.Collections.Generic;
using System.Text;

namespace BFBot
    {
    public class Sentiment
        {
        public static Sentiment INVALID = new Sentiment(-1);
        public static Sentiment NEUTRAL = new Sentiment(0);
        public static Sentiment BULLISH = new Sentiment(1);
        public static Sentiment BEARISH = new Sentiment(2);
        private int m_ordinal;

        private Sentiment(int ordinal)
            {
            this.m_ordinal = ordinal;
            }

        public bool Equals(object o)
            {
            if(o == null) // || !(o instanceof Sentiment))
                return false;
            else
            return m_ordinal == ((Sentiment)o).m_ordinal;
            }

        public int HasCode()
            {
            return m_ordinal;
            }
        }
    }
