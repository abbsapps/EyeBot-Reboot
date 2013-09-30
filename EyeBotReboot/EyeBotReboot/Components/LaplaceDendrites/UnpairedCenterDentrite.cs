using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyeBotReboot.Components.Neurons;

namespace EyeBotReboot.Components.LaplaceDendrites
{
    public class UnpairedCenterDentrite: ILaplaceDendrite
    {
        public UnpairedCenterDentrite(LaplaceFilter targetNeuron)
        {
            Neuron = targetNeuron;
            DendriteType = "center";
        }

        public string DendriteType { get; set; }
        public LaplaceFilter Neuron { get; set; }
        public double Charge { get; set; }

        public void Fire()
        {
            Neuron.Value = Charge;
        }
    }
}
