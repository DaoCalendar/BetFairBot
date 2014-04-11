using System;
using System.Collections.Generic;
using System.Text;

namespace BFForcaster
    {
    public class MovementPatterns
        {
        private Dictionary<int, MovementPattern> m_items;

        public MovementPatterns()
            {
            m_items = new Dictionary<int, MovementPattern>();
            }

        public void AddPattern(MovementPattern movementPattern)
            {
            if (m_items.ContainsKey(movementPattern.MovementPatternKey))
                {
                MovementPattern existingPattern = m_items[movementPattern.MovementPatternKey];
                existingPattern.AddWeight();
                }
            else
                {
                m_items.Add(movementPattern.MovementPatternKey, movementPattern);
                }
            }

        public int PredictNextMovement(MovementPattern movementPattern)
            {
            return m_items[movementPattern.MovementPatternKey].NextMovement;
            }
        }
    }
