using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace BetFairInterface
    {
    class BFMarketParser
        {
        private System.Collections.Generic.List<BFRunnerInfo> runners = new List<BFRunnerInfo>();
        public BFMarketParser(string market)
            {
            BFMarket bfMarket = new BFMarket(market);
            }
        }
    }
