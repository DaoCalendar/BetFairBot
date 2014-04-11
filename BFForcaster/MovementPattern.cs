using System;
using System.Collections.Generic;
using System.Text;

namespace BFForcaster
    {
    public class MovementPattern
        {
        private int m_movementPatternKey;
        private int m_nextMovement;
        private int m_weight;

        public MovementPattern(int pattern, int nextMovement)
            {
            m_movementPatternKey = pattern;
            m_nextMovement = nextMovement;
            m_weight = 0;
            }

        public int MovementPatternKey
            {
            get { return m_movementPatternKey; }
            }

        public int NextMovement
            {
            get { return m_nextMovement; }
            }

        public void AddWeight()
            {
            m_weight++;
            }
        }
    }
