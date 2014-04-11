using System;
using System.Collections.Generic;
using System.Text;

namespace BFBot
    {
    public class BfbMessage
        {
        private string m_message;

        public BfbMessage()
            {
            m_message = "";
            }

        public void AddLine(string line)
            {
            m_message += line + Environment.NewLine;
            }

        public string Message
            {
            get { return m_message; }
            }

        public void Clear()
            {
            m_message = "";
            }
        }
    }
