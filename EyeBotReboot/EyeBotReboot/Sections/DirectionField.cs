using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyeBotReboot.Components.Neurons;

namespace EyeBotReboot.Sections
{
    public class DirectionField
    {
        public DirectionField(float direction,
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


        public List<Direction> DirectionNeurons { get; set; }
    }
}
