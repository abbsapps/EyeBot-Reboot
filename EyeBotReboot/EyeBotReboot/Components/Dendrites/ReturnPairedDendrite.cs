using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyeBotReboot.Components.Axons;

namespace EyeBotReboot.Components.Dendrites
{
    public class ReturnPairedDendrite
    {
        public ReturnPairedDendrite(InitiationAxonTwoWay pairedAxon, INeuron returnNeuron, double thresholdBase, double thresholdSpike, double thresholdDecayPercent, double thresholdDecayConstant, double signalStrength)
        {
            DendriteType = "paired";
            Neuron = returnNeuron;
            PairedAxon = pairedAxon;
        }

        public string DendriteType { get; set; }
        public INeuron Neuron { get; set; }
        public IAxon PairedAxon { get; set; }
        public double AxonThreshReduction { get; set; }
    }
}
