using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using EyeBotReboot.Components.Axons;

namespace EyeBotReboot.Components.Neurons
{
    public class LaplaceFilter: INeuron
    {
        public LaplaceFilter(int xLocation, int yLocation, float thresholdBase, float thresholdSpike, float thresholdDecayPercent, float thresholdDecayConstant, float signalStrength)
        {
            Axons = new List<InitiationAxonOneWay>();
            Charge = 0;
            XLocation = xLocation;
            YLocation = yLocation;
            var comparitiveXLocation = GlobalLayersKnowledge.MicroSectorField.WidthPercent*
                                       GlobalLayersKnowledge.Perception.Width * .5;
            var comparitiveYLocation = GlobalLayersKnowledge.MicroSectorField.HeighPercent*
                                       GlobalLayersKnowledge.Perception.Height*.5;

            //micro-sector and direction-field section here
            if ((xLocation >(-1.0 * comparitiveXLocation) && xLocation < (comparitiveXLocation)) && (yLocation > (-1.0 * comparitiveYLocation) && yLocation < (comparitiveYLocation)))
            {
                var xIndexPartOne =
                    (float)
                    (xLocation +
                     .5*(GlobalLayersKnowledge.MicroSectorField.WidthPercent*GlobalLayersKnowledge.Perception.Width));

                var yIndexPartOne =
                    (float)
                    (yLocation +
                     .5*(GlobalLayersKnowledge.MicroSectorField.HeighPercent*GlobalLayersKnowledge.Perception.Height));

                var nearestSectorXIndex = (int)((xIndexPartOne * 
                    (float)GlobalLayersKnowledge.MicroSectorField.TemporaryFieldByLocation.Count) / 
                    (float)(GlobalLayersKnowledge.MicroSectorField.WidthPercent * GlobalLayersKnowledge.Perception.Width));
                var nearestSectorYIndex =
                    (int)(( yIndexPartOne * 
                    (float)GlobalLayersKnowledge.MicroSectorField.TemporaryFieldByLocation[0].Count) / 
                    (float)(GlobalLayersKnowledge.MicroSectorField.HeighPercent * GlobalLayersKnowledge.Perception.Height));
                Axons.Add(new InitiationAxonOneWay(dendriteType: "center",
                                                   targetNeuron:
                                                       GlobalLayersKnowledge.MicroSectorField.TemporaryFieldByLocation
                                                       [nearestSectorXIndex][nearestSectorYIndex],
                                                   thresholdBase: thresholdBase, thresholdSpike: thresholdSpike,
                                                   thresholdDecayPercent: thresholdDecayPercent,
                                                   thresholdDecayConstant: thresholdDecayConstant,
                                                   signalStrength: signalStrength));
                //CHECK THE LOGIC ON THIS INDEX LOCATION
            }



            else //macro-sector section here
            {
               
                var xIndexPartOne = (float) (xLocation + .5*GlobalLayersKnowledge.Perception.Width);
                var yIndexPartOne = (float) (yLocation + .5*GlobalLayersKnowledge.Perception.Height);

                var nearestSectorXIndex = 
                    (int)(( xIndexPartOne * (float)GlobalLayersKnowledge.MacroSectorField.TemporaryFieldByLocation.Count) / 
                    (float)GlobalLayersKnowledge.Perception.Width);
                var nearestSectorYIndex =
                    (int)(( yIndexPartOne * (float)GlobalLayersKnowledge.MacroSectorField.TemporaryFieldByLocation[0].Count) / 
                    (float)GlobalLayersKnowledge.Perception.Height);

                Axons.Add(new InitiationAxonOneWay(dendriteType: "center",
                                                   targetNeuron:
                                                       GlobalLayersKnowledge.MacroSectorField.TemporaryFieldByLocation
                                                       [nearestSectorXIndex][nearestSectorYIndex],
                                                   thresholdBase: thresholdBase, thresholdSpike: thresholdSpike,
                                                   thresholdDecayPercent: thresholdDecayPercent,
                                                   thresholdDecayConstant: thresholdDecayConstant,
                                                   signalStrength: signalStrength));
                //CHECK THE LOGIC ON THIS INDEX LOCATION
            }
        }

        public int XLocation { get; set; } //theoretically don't need if eye muscle localization works out as expected
        public int YLocation { get; set; } //theoretically don't need if eye muscle localization works out as expected
        public float Value { get; set; }
        public float Charge { get; set; }
        public List<InitiationAxonOneWay> Axons { get; set; }

        public void NewTurn()
        {
            foreach (var axon in Axons)
            {
                if (axon.Threshold > axon.ThresholdBase)
                {
                    axon.Threshold -= ((axon.ThresholdDecayPercent*(axon.Threshold - axon.ThresholdBase)) + axon.ThresholdDecayConstant);
                    if (axon.Threshold < axon.ThresholdBase)
                    {
                        axon.Threshold = axon.ThresholdBase;
                    }
                }
                if (Charge > axon.Threshold)
                {
                    axon.Fire();
                    Charge -= axon.SignalStrength;
                }
            }
            if (Charge > 2) //2 needs to be ultimately based on some insput Charge.  NO ARBITRARIES EXCEPT AT THE SYSTEM BUILD LEVEL.  Current 2 is just for testing purposes.  Also XLocation and YLocation ultimately may be removed... though not quite sure yet whether they are necessary for the Muscle movement
            {
                GlobalLayersKnowledge.Perception.SetPixel(XLocation + (int)(.5 * GlobalLayersKnowledge.Perception.Width), YLocation + (int)(.5 * GlobalLayersKnowledge.Perception.Height), Color.White);
            //    Charge = Charge - 2;
            }
        }
    }
}
