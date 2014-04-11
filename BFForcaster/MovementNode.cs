using System;
using System.Collections.Generic;
using System.Text;

namespace BFForcaster
    {
    public class MovementNode
        {
        private LinkedListNode<int> m_next;
        private LinkedListNode<int> m_previous;
        private string m_signature;

        public MovementNode(LinkedListNode<int> previous, LinkedListNode<int> next, List<int> items)
            {
            CalculateSignature(items);
            }

        private void CalculateSignature(List<int> items)
            {
            foreach (int i in items)
                m_signature += i.ToString();
            }

        public LinkedListNode<int> Next
            {
            get { return m_next; }
            }

        public LinkedListNode<int> Previous
            {
            get { return m_previous; }
            }

        public string Signature
            {
            get { return m_signature; }
            }
        }
    }
