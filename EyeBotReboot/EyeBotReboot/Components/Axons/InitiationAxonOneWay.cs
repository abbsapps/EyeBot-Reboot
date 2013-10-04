using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyeBotReboot.Components.Dendrites;

namespace EyeBotReboot.Components.Axons
{
    public class InitiationAxonOneWay: IAxonUnpaired
    {
        public InitiationAxonOneWay(double thresholdBase, double thresholdSpike, double thresholdDecayPercent, double thresholdDecayConstant, double signalStrength, string dendriteType, INeuron targetNeuron)
        {
            ThresholdBase = thresholdBase;
            ThresholdSpike = thresholdSpike;
            ThresholdDecayPercent = thresholdDecayPercent;
            ThresholdDecayConstant = thresholdDecayConstant;
            Threshold = thresholdBase;
            SignalStrength = signalStrength;
            Dendrite = new UnpairedDendrite(targetNeuron);

        }

        public double ThresholdBase { get; set; }
        public double ThresholdSpike { get; set; }
        public double ThresholdDecayPercent { get; set; }
        public double ThresholdDecayConstant { get; set; }
        public double Threshold { get; set; }
        public double SignalStrength { get; set; }
        public UnpairedDendrite Dendrite { get; set; }

        public void Fire()
        {
            Dendrite.IncomingCharge += SignalStrength;
            Threshold += ThresholdSpike;
            Dendrite.Fire();
        }

        public void NewTurn()
        {
            if (Threshold > ThresholdBase)
            {
                Threshold -= ((ThresholdDecayPercent*(Threshold - ThresholdBase)) + ThresholdDecayConstant);
                if (Threshold < ThresholdBase)
                {
                    Threshold = ThresholdBase;
                }
            }
            else if (Threshold < ThresholdBase)
            {
                Threshold += ((ThresholdDecayPercent * (Threshold - ThresholdBase)) + ThresholdDecayConstant);
                if (Threshold > ThresholdBase)
                {
                    Threshold = ThresholdBase;
                }
            }
        }


    }
}
