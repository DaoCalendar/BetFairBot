using System;
using System.Collections.Generic;
using System.Text;

namespace BFForcaster
    {
    public class ProcessLayer
        {
        private List<InputLayer> m_layers;
        
        public ProcessLayer(InputLayer inputLayer)
            {
            m_layers = new List<InputLayer>();
            m_layers.Add(inputLayer);
            }

        public void UpdateLayer(InputLayer inputLayer)
            {
            m_layers.Add(inputLayer);
            }
        }
    }
