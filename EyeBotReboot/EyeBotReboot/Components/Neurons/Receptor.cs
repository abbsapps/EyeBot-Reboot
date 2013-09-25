using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using EyeBotReboot.Components.Axons;

namespace EyeBotReboot.Components.Neurons
{
    public class Receptor: INeuron
    {
        public Receptor(int xLocation, int yLocation, int fieldWidth, int fieldHeight, float focusDensity, float thresholdBase, float thresholdSpike, float thresholdDecayPercent, float thresholdDecayConstant, float signalStrength, int laplaceReach)
        {
            Axons = new List<ReceptorAxon>();
            Charge = 0;
            XLocation = xLocation;
            YLocation = yLocation;
            var distanceFromFocus = Math.Sqrt((XLocation*XLocation) + (YLocation*YLocation));
            var distanceRatio = distanceFromFocus/
                                Math.Sqrt((fieldWidth/2)*(fieldWidth/2) + (fieldHeight/2)*(fieldHeight/2));
            FireChance = (float) Math.Pow(distanceRatio, focusDensity);
            Axons.Add(new ReceptorAxon(dendriteType: "center", targetNeuron: GlobalLayersKnowledge.LaplaceFilterField.TemporaryFieldByLocation[(int)((.5 * fieldWidth) + xLocation)][(int)((.5 * fieldHeight) + yLocation)])); //CHECK THE LOGIC ON THIS INDEX LOCATION
            for (int i = -1 * laplaceReach; i < laplaceReach; i++)
            {
                for (int j = -1 * laplaceReach; j < laplaceReach; j++)
                {
                    if (!(i == 0 && j == 0) && !(Math.Abs(xLocation) >= .5 * fieldWidth - (laplaceReach - 1) || Math.Abs(yLocation) >= .5 * fieldHeight - (laplaceReach - 1)))
                    {
                        Axons.Add(new ReceptorAxon(dendriteType: "surround", targetNeuron: GlobalLayersKnowledge.LaplaceFilterField.TemporaryFieldByLocation[(int)((.5 * fieldWidth) + xLocation + i)][(int)((.5 * fieldHeight) + yLocation + j)]));
                    }
                }
            }
        }

        public int XLocation { get; set; } //theoretically don't need if eye muscle localization works out as expected
        public int YLocation { get; set; } //theoretically don't need if eye muscle localization works out as expected
        public float Charge { get; set; }
        public float FireChance { get; set; }
        public List<ReceptorAxon> Axons { get; set; }

        public void NewTurn(int fieldFocusX, int fieldFocusY)
        {
            if (GlobalLayersKnowledge.Randomer.NextDouble() > FireChance && !(XLocation + fieldFocusX > GlobalLayersKnowledge.Environment.Width - 1 || XLocation + fieldFocusX < 0 || YLocation + fieldFocusY > GlobalLayersKnowledge.Environment.Height - 1 || YLocation + fieldFocusY < 0))
            {
                Fire(fieldFocusX: fieldFocusX, fieldFocusY: fieldFocusY);
            }
        }

        //hack below
        public void Move(int fieldFocusX, int fieldFocusY)
        {
            if (!(XLocation + fieldFocusX > GlobalLayersKnowledge.Environment.Width - 1 || XLocation + fieldFocusX < 0 || YLocation + fieldFocusY > GlobalLayersKnowledge.Environment.Height - 1 || YLocation + fieldFocusY < 0))
            {
                Fire(fieldFocusX: fieldFocusX, fieldFocusY: fieldFocusY);
            }
        }
        //end hack

        public void Fire(int fieldFocusX, int fieldFocusY)
        {
            var environmentInput = GlobalLayersKnowledge.Environment.GetPixel(XLocation + fieldFocusX,
                                                                              YLocation + fieldFocusY).GetBrightness();
            //GlobalLayersKnowledge.Perception.SetPixel(XLocation + fieldFocusX, YLocation + fieldFocusY, );
            foreach (var axon in Axons) //note that this breaks the rule of only firing if neuron charge exceeds axon thresh.  However receptors are very different from further-back neurons and in this case transfer a Charge instead of a charge.  This may be a hack.  I will look deeper into it later
            {
                axon.BrightnessCharge = environmentInput;
                axon.Fire();
            }
        }
    }
}
