using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyeBotReboot.Components.Dendrites;

namespace EyeBotReboot.Components.Axons
{
    public class InitiationAxonTwoWay: IAxon
    {
        public InitiationAxonTwoWay(double thresholdBase, double thresholdSpike, double thresholdDecayPercent, double thresholdDecayConstant, double signalStrength, string dendriteType, INeuron targetNeuron, INeuron returnNeuron)
        {
            ThresholdBase = thresholdBase;
            ThresholdSpike = thresholdSpike;
            ThresholdDecayPercent = thresholdDecayPercent;
            ThresholdDecayConstant = thresholdDecayConstant;
            Threshold = thresholdBase;
            SignalStrength = signalStrength;
            PairedDendrite = new PairedDendrite(targetNeuron: targetNeuron, returnNeuron: returnNeuron, returnAxon: this,
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

        public PairedDendrite PairedDendrite { get; set; }
    }
}
