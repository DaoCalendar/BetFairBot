using System;
using System.Collections.Generic;
using System.Text;

namespace BFBot
    {
    interface IBet
        {
        double Stake { get; set; }
        double Odds { get; set;}
        double Returns { get; }
        double Profit { get; }
        }
    }
