using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyeBotReboot.Sections
{
    public class DirectionSuperField
    {
        public DirectionSuperField(List<float> directions,
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

        public List<DirectionField> DirectionFields { get; set; } 
    }
}
