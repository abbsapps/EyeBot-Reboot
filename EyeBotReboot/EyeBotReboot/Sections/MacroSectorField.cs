using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyeBotReboot.Components.Neurons;

namespace EyeBotReboot.Sections
{
    public class MacroSectorField
    {
        public MacroSectorField(int fieldWidth, int fieldHeight, int sectorRowCount, float thresholdBase, float thresholdSpike, float thresholdDecayPercent, float thresholdDecayConstant, float signalStrength, string dendriteType)
        {
            Field = new List<Sector>();
            TemporaryFieldByLocation = new List<List<Sector>>();

            var counter = 0;
            for (int i = (int)(-1 * (.5 * fieldWidth)); i < (int)(.5 * fieldWidth); i += (int)((1.0/sectorRowCount) * fieldWidth))
            {
                TemporaryFieldByLocation.Add(new List<Sector>());
                for (int j = (int)(-1 * (.5 * fieldHeight)); j < (int)(.5 * fieldHeight); j = j + (int)((1.0/sectorRowCount) * fieldHeight))
                {
                    var xLocation = i +
                                    (int)
                                    ((1.0/sectorRowCount)*fieldWidth - ((int) (((1.0/sectorRowCount)*fieldWidth)/2)));
                    var yLocation = j +
                                    (int)
                                    ((1.0/sectorRowCount)*fieldHeight - ((int) (((1.0/sectorRowCount)*fieldHeight)/2)));

                    var newMacroSector = new Sector(xLocation: xLocation, yLocation: yLocation, thresholdBase: thresholdBase, thresholdSpike: thresholdSpike, thresholdDecayPercent: thresholdDecayPercent, thresholdDecayConstant: thresholdDecayConstant, signalStrength: signalStrength, dendriteType: dendriteType);
                    TemporaryFieldByLocation[counter].Add(newMacroSector);
                    Field.Add(newMacroSector);
                }
                counter++;
            }
        }

        public List<Sector> Field { get; set; }
        public List<List<Sector>> TemporaryFieldByLocation { get; set; }

        public void NewTurn()
        {
            foreach (var sector in Field)
            {
                //sector.NewTurn();
            }
        }
    }
}
