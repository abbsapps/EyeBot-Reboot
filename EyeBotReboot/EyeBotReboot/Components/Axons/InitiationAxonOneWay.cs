using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyeBotReboot.Components.Dendrites;

namespace EyeBotReboot.Components.Axons
{
    public class InitiationAxonOneWay: IAxon
    {
        public InitiationAxonOneWay(float thresholdBase, float thresholdSpike, float thresholdDecayPercent, float thresholdDecayConstant, float signalStrength, string dendriteType, INeuron targetNeuron)
        {
            ThresholdBase = thresholdBase;
            ThresholdSpike = thresholdSpike;
            ThresholdDecayPercent = thresholdDecayPercent;
            ThresholdDecayConstant = thresholdDecayConstant;
            Threshold = thresholdBase;
            SignalStrength = signalStrength;
            Dendrite = new UnpairedDendrite(targetNeuron);

        }

        public float ThresholdBase { get; set; }
        public float ThresholdSpike { get; set; }
        public float ThresholdDecayPercent { get; set; }
        public float ThresholdDecayConstant { get; set; }
        public float Threshold { get; set; }
        public float SignalStrength { get; set; }
        public UnpairedDendrite Dendrite { get; set; }

        public void Fire()
        {
            Dendrite.IncomingCharge += SignalStrength;
            Threshold += ThresholdSpike;
            Dendrite.Fire();
        }


    }
}
