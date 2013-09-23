using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyeBotReboot.Components.Neurons;

namespace EyeBotReboot.Sections
{
    public class ReceptorField
    {
        public ReceptorField(int fieldWidth, int fieldHeight, float focusDensity, int focusLocationX, int focusLocationY, float thresholdBase, float thresholdSpike, float thresholdDecayPercent, float thresholdDecayConstant, float signalStrength, int laplaceReach)
        {
            Field = new List<Receptor>();
            TemporaryFieldByLocation = new List<List<Receptor>>(); //might not need?
            for (int i = (int)(-1 * (.5 * fieldWidth)); i < (int)(.5 * fieldWidth); i++)
            {
                TemporaryFieldByLocation.Add(new List<Receptor>());
                for (int j = (int)(-1 * (.5 * fieldHeight)); j < (int)(.5 * fieldHeight); j++)
                {
                    var newReceptor = new Receptor(xLocation: i, yLocation: j, fieldWidth: fieldWidth, fieldHeight: fieldHeight, focusDensity: focusDensity, thresholdBase: thresholdBase, thresholdSpike: thresholdSpike, thresholdDecayPercent: thresholdDecayPercent, thresholdDecayConstant: thresholdDecayConstant, signalStrength: signalStrength, laplaceReach: laplaceReach);
                    
                    Field.Add(newReceptor);
                    TemporaryFieldByLocation[i + (int)(.5 * fieldWidth)].Add(newReceptor);
                }
            }

            EnvironmentFocusX = focusLocationX; //theoretically don't need if eye muscle localization works out as expected
            EnvironmentFocusY = focusLocationY; //theoretically don't need if eye muscle localization works out as expected
        }

        public List<Receptor> Field { get; set; }
        public List<List<Receptor>> TemporaryFieldByLocation { get; set; }
        public int EnvironmentFocusX { get; set; }
        public int EnvironmentFocusY { get; set; }

        public void NewTurn()
        {
            foreach (var receptor in Field)
            {
                receptor.NewTurn(fieldFocusX: EnvironmentFocusX, fieldFocusY: EnvironmentFocusY);
            }
        }
    }
}
