using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyeBotReboot.Components.Axons;

namespace EyeBotReboot.Components.Dendrites
{
    public class ReturnPairedDendrite: IDendrite
    {
        public ReturnPairedDendrite(InitiationAxonTwoWay pairedAxon, double threshReductionMultiplier, INeuron returnNeuron, double thresholdBase, double thresholdSpike, double thresholdDecayPercent, double thresholdDecayConstant, double signalStrength)
        {
            DendriteType = "paired";
            Neuron = returnNeuron;
            PairedAxon = pairedAxon;
        }

        public string DendriteType { get; set; }
        public INeuron Neuron { get; set; }
        public InitiationAxonTwoWay PairedAxon { get; set; }
        public double AxonThreshReductionMultiplier { get; set; }
        public double IncomingCharge { get; set; }

        public void Fire()
        {
            Neuron.Charge += IncomingCharge;
            PairedAxon.Threshold -= (IncomingCharge * AxonThreshReductionMultiplier);
            IncomingCharge = 0;
        }
    }
}
