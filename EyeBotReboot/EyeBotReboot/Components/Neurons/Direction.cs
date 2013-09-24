using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyeBotReboot.Components.Neurons
{
    public class Direction: INeuron
    {
                public Direction(float direction,
                              float otherDirectionThresholdBase, float otherDirectionThresholdSpike,
                              float otherDirectionThresholdDecayPercent, float otherDirectionThresholdDecayConstant,
                              float otherDirectionSignalStrength,

                              float representativeThresholdBase, float representativeDirectionThresholdSpike,
                              float representativeDirectionThresholdDecayPercent,
                              float representativeDirectionThresholdDecayConstant,
                              float representativeDirectionSignalStrength,

                              float laplaceFilterThresholdBase, float laplaceFilterThresholdSpike,
                              float laplaceFilterThresholdDecayPercent, float laplaceFilterThresholdDecayConstant,
                              float laplaceFilterSignalStrength)
        {
        }
        public float Charge { get; set; }
    }
}
