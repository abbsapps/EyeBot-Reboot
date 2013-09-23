using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyeBotReboot.Components.Dendrites
{
    public class PairedDendrite : IDendrite
    {
        public PairedDendrite(INeuron targetNeuron, INeuron returnNeuron)
        {
            DendriteType = "paired";
        }

        public string DendriteType { get; set; }
        public INeuron Neuron { get; set; }
        public IAxon PairedAxon { get; set; }
        public float AxonThreshReduction { get; set; }
    }
}
