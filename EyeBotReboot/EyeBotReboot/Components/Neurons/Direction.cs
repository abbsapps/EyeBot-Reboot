using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyeBotReboot.Components.Axons;

namespace EyeBotReboot.Components.Neurons
{
    public class Direction: INeuron
    {
        public Direction(double direction, //does the actual direction neuron constructor need to know it's direction? I feel like the connections between neurons in a field will only be established after the entire field has been formed, at the DirectionField level
                        DirectionRepresentative directionRepresentativeNeuron,

                        double representativeThresholdBase, double representativeDirectionThresholdSpike,
                        double representativeDirectionThresholdDecayPercent,
                        double representativeDirectionThresholdDecayConstant,
                        double representativeDirectionSignalStrength)
        {
            Charge = 0;
            Axons = new List<IAxonPaired>();
            Axons.Add(new InitiationAxonTwoWay(outboundThresholdBase: representativeThresholdBase,
                                               //heavily flawed because of local decisions.  At this point I'm actually pretty sure I want the axon to be one-way, but the refactor to do that is complicated.  Gross local hacks are current 'fix' for that
                                               outboundThresholdSpike: representativeDirectionThresholdSpike,
                                               outboundThresholdDecayPercent:
                                                   representativeDirectionThresholdDecayPercent,
                                               outboundThresholdDecayConstant:
                                                   representativeDirectionThresholdDecayConstant,
                                               outboundSignalStrength: representativeDirectionSignalStrength,
                                               outboundDendriteType: "paired",
                                               outboundDendriteThreshReductionMultiplier: 0,
                                               inboundThresholdBase: 1000000000, inboundThresholdSpike: 0,
                                               inboundThresholdDecayPercent: 0, inboundThresholdDecayConstant: 0,
                                               inboundSignalStrength: 0, inboundDendriteType: "paired",
                                               inboundDendriteThreshReductionMultiplier: 0,
                                               targetNeuron: directionRepresentativeNeuron, returnNeuron: this));

            Id = Guid.NewGuid();
        }


        public double Charge { get; set; }
        public List<IAxonPaired> Axons { get; set; }

        public void NewTurn()
        {
            foreach (var axon in Axons)
            {
                if (Charge > axon.Threshold)
                {
                    axon.Fire();
                    Charge -= axon.SignalStrength;
                }
            }

            foreach (var axon in Axons)
            {
                axon.NewTurn();
            }
        }

        //for testing purposes
        public Guid Id { get; set; }
        //end for testing purposes
    }
}
