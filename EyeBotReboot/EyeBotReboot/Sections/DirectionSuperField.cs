using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyeBotReboot.Sections
{
    public class DirectionSuperField
    {
        public DirectionSuperField(List<double> directions, int fieldWidth, int fieldHeight, 
                                   double fieldWidthPercent, double fieldHeightPercent, 
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
            DirectionFields = new List<DirectionField>();
            foreach (var direction in directions)
            {
                DirectionField newDirectionField = new DirectionField(direction: direction,
                                                                      fieldWidth: fieldWidth, 
                                                                      fieldHeight: fieldHeight,
                                                                      fieldWidthPercent: fieldWidthPercent,
                                                                      fieldHeightPercent: fieldHeightPercent,
                                                                      otherDirectionThresholdBase: otherDirectionThresholdBase,
                                                                      otherDirectionThresholdSpike: otherDirectionThresholdSpike,
                                                                      otherDirectionThresholdDecayPercent: otherDirectionThresholdDecayPercent,
                                                                      otherDirectionThresholdDecayConstant: otherDirectionThresholdDecayConstant,
                                                                      otherDirectionSignalStrength: otherDirectionSignalStrength,
                                                                      representativeThresholdBase: representativeThresholdBase,
                                                                      representativeDirectionThresholdSpike: representativeDirectionThresholdSpike,
                                                                      representativeDirectionThresholdDecayPercent: representativeDirectionThresholdDecayPercent,
                                                                      representativeDirectionThresholdDecayConstant: representativeDirectionThresholdDecayConstant,
                                                                      representativeDirectionSignalStrength: representativeDirectionSignalStrength,
                                                                      laplaceFilterThresholdBase: laplaceFilterThresholdBase,
                                                                      laplaceFilterThresholdSpike: laplaceFilterThresholdSpike,
                                                                      laplaceFilterThresholdDecayPercent: laplaceFilterThresholdDecayPercent,
                                                                      laplaceFilterThresholdDecayConstant: laplaceFilterThresholdDecayConstant,
                                                                      laplaceFilterSignalStrength: laplaceFilterSignalStrength);
                DirectionFields.Add(newDirectionField);
            }
        }

        public List<DirectionField> DirectionFields { get; set; } 
    }
}
