using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyeBotReboot.Components.Axons
{
    public class ReturnAxon : IAxon
    {
        public ReturnAxon(float thresholdBase, float thresholdSpike, float thresholdDecayPercent, float thresholdDecayConstant, float signalStrength, string signalType, INeuron returnNeuron) //current thinking is that returnAxons will ALWAYS be paired with a PairedDendrite since a returning axon by nature implies a feedback loop, since it itself must be tied to a PairedDendrite created from the InitiationAxon
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
