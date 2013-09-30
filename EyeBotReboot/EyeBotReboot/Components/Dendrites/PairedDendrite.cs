using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyeBotReboot.Components.Axons;

namespace EyeBotReboot.Components.Dendrites
{
    public class PairedDendrite : IDendrite
    {
        public PairedDendrite(INeuron targetNeuron, INeuron returnNeuron, InitiationAxonTwoWay returnAxon, double thresholdBase, double thresholdSpike, double thresholdDecayPercent, double thresholdDecayConstant, double signalStrength)
        {
            DendriteType = "paired";
            Neuron = targetNeuron;
            PairedAxon = new ReturnAxon(thresholdBase: thresholdBase, thresholdSpike: thresholdSpike,
                                        thresholdDecayPercent: thresholdDecayPercent,
                                        thresholdDecayConstant: thresholdDecayConstant, signalStrength: signalStrength,
                                        returnNeuron: returnNeuron, returnAxon: returnAxon);
        }

        public string DendriteType { get; set; }
        public INeuron Neuron { get; set; }
        public IAxon PairedAxon { get; set; }
        public double AxonThreshReduction { get; set; }
    }
}
