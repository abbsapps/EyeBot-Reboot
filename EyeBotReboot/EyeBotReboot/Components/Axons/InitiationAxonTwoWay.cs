using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyeBotReboot.Components.Dendrites;

namespace EyeBotReboot.Components.Axons
{
    public class InitiationAxonTwoWay: IAxonPaired
    {
        public InitiationAxonTwoWay(double thresholdBase, double thresholdSpike, double thresholdDecayPercent, double thresholdDecayConstant, double signalStrength, string dendriteType, INeuron targetNeuron, INeuron returnNeuron, double dendriteThreshReductionMultiplier)
        {
            ThresholdBase = thresholdBase;
            ThresholdSpike = thresholdSpike;
            ThresholdDecayPercent = thresholdDecayPercent;
            ThresholdDecayConstant = thresholdDecayConstant;
            Threshold = thresholdBase;
            SignalStrength = signalStrength;
            Dendrite = new PairedDendrite(targetNeuron: targetNeuron, returnNeuron: returnNeuron, returnAxon: this,
                                          threshReductionMultiplier: dendriteThreshReductionMultiplier,
                                          thresholdBase: thresholdBase, thresholdSpike: thresholdSpike,
                                          thresholdDecayPercent: thresholdDecayPercent,
                                          thresholdDecayConstant: thresholdDecayConstant,
                                          signalStrength: signalStrength);
        }
        public double ThresholdBase { get; set; }
        public double ThresholdSpike { get; set; }
        public double ThresholdDecayPercent { get; set; }
        public double ThresholdDecayConstant { get; set; }
        public double Threshold { get; set; }
        public double SignalStrength { get; set; }

        public PairedDendrite Dendrite { get; set; }

        public void Fire()
        {
            
        }
    }
}
