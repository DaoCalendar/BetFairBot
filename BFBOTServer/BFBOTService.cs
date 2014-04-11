using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using BFBot;

namespace BFBOTServer
{
    public partial class BFBOTService : ServiceBase
    {
        private MarketTracker m_marketTracker;

        public BFBOTService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            if (m_marketTracker == null)
                m_marketTracker = MarketTracker.Instance;
        }

        protected override void OnStop()
        {
            
        }

        
    }
}
