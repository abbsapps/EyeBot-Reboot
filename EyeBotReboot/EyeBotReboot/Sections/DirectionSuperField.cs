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
                                   double otherDirectionThreshReductionMultiplier,
                                   double otherDirectionThresholdBase, double otherDirectionThresholdSpike,
                                   double otherDirectionThresholdDecayPercent, double otherDirectionThresholdDecayConstant,
                                   double otherDirectionSignalStrength,

                                   double representativeThresholdBase, double representativeDirectionThresholdSpike,
                                   double representativeDirectionThresholdDecayPercent,
                                   double representativeDirectionThresholdDecayConstant,
                                   double representativeDirectionSignalStrength)
        {
            DirectionFields = new List<DirectionField>();
            foreach (var direction in directions)
            {
                DirectionField newDirectionField = new DirectionField(direction: direction,
                                                                      fieldWidth: fieldWidth, 
                                                                      fieldHeight: fieldHeight,
                                                                      fieldWidthPercent: fieldWidthPercent,
                                                                      fieldHeightPercent: fieldHeightPercent,
                                                                      otherDirectionThreshReductionMultiplier: otherDirectionThreshReductionMultiplier,
                                                                      otherDirectionThresholdBase: otherDirectionThresholdBase,
                                                                      otherDirectionThresholdSpike: otherDirectionThresholdSpike,
                                                                      otherDirectionThresholdDecayPercent: otherDirectionThresholdDecayPercent,
                                                                      otherDirectionThresholdDecayConstant: otherDirectionThresholdDecayConstant,
                                                                      otherDirectionSignalStrength: otherDirectionSignalStrength,
                                                                      representativeThresholdBase: representativeThresholdBase,
                                                                      representativeDirectionThresholdSpike: representativeDirectionThresholdSpike,
                                                                      representativeDirectionThresholdDecayPercent: representativeDirectionThresholdDecayPercent,
                                                                      representativeDirectionThresholdDecayConstant: representativeDirectionThresholdDecayConstant,
                                                                      representativeDirectionSignalStrength: representativeDirectionSignalStrength);
                DirectionFields.Add(newDirectionField);
            }
        }

        public List<DirectionField> DirectionFields { get; set; } 

        public void NewTurn()
        {
            foreach (var directionField in DirectionFields)
            {
                directionField.NewTurn();
            }   
        }
    }
}
