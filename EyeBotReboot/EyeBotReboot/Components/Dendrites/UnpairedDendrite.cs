using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyeBotReboot.Components.Dendrites
{
    public class UnpairedDendrite : IDendrite
    {
        public UnpairedDendrite(INeuron targetNeuron)
        {
            Neuron = targetNeuron;
            DendriteType = "unpaired";
        }

        public string DendriteType { get; set; }
        public INeuron Neuron { get; set; }
        public float IncomingCharge { get; set; }

        public void Fire()
        {
            Neuron.Charge += IncomingCharge;
            IncomingCharge = 0;
        }
    }
}
