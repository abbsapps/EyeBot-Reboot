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

            GlobalLayersKnowledge.MacroSectorField = new MacroSectorField(fieldWidth: receptorFieldWidth,
                                                                          fieldHeight: receptorFieldHeight,
                                                                          sectorRowCount: 20, thresholdBase: 1000,
                                                                          thresholdSpike: 100,
                                                                          thresholdDecayPercent: (float) .2,
                                                                          thresholdDecayConstant: 10, signalStrength: 1,
                                                                          dendriteType: "unpaired");

            GlobalLayersKnowledge.MicroSectorField = new MicroSectorField(fieldWidth: receptorFieldWidth,
                                                                          fieldHeight: receptorFieldHeight,
                                                                          fieldWidthPercent: (float) .1,
                                                                          fieldHeightPercent: (float) .1,
                                                                          sectorRowCount: 10, thresholdBase: 200,
                                                                          thresholdSpike: 25,
                                                                          thresholdDecayPercent: (float) .2,
                                                                          thresholdDecayConstant: 5, signalStrength: 1,
                                                                          dendriteType: "unpaired");

            GlobalLayersKnowledge.LaplaceFilterField = new LaplaceFilterField(fieldWidth: receptorFieldWidth,
                                                                              fieldHeight: receptorFieldHeight,
                                                                              focusDensity: (float) .15,
                                                                              thresholdBase: 3, thresholdSpike: 0,
                                                                              thresholdDecayPercent: (float) .2,
                                                                              thresholdDecayConstant: (float) .3,
                                                                              signalStrength: 3);

            GlobalLayersKnowledge.ReceptorField = new ReceptorField(fieldWidth: receptorFieldWidth,
                                                                    fieldHeight: receptorFieldHeight,
                                                                    focusDensity: (float) .3,
                                                                    focusLocationX: focusStartLocationX,
                                                                    focusLocationY: focusStartLocationY,
                                                                    thresholdBase: 0, thresholdSpike: 0,
                                                                    thresholdDecayPercent: (float) 0,
                                                                    thresholdDecayConstant: (float) 0, signalStrength: 3,
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
