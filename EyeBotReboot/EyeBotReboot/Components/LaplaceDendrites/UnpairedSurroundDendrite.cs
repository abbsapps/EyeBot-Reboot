using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyeBotReboot.Components.Neurons;

namespace EyeBotReboot.Components.LaplaceDendrites
{
    public class UnpairedSurroundDendrite: ILaplaceDendrite
    {
        public UnpairedSurroundDendrite(LaplaceFilter targetNeuron)
        {
            Neuron = targetNeuron;
            DendriteType = "surround";
        }

        public string DendriteType { get; set; }
        public LaplaceFilter Neuron { get; set; }
        public double Charge { get; set; }

        public void Fire()
        {
            Neuron.Charge += Math.Abs(Neuron.Charge - Charge);
        }
    }
}
