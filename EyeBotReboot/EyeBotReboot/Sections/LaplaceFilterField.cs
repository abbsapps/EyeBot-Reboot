using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyeBotReboot.Components.Neurons;

namespace EyeBotReboot.Sections
{
    public class LaplaceFilterField
    {
        public LaplaceFilterField(int fieldWidth, int fieldHeight, float focusDensity, float thresholdBase, float thresholdSpike, float thresholdDecayPercent, float thresholdDecayConstant, float signalStrength)
        {
            Field = new List<LaplaceFilter>();
            TemporaryFieldByLocation = new List<List<LaplaceFilter>>(); //might not need?
            for (int i = (int)(-1 * (.5 * fieldWidth)); i < (int)(.5 * fieldWidth); i++)
            {
                TemporaryFieldByLocation.Add(new List<LaplaceFilter>());
                for (int j = (int)(-1 * (.5 * fieldHeight)); j < (int)(.5 * fieldHeight); j++)
                {
                    var newLaplaceFilter = new LaplaceFilter(xLocation: i, yLocation: j, thresholdBase: thresholdBase, thresholdSpike: thresholdSpike, thresholdDecayPercent: thresholdDecayPercent, thresholdDecayConstant: thresholdDecayConstant, signalStrength: signalStrength);
                    Field.Add(newLaplaceFilter);
                    TemporaryFieldByLocation[i + (int)(.5 * fieldWidth)].Add(newLaplaceFilter);
                }
            }
        }

        public List<LaplaceFilter> Field { get; set; }
        public List<List<LaplaceFilter>> TemporaryFieldByLocation { get; set; }

        public void NewTurn()
        {
            foreach (var laplaceFilter in Field)
            {
                laplaceFilter.NewTurn();
            }
        }
    }
}
