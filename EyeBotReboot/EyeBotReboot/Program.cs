using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Mime;
using System.Text;
using EyeBotReboot.Components.Muscle;
using EyeBotReboot.Sections;

namespace EyeBotReboot
{
    class Program
    {
        static void Main(string[] args)
        {
            var receptorFieldWidth = 500;
            var receptorFieldHeight = 500;

            Image environmentImage = Image.FromFile(System.IO.Directory.GetCurrentDirectory() + "/Images/example.png");
            GlobalLayersKnowledge.Environment = new Bitmap(environmentImage);
            GlobalLayersKnowledge.Perception = new Bitmap(receptorFieldWidth, receptorFieldHeight);
            GlobalLayersKnowledge.Randomer = new Random();
            GlobalLayersKnowledge.Counter = 0;

            var focusStartLocationX = (int) (GlobalLayersKnowledge.Randomer.NextDouble()*
                                      GlobalLayersKnowledge.Environment.Width);
            var focusStartLocationY = (int)(GlobalLayersKnowledge.Randomer.NextDouble()*
                                      GlobalLayersKnowledge.Environment.Height);

            //focusStartLocationX = 260;
            //focusStartLocationY = 260;

            GlobalLayersKnowledge.EyeMuscle = new EyeMuscle();

            var directions = new List<double>();

            for (double i = 1; i < 360; i += 3.6 )
            {
                directions.Add(i);
            }

            //for experimental testing purposes
            //directions.Add(100);
            //end experimental testing exactitude

            GlobalLayersKnowledge.DirectionSuperField = new DirectionSuperField(directions: directions, //1's are all obviously fillers.  For now I'm just trying to get the direction fields hooked up right
                                                                                fieldWidth: receptorFieldWidth,
                                                                                fieldHeight: receptorFieldHeight,
                                                                                fieldHeightPercent: .1,
                                                                                fieldWidthPercent: .1,
                                                                                otherDirectionThreshReductionMultiplier: 1,
                                                                                otherDirectionThresholdBase: 1,
                                                                                otherDirectionThresholdSpike: 1,
                                                                                otherDirectionThresholdDecayPercent: 1,
                                                                                otherDirectionThresholdDecayConstant: 1,
                                                                                otherDirectionSignalStrength: 1,
                                                                                representativeThresholdBase: 1,
                                                                                representativeDirectionThresholdSpike: 1,
                                                                                representativeDirectionThresholdDecayPercent : 1,
                                                                                representativeDirectionThresholdDecayConstant : 1,
                                                                                representativeDirectionSignalStrength: 1);

            GlobalLayersKnowledge.MacroSectorField = new MacroSectorField(fieldWidth: receptorFieldWidth,
                                                                          fieldHeight: receptorFieldHeight,
                                                                          sectorRowCount: 10, thresholdBase: 1500,
                                                                          thresholdSpike: 500,
                                                                          thresholdDecayPercent: .2,
                                                                          thresholdDecayConstant: 10, signalStrength: 1,
                                                                          dendriteType: "unpaired");

            GlobalLayersKnowledge.MicroSectorField = new MicroSectorField(fieldWidth: receptorFieldWidth,
                                                                          fieldHeight: receptorFieldHeight,
                                                                          fieldWidthPercent: .1,
                                                                          fieldHeightPercent: .1,
                                                                          sectorRowCount: 10, thresholdBase: 150,
                                                                          thresholdSpike: 150,
                                                                          thresholdDecayPercent: .2,
                                                                          thresholdDecayConstant: 5, signalStrength: 1,
                                                                          dendriteType: "unpaired");

            GlobalLayersKnowledge.LaplaceFilterField = new LaplaceFilterField(fieldWidth: receptorFieldWidth,
                                                                              fieldHeight: receptorFieldHeight,
                                                                              focusDensity: .15,
                                                                              thresholdBase: 3, thresholdSpike: 0,
                                                                              thresholdDecayPercent: .2,
                                                                              thresholdDecayConstant: .3,
                                                                              signalStrength: 3,

                                                                              directionNeuronOutboundThresholdBase: 1,
                                                                              directionNeuronOutboundThresholdSpike: 1,
                                                                              directionNeuronOutboundThresholdDecayPercent: .1,
                                                                              directionNeuronOutboundThresholdDecayConstant: 1,
                                                                              directionNeuronOutboundSignalStrength: 1,
                                                                              directionNeuronOutboundDendriteThresholdReductionMultiplier : 5,

                                                                              directionNeuronInboundThresholdBase: 1,
                                                                              directionNeuronInboundThresholdSpike: 1,
                                                                              directionNeuronInboundThresholdDecayPercent: .1,
                                                                              directionNeuronInboundThresholdDecayConstant: 1,
                                                                              directionNeuronInboundSignalStrength: 1,
                                                                              directionNeuronInboundDendriteThresholdReductionMultiplier: 5);//THIS IS NEED OF HEAVY TWEEKING / TESTING

            GlobalLayersKnowledge.ReceptorField = new ReceptorField(fieldWidth: receptorFieldWidth,
                                                                    fieldHeight: receptorFieldHeight,
                                                                    focusDensity: .3,
                                                                    focusLocationX: focusStartLocationX,
                                                                    focusLocationY: focusStartLocationY,
                                                                    thresholdBase: 0, thresholdSpike: 0,
                                                                    thresholdDecayPercent: 0,
                                                                    thresholdDecayConstant: 0, signalStrength: 3,
                                                                    laplaceReach: 2);

            GlobalLayersKnowledge.EyeMuscle.ReceptorField = GlobalLayersKnowledge.ReceptorField;
            

            for (int i = 0; i < 10; i++)
            {
                GlobalLayersKnowledge.Perception = new Bitmap(receptorFieldWidth, receptorFieldHeight);
                GlobalLayersKnowledge.ReceptorField.NewTurn();
                GlobalLayersKnowledge.LaplaceFilterField.NewTurn();
                GlobalLayersKnowledge.MacroSectorField.NewTurn();
                GlobalLayersKnowledge.MicroSectorField.NewTurn();
                var currentPath = System.IO.Directory.GetCurrentDirectory();
                //if (i % 5 == 0)
                //{
                    GlobalLayersKnowledge.Perception.Save(currentPath + "/Results/perception" + i.ToString() + ".png");
                //}
                
            }
        }
    }
}
