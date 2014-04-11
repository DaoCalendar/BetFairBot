using System;
using System.Collections.Generic;
using System.Text;

namespace BFBot
    {
    public interface IPattern
        {
        void init(Security security);

        void add(Bar bar);

        Sentiment getSentiment();
        }
    }
