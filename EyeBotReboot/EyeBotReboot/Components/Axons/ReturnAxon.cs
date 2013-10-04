using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyeBotReboot.Components.Dendrites;

namespace EyeBotReboot.Components.Axons
{
    public class ReturnAxon : IAxon
    {
        public ReturnAxon(double thresholdBase, double thresholdSpike, double thresholdDecayPercent, double thresholdDecayConstant, double signalStrength, INeuron returnNeuron, InitiationAxonTwoWay returnAxon, double dendriteThreshReductionMultiplier) //current thinking is that returnAxons will ALWAYS be paired with a PairedDendrite since a returning axon by nature implies a feedback loop, since it itself must be tied to a PairedDendrite created from the InitiationAxon
        {
            ThresholdBase = thresholdBase;
            ThresholdSpike = thresholdSpike;
            ThresholdDecayPercent = thresholdDecayPercent;
            ThresholdDecayConstant = thresholdDecayConstant;
            Threshold = thresholdBase;
            SignalStrength = signalStrength;
            Dendrite = new ReturnPairedDendrite(pairedAxon: returnAxon, returnNeuron: returnNeuron,
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

        public ReturnPairedDendrite Dendrite { get; set; }

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
                Threshold -= ((ThresholdDecayPercent * (Threshold - ThresholdBase)) + ThresholdDecayConstant);
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
