﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using EyeBotReboot.Components.Axons;

namespace EyeBotReboot.Components.Neurons
{
    public class Sector: INeuron
    {
        public Sector(int xLocation, int yLocation, float thresholdBase, float thresholdSpike, float thresholdDecayPercent, float thresholdDecayConstant, float signalStrength, string dendriteType)
        {
            Axons = new List<IAxon>();
            InitiationAxonOneWay axon = new InitiationAxonOneWay(thresholdBase: thresholdBase, thresholdSpike: thresholdSpike,
                                                            thresholdDecayPercent: thresholdDecayPercent,
                                                            thresholdDecayConstant: thresholdDecayConstant,
                                                            signalStrength: signalStrength, dendriteType: dendriteType,
                                                            targetNeuron: GlobalLayersKnowledge.EyeMuscle);
            Axons.Add(axon);
            Charge = 0;
            XLocation = xLocation;
            YLocation = yLocation;
        }

        public int XLocation { get; set; } //theoretically don't need if eye muscle localization works out as expected
        public int YLocation { get; set; } //theoretically don't need if eye muscle localization works out as expected
        public List<IAxon> Axons { get; set; }
        public float Charge { get; set; }

        public void NewTurn()
        {
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    GlobalLayersKnowledge.Perception.SetPixel(
                        XLocation + i + (int)(.5 * GlobalLayersKnowledge.Perception.Width),
                        YLocation + j + (int)(.5 * GlobalLayersKnowledge.Perception.Height), Color.Red);
                }
            }
            if (Charge > 2)
            {
                for (int i = -1; i < 2; i++ )
                {
                    for (int j = -1; j < 2; j++ )
                    {
                        GlobalLayersKnowledge.Perception.SetPixel(
                            XLocation + i + (int)(.5 * GlobalLayersKnowledge.Perception.Width),
                            YLocation + j + (int)(.5 * GlobalLayersKnowledge.Perception.Height), Color.GreenYellow);
                    }
                }
            }
            foreach (InitiationAxonOneWay axon in Axons)
            {
                if (Charge > axon.Threshold)
                {
                    axon.Fire();
                    Charge -= axon.SignalStrength;
                    GlobalLayersKnowledge.EyeMuscle.ChangePosition(XLocation, YLocation);
                }
                axon.Threshold -= (axon.ThresholdDecayConstant + axon.ThresholdDecayPercent * axon.Threshold);
                if (axon.Threshold < axon.ThresholdBase)
                {
                    axon.Threshold = axon.ThresholdBase;
                }
            }
        }
    }
}
