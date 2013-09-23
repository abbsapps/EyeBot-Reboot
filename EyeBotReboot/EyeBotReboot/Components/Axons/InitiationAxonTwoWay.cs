using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyeBotReboot.Components.Axons
{
    public class InitiationAxonTwoWay: IAxon
    {
        public InitiationAxonTwoWay(float thresholdBase, float thresholdSpike, float thresholdDecayPercent, float thresholdDecayConstant, float signalStrength, string dendriteType, INeuron targetNeuron, INeuron returnNeuron)
        {
            ThresholdBase = thresholdBase;
            ThresholdSpike = thresholdSpike;
            ThresholdDecayPercent = thresholdDecayPercent;
            ThresholdDecayConstant = thresholdDecayConstant;
            Threshold = thresholdBase;
            SignalStrength = signalStrength;
        }
        public float ThresholdBase { get; set; }
        public float ThresholdSpike { get; set; }
        public float ThresholdDecayPercent { get; set; }
        public float ThresholdDecayConstant { get; set; }
        public float Threshold { get; set; }
        public float SignalStrength { get; set; }

        public IDendrite PairedDendrite { get; set; }
    }
}
