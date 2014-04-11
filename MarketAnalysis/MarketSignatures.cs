using System;
using System.Collections.Generic;
using System.Text;

namespace MarketAnalysis
    {
    public class MarketSignatures
        {
        private System.Collections.Hashtable m_signatures;
        private MarketSignatures m_instance;

        private MarketSignatures()
            {
            m_signatures = new System.Collections.Hashtable();
            }

        public MarketSignatures Instance()
            {
            if(m_instance == null)
                m_instance = new MarketSignatures();
            return m_instance;
            }

        public void AddSignature(MarketSignature marketSignature)
            {
            if (m_signatures.ContainsKey(marketSignature.Signature))
                {
                MarketSignature mSig = (MarketSignature)m_signatures[marketSignature.Signature];
                mSig.IncreaseWeight();
                }
            else
                {
                m_signatures.Add(marketSignature.Signature, marketSignature);
                }
            }
        }
    }
