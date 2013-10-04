using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyeBotReboot.Components.Axons;

namespace EyeBotReboot.Components.Dendrites
{
    public class PairedDendrite : IDendrite
    {
        public PairedDendrite(INeuron targetNeuron, INeuron returnNeuron, InitiationAxonTwoWay returnAxon, double selfThreshReductionMultiplier, double pairedAxonThresholdBase, double pairedAxonThresholdSpike, double pairedAxonThresholdDecayPercent, double pairedAxonThresholdDecayConstant, double pairedAxonSignalStrength, double returnDendriteThreshReductionMultiplier)
        {
            DendriteType = "paired";
            Neuron = targetNeuron;
            AxonThreshReductionMultiplier = selfThreshReductionMultiplier;
            PairedAxon = new ReturnAxon(thresholdBase: pairedAxonThresholdBase, thresholdSpike: pairedAxonThresholdSpike,
                                        dendriteThreshReductionMultiplier: returnDendriteThreshReductionMultiplier,
                                        thresholdDecayPercent: pairedAxonThresholdDecayPercent,
                                        thresholdDecayConstant: pairedAxonThresholdDecayConstant, signalStrength: pairedAxonSignalStrength,
                                        returnNeuron: returnNeuron, returnAxon: returnAxon);
        }

        public string DendriteType { get; set; }
        public INeuron Neuron { get; set; }
        public ReturnAxon PairedAxon { get; set; }
        public double AxonThreshReductionMultiplier { get; set; }
        public double IncomingCharge { get; set; }


        public void Fire()
        {
            Neuron.Charge += IncomingCharge;
            PairedAxon.Threshold -= (IncomingCharge*AxonThreshReductionMultiplier);
            IncomingCharge = 0;
        }
    }
}
