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
                        double otherDirectionThreshReductionMultiplier,
                        double otherDirectionThresholdBase, double otherDirectionThresholdSpike,
                        double otherDirectionThresholdDecayPercent, double otherDirectionThresholdDecayConstant,
                        double otherDirectionSignalStrength,

                        double representativeThresholdBase, double representativeDirectionThresholdSpike,
                        double representativeDirectionThresholdDecayPercent,
                        double representativeDirectionThresholdDecayConstant,
                        double representativeDirectionSignalStrength)
        {
            Charge = 0;
            Axons = new List<IAxonPaired>();

            Id = Guid.NewGuid();
        }


        public double Charge { get; set; }
        public List<IAxonPaired> Axons { get; set; }

        //for testing purposes
        public Guid Id { get; set; }
        //end for testing purposes
    }
}
