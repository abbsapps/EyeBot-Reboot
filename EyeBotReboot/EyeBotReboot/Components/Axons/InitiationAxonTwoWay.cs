using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyeBotReboot.Components.Dendrites;

namespace EyeBotReboot.Components.Axons
{
    public class InitiationAxonTwoWay: IAxonPaired
    {
        public InitiationAxonTwoWay(double outboundThresholdBase, double outboundThresholdSpike, double outboundThresholdDecayPercent, double outboundThresholdDecayConstant, double outboundSignalStrength, string outboundDendriteType, double outboundDendriteThreshReductionMultiplier, double inboundThresholdBase, double inboundThresholdSpike, double inboundThresholdDecayPercent, double inboundThresholdDecayConstant, double inboundSignalStrength, string inboundDendriteType, double inboundDendriteThreshReductionMultiplier, INeuron targetNeuron, INeuron returnNeuron)
        {
            ThresholdBase = outboundThresholdBase;
            ThresholdSpike = outboundThresholdSpike;
            ThresholdDecayPercent = outboundThresholdDecayPercent;
            ThresholdDecayConstant = outboundThresholdDecayConstant;
            Threshold = outboundThresholdBase;
            SignalStrength = outboundSignalStrength;
            Dendrite = new PairedDendrite(targetNeuron: targetNeuron, returnNeuron: returnNeuron, returnAxon: this,
                                          selfThreshReductionMultiplier: outboundDendriteThreshReductionMultiplier,
                                          pairedAxonThresholdBase: inboundThresholdBase, pairedAxonThresholdSpike: inboundThresholdSpike,
                                          pairedAxonThresholdDecayPercent: inboundThresholdDecayPercent,
                                          pairedAxonThresholdDecayConstant: inboundThresholdDecayConstant,
                                          pairedAxonSignalStrength: inboundSignalStrength, returnDendriteThreshReductionMultiplier: inboundDendriteThreshReductionMultiplier);
        }
        public double ThresholdBase { get; set; }
        public double ThresholdSpike { get; set; }
        public double ThresholdDecayPercent { get; set; }
        public double ThresholdDecayConstant { get; set; }
        public double Threshold { get; set; }
        public double SignalStrength { get; set; }

        public PairedDendrite Dendrite { get; set; }

        public void Fire()//IMPORTANT NOTE: remember to add in paired axon thresh lowering here.  Complication is that this should actually be able to lower the axon thresh to sub-thresh-base values, which means I will have to change the logic of paired axons to enable sub-base-threshold thresholds.  To address this maybe add a "ThreshMinimum" property to paired axons?
        {
         
        }
    }
}
