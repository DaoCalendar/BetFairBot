using System;
using System.Collections.Generic;
using System.Text;

namespace MarketAnalysis
    {
    public class MarketSignature
        {
        private string m_signature;
        private int[] m_values;
        private int m_weight;
        private int m_watchValue;

        public MarketSignature(int[] values, int watchValue)
            {
            m_values = values;
            m_watchValue = watchValue;
            foreach (int i in m_values)
                m_signature += i.ToString();
            m_signature += m_watchValue.ToString();
            }

        public string Signature
            {
            get { return m_signature; }
            }

        public void IncreaseWeight()
            {
            m_weight++;
            }
        }
    }
