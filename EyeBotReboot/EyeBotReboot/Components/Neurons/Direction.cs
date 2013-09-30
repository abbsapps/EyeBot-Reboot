using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyeBotReboot.Components.Neurons
{
    public class Direction: INeuron
    {
        public Direction(double direction, //does the actual direction neuron constructor need to know it's direction? I feel like the connections between neurons in a field will only be established after the entire field has been formed, at the DirectionField level
                        double otherDirectionThresholdBase, double otherDirectionThresholdSpike,
                        double otherDirectionThresholdDecayPercent, double otherDirectionThresholdDecayConstant,
                        double otherDirectionSignalStrength,

                        double representativeThresholdBase, double representativeDirectionThresholdSpike,
                        double representativeDirectionThresholdDecayPercent,
                        double representativeDirectionThresholdDecayConstant,
                        double representativeDirectionSignalStrength,

                        double laplaceFilterThresholdBase, double laplaceFilterThresholdSpike,
                        double laplaceFilterThresholdDecayPercent, double laplaceFilterThresholdDecayConstant,
                        double laplaceFilterSignalStrength)
        {
            Charge = 0;
            Axons = new List<IAxon>();

            Id = Guid.NewGuid();
        }


        public double Charge { get; set; }
        public List<IAxon> Axons { get; set; }

        //for testing purposes
        public Guid Id { get; set; }
        //end for testing purposes
    }
}
