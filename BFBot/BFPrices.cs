using System;
using System.Collections.Generic;
using System.Text;

namespace BFBot
    {
    public class BfPrices
        {
        private readonly List<BfPrice> m_prices = new List<BfPrice>();

        public BfPrices(string info)
            {
            string[] parts = info.Split('~');

            if (parts.Length == 5)
                {
                BfPrice thisPrice = new BfPrice(parts[0], parts[1], parts[2], parts[3]);
                m_prices.Add(thisPrice);
                }
            else if (parts.Length == 9)
                {
                BfPrice thisPrice = new BfPrice(parts[0], parts[1], parts[2], parts[3]);
                m_prices.Add(thisPrice);
                thisPrice = new BfPrice(parts[4], parts[5], parts[6], parts[7]);
                m_prices.Add(thisPrice);
                }
            else if (parts.Length ==12)
                {
                BfPrice thisPrice = new BfPrice(parts[0], parts[1], parts[2], parts[3]);
                m_prices.Add(thisPrice);
                thisPrice = new BfPrice(parts[4], parts[5], parts[6], parts[7]);
                m_prices.Add(thisPrice);
                thisPrice = new BfPrice(parts[8], parts[9], parts[10], parts[11]);
                m_prices.Add(thisPrice);
                }
            }

        public List<BfPrice> GetPrices
            {
            get { return m_prices; }
            }
        }
    }
