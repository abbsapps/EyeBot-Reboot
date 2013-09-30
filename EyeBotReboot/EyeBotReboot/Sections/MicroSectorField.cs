using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyeBotReboot.Components.Neurons;

namespace EyeBotReboot.Sections
{
    public class MicroSectorField
    {
        public MicroSectorField(int fieldWidth, int fieldHeight, double fieldWidthPercent, double fieldHeightPercent, int sectorRowCount, double thresholdBase, double thresholdSpike, double thresholdDecayPercent, double thresholdDecayConstant, double signalStrength, string dendriteType)
        {
            Field = new List<Sector>();
            TemporaryFieldByLocation = new List<List<Sector>>();
            WidthPercent = fieldWidthPercent;
            HeightPercent = fieldHeightPercent;

            var counter = 0; //sonething wonky in the sector row count hanling - it doen't like numbers other than 10
            for (int i = (int)(-1 * (.5 * fieldWidth * fieldWidthPercent)); i < (int)(.5 * fieldWidth * fieldWidthPercent); i += (int)((1.0 / sectorRowCount) * fieldWidthPercent * fieldWidth))
            {
                TemporaryFieldByLocation.Add(new List<Sector>());
                for (int j = (int)(-1 * (.5 * fieldHeight * fieldHeightPercent)); j < (int)(.5 * fieldHeight * fieldHeightPercent); j += (int)((1.0 / sectorRowCount) * fieldHeightPercent * fieldWidth))
                {
                    var xLocation = i +
                                    (int)
                                    ((1.0/sectorRowCount)*fieldWidth*fieldWidthPercent -
                                     ((int) (((1.0/sectorRowCount)*fieldWidth*fieldWidthPercent)/2)));
                    var yLocation = j +
                                    (int)
                                    ((1.0/sectorRowCount)*fieldHeight*fieldHeightPercent -
                                     ((int) (((1.0/sectorRowCount)*fieldHeight*fieldHeightPercent)/2)));

                    var newMicroSector = new Sector(xLocation: xLocation, yLocation: yLocation, thresholdBase: thresholdBase, thresholdSpike: thresholdSpike, thresholdDecayPercent: thresholdDecayPercent, thresholdDecayConstant: thresholdDecayConstant, signalStrength: signalStrength, dendriteType: dendriteType);
                    TemporaryFieldByLocation[counter].Add(newMicroSector);
                    Field.Add(newMicroSector);
                }
                counter++;
            }
        }

        public List<Sector> Field { get; set; }
        public List<List<Sector>> TemporaryFieldByLocation { get; set; }
        public double WidthPercent { get; set; }
        public double HeightPercent { get; set; }

        public void NewTurn()
        {
            foreach (var sector in Field)
            {
                sector.NewTurn();
            }
        }
    }
}
