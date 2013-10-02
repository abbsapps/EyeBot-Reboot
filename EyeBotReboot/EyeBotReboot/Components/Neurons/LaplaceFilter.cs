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
        public LaplaceFilter(int xLocation, int yLocation, double thresholdBase, double thresholdSpike, double thresholdDecayPercent, double thresholdDecayConstant, double signalStrength, double directionNeuronOutboundThresholdBase, double directionNeuronOutboundThresholdSpike, double directionNeuronOutboundThresholdDecayPercent, double directionNeuronOutboundThresholdDecayConstant, double directionNeuronOutboundSignalStrength, double directionNeuronOutboundDendriteThresholdReductionMultiplier, double directionNeuronInboundThresholdBase, double directionNeuronInboundThresholdSpike, double directionNeuronInboundThresholdDecayPercent, double directionNeuronInboundThresholdDecayConstant, double directionNeuronInboundSignalStrength, double directionNeuronInboundDendriteThresholdReductionMultiplier)
        {
            Axons = new List<IAxon>();
            Charge = 0;
            XLocation = xLocation;
            YLocation = yLocation;
            var comparitiveXLocation = GlobalLayersKnowledge.MicroSectorField.WidthPercent*
                                       GlobalLayersKnowledge.Perception.Width * .5;
            var comparitiveYLocation = GlobalLayersKnowledge.MicroSectorField.HeightPercent*
                                       GlobalLayersKnowledge.Perception.Height*.5;

            //micro-sector and direction-field section here
            if ((xLocation >(-1.0 * comparitiveXLocation) && xLocation < (comparitiveXLocation)) && (yLocation > (-1.0 * comparitiveYLocation) && yLocation < (comparitiveYLocation)))
            {
                var xIndexPartOne =
                    (double)
                    (xLocation +
                     .5*(GlobalLayersKnowledge.MicroSectorField.WidthPercent*GlobalLayersKnowledge.Perception.Width));

                var yIndexPartOne =
                    (double)
                    (yLocation +
                     .5*(GlobalLayersKnowledge.MicroSectorField.HeightPercent*GlobalLayersKnowledge.Perception.Height));

                var nearestSectorXIndex = (int)((xIndexPartOne * 
                    (double)GlobalLayersKnowledge.MicroSectorField.TemporaryFieldByLocation.Count) / 
                    (double)(GlobalLayersKnowledge.MicroSectorField.WidthPercent * GlobalLayersKnowledge.Perception.Width));
                var nearestSectorYIndex =
                    (int)(( yIndexPartOne * 
                    (double)GlobalLayersKnowledge.MicroSectorField.TemporaryFieldByLocation[0].Count) / 
                    (double)(GlobalLayersKnowledge.MicroSectorField.HeightPercent * GlobalLayersKnowledge.Perception.Height));
                Axons.Add(new InitiationAxonOneWay(dendriteType: "center",
                                                   targetNeuron:
                                                       GlobalLayersKnowledge.MicroSectorField.TemporaryFieldByLocation
                                                       [nearestSectorXIndex][nearestSectorYIndex],
                                                   thresholdBase: thresholdBase, thresholdSpike: thresholdSpike,
                                                   thresholdDecayPercent: thresholdDecayPercent,
                                                   thresholdDecayConstant: thresholdDecayConstant,
                                                   signalStrength: signalStrength));

                //direction field section here
                foreach (var directionField in GlobalLayersKnowledge.DirectionSuperField.DirectionFields) //I AM EXTREMELY WARY OF THIS CODE FOR NOW.  
                    //I'M PRETTY SURE ALL THESE THRESH CONSTRUCTOR VARIABLES SHOULD FOR LAPLACE-FILTER-TO-DIRECTION-NEURON AXONS NOT BE THE SAME AS THE 
                    //LAPLACE-FILTER-TO-SECTOR-NEURON AXONS, WHICH IS CURRENTLY THE CASE.  SO... MAYBE I HAVE TO ADD EXTRA SET OF INPUTS FOR LAPLACE FILTERS 
                    //WHICH IS WHAT THEIR AXONS-TO-DIRECTION-NEURONS SHOULD HAVE AS VALUES? ALSO NEEDING TO BE CONSIDERED: DIRECTION-NEURON-TO-LAPLACE-FILTER
                    //SENDING IS UNDER CURRENT DESIGN SUPPOSED TO HAVE A VERY VERY HIGH PAIRED-AXON-THRESH-LOWERING MULTIPLIER, BUT UNDER CURRENT DESIGN IT 
                    //LOOKS LIKE ALL DENDRITE PAIRED-AXON-THRESH-LOWERING MULTIPLIERS ARE THE GOING BOTH DIRECTIONS AFTER THE INITIATIONAXONTWOWAY HAS BEEN
                    //INITIATED.  THIS IS NOT A GOOD SOLUTION.  CLEARLY TIME TO SLOW DOWN AND REFACTOR.
                {
                    var xIndex = xLocation + (int)comparitiveXLocation;
                    var yIndex = yLocation + (int)comparitiveYLocation;
                    var targetNeuronLocation = directionField.TemporaryFieldByLocation[xIndex][yIndex];
                    Axons.Add(new InitiationAxonTwoWay(outboundThresholdBase: directionNeuronOutboundThresholdBase, outboundThresholdSpike: directionNeuronOutboundThresholdSpike,
                                                       outboundThresholdDecayPercent: directionNeuronOutboundThresholdDecayPercent,
                                                       outboundThresholdDecayConstant: directionNeuronOutboundThresholdDecayConstant,
                                                       outboundSignalStrength: directionNeuronOutboundSignalStrength, outboundDendriteType: "paired",
                                                       outboundDendriteThreshReductionMultiplier: directionNeuronOutboundDendriteThresholdReductionMultiplier, 
                                                       inboundThresholdBase: directionNeuronInboundThresholdBase,
                                                       inboundThresholdSpike: directionNeuronInboundThresholdSpike,
                                                       inboundThresholdDecayPercent: directionNeuronInboundThresholdDecayPercent,
                                                       inboundThresholdDecayConstant: directionNeuronInboundThresholdDecayConstant,
                                                       inboundSignalStrength: directionNeuronInboundSignalStrength,
                                                       inboundDendriteType: "paired",
                                                       inboundDendriteThreshReductionMultiplier: directionNeuronInboundDendriteThresholdReductionMultiplier,
                                                       targetNeuron: targetNeuronLocation, returnNeuron: this));
                }
            }



            else
            {
               
                var xIndexPartOne = (double) (xLocation + .5*GlobalLayersKnowledge.Perception.Width);
                var yIndexPartOne = (double) (yLocation + .5*GlobalLayersKnowledge.Perception.Height);

                var nearestSectorXIndex = 
                    (int)(( xIndexPartOne * (double)GlobalLayersKnowledge.MacroSectorField.TemporaryFieldByLocation.Count) / 
                    (double)GlobalLayersKnowledge.Perception.Width);
                var nearestSectorYIndex =
                    (int)(( yIndexPartOne * (double)GlobalLayersKnowledge.MacroSectorField.TemporaryFieldByLocation[0].Count) / 
                    (double)GlobalLayersKnowledge.Perception.Height);

                Axons.Add(new InitiationAxonOneWay(dendriteType: "center",
                                                   targetNeuron:
                                                       GlobalLayersKnowledge.MacroSectorField.TemporaryFieldByLocation
                                                       [nearestSectorXIndex][nearestSectorYIndex],
                                                   thresholdBase: thresholdBase, thresholdSpike: thresholdSpike,
                                                   thresholdDecayPercent: thresholdDecayPercent,
                                                   thresholdDecayConstant: thresholdDecayConstant,
                                                   signalStrength: signalStrength));
            }
        }

        public int XLocation { get; set; } //theoretically don't need if eye muscle localization works out as expected
        public int YLocation { get; set; } //theoretically don't need if eye muscle localization works out as expected
        public double Value { get; set; }
        public double Charge { get; set; }
        public List<IAxon> Axons { get; set; }

        public void NewTurn()
        {
            foreach (var axon in Axons)
            {
                while (axon.Threshold > axon.ThresholdBase) //DEFINITELY LOOK INTO WHILE LOOP HERE - PRETTY POSITIVE THAT IS THE RIGHT ROUTE TO GO.
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
