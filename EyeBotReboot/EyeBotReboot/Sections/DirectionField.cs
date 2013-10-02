using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyeBotReboot.Components.Axons;
using EyeBotReboot.Components.Neurons;

namespace EyeBotReboot.Sections
{
    public class DirectionField
    {
        public DirectionField(double direction, int fieldWidth, int fieldHeight,
                              double fieldWidthPercent, double fieldHeightPercent, 
                              double otherDirectionThreshReductionMultiplier,
                              double otherDirectionThresholdBase, double otherDirectionThresholdSpike,
                              double otherDirectionThresholdDecayPercent, double otherDirectionThresholdDecayConstant,
                              double otherDirectionSignalStrength,

                              double representativeThresholdBase, double representativeDirectionThresholdSpike,
                              double representativeDirectionThresholdDecayPercent,
                              double representativeDirectionThresholdDecayConstant,
                              double representativeDirectionSignalStrength,

                              double laplaceFilterThresholdBase, double laplaceFilterThresholdSpike,
                              double laplaceFilterThresholdDecayPercent, double laplaceFilterThresholdDecayConstant,
                              double laplaceFilterSignalStrength)
        {

            WidthPercent = fieldWidthPercent;
            HeightPercent = fieldHeightPercent;

            TemporaryFieldByLocation = new List<List<Direction>>();
            Field = new List<Direction>();

            for (int i = 0; i < (int)(fieldWidth * fieldWidthPercent); i++)
            { 

                TemporaryFieldByLocation.Add(new List<Direction>());
                for (int j = 0; j < (int)(fieldHeight * fieldHeightPercent); j++)
                {
                    
                    Direction newDirectionNeuron = new Direction(direction: direction,
                                                                 otherDirectionThreshReductionMultiplier: otherDirectionThreshReductionMultiplier,
                                                                 otherDirectionThresholdBase: otherDirectionThresholdBase,
                                                                 otherDirectionThresholdSpike: otherDirectionThresholdSpike,
                                                                 otherDirectionThresholdDecayPercent: otherDirectionThresholdDecayPercent,
                                                                 otherDirectionThresholdDecayConstant: otherDirectionThresholdDecayConstant,
                                                                 otherDirectionSignalStrength: otherDirectionSignalStrength,
                                                                 representativeThresholdBase: representativeThresholdBase,
                                                                 representativeDirectionThresholdSpike: representativeDirectionThresholdSpike,
                                                                 representativeDirectionThresholdDecayPercent: representativeDirectionThresholdDecayPercent,
                                                                 representativeDirectionThresholdDecayConstant: representativeDirectionThresholdDecayConstant,
                                                                 representativeDirectionSignalStrength: representativeDirectionSignalStrength);

                    Field.Add(newDirectionNeuron);
                    TemporaryFieldByLocation[i].Add(newDirectionNeuron); //pretty sure it should be okay to use this instead of more complicated below code
                }
            }

            //XXXXXtreme haxor zone for experimenting with connecting direction neurons to each other in the right continuous directions below
            var directionInRadians = Math.PI*(direction/180);
            var xChangePerUnit = Math.Cos(directionInRadians);
            var yChangePerUnit = Math.Sin(directionInRadians);

            var connectionIndexByLocation = new List<List<List<int>>>();

            var startFromFirstOrLastX = xChangePerUnit > 0 ? 0: TemporaryFieldByLocation.Count - 1;
            var startFromFirstOrLastY = yChangePerUnit > 0 ? 0 : TemporaryFieldByLocation[0].Count - 1;

            //x start adder
            for (int i = 0; i < TemporaryFieldByLocation.Count; i++) //this is an experimental place for trying to add directionNeuron-to-directionNeuron connections along the proper direction
            {
                var alreadyIncludedIndexPoints = new List<List<int>>();

                int indexPointX = 0;
                int indexPointY = 0;
                double realPointX = startFromFirstOrLastX == 0 ? i : startFromFirstOrLastX - i;
                double realPointY = startFromFirstOrLastY;

                while (realPointX < TemporaryFieldByLocation.Count-1 && realPointY < TemporaryFieldByLocation[0].Count-1 && realPointX >= 0 && realPointY >= 0)
                {
                    realPointX += xChangePerUnit * .25; //should this be yChange? Also, .25 is totes arbi small number intended to make sure I don't skip an index point.  Gotta be a better way; this is dumb dumb dumb
                    realPointY += yChangePerUnit * .25; //should this be xChange? Also, .25 is totes arbi small number intended to make sure I don't skip an index point.  Gotta be a better way; this is dumb dumb dumb
                    indexPointX = (int)Math.Round(realPointX);
                    indexPointY = (int) Math.Round(realPointY);
                    var newCoordinatePair = new List<int>() {indexPointX, indexPointY};

                    bool coordinatePairAlreadyExists = false;
                    foreach (var coordinatePair in alreadyIncludedIndexPoints)
                    {
                        if (indexPointX == coordinatePair[0] && indexPointY == coordinatePair[1])
                        {
                            coordinatePairAlreadyExists = true;
                        }
                    }

                    if (!coordinatePairAlreadyExists)
                    {
                        alreadyIncludedIndexPoints.Add(newCoordinatePair);
                    }
                }
                connectionIndexByLocation.Add(alreadyIncludedIndexPoints);
            }

            //y start adder
            for (int i = 0; i < TemporaryFieldByLocation.Count; i++) //this is an experimental place for trying to add directionNeuron-to-directionNeuron connections along the proper direction
            {
                var alreadyIncludedIndexPoints = new List<List<int>>();

                int indexPointX = 0;
                int indexPointY = 0;
                double realPointX = startFromFirstOrLastX;
                double realPointY = startFromFirstOrLastY == 0 ? i : startFromFirstOrLastY - i;

                while (realPointX < (TemporaryFieldByLocation.Count-1) && realPointY < (TemporaryFieldByLocation[0].Count-1) && realPointX >= 0 && realPointY >= 0)
                {
                    realPointX += xChangePerUnit * .25; //should this be yChange? Also, .25 is totes arbi small number intended to make sure I don't skip an index point.  Gotta be a better way; this is dumb dumb dumb
                    realPointY += yChangePerUnit * .25; //should this be xChange? Also, .25 is totes arbi small number intended to make sure I don't skip an index point.  Gotta be a better way; this is dumb dumb dumb
                    indexPointX = (int)Math.Round(realPointX);
                    indexPointY = (int)Math.Round(realPointY);
                    var newCoordinatePair = new List<int>() { indexPointX, indexPointY };

                    bool coordinatePairAlreadyExists = false;
                    foreach (var coordinatePair in alreadyIncludedIndexPoints)
                    {
                        if (indexPointX == coordinatePair[0] && indexPointY == coordinatePair[1])
                        {
                            coordinatePairAlreadyExists = true;
                        }
                    }

                    if (!coordinatePairAlreadyExists)
                    {
                        alreadyIncludedIndexPoints.Add(newCoordinatePair);
                    }
                }
                connectionIndexByLocation.Add(alreadyIncludedIndexPoints);
            }
            //long comment: currently anticipated problem is that for directions that have axis change values close to yChange = 0 or xChange = 0,
            //there will be A LOT of redundancy in how the connections will wire.  To address this, I am thinking for now of simply checking whether
            //or not a pre-existing connection exists between a given direction neuron in a field and a given sibling direction neuron, and only
            //establishing a new connection if a current one does not exist.  Final note: this seems easy in theory, but in practice the only-axon-
            //awareness of neurons (which is a good thing for concern isolation) might complicate this.  Cross that when I get there tho.

            for (int firstLayer = 0;  firstLayer < connectionIndexByLocation.Count - 1; firstLayer++) //not sure why -2 instead of -1 is necessary here - for some reason -1 was breaking it
            {
                for (int neuronIndexPosition = 0;
                     neuronIndexPosition < connectionIndexByLocation[firstLayer].Count - 1;
                     neuronIndexPosition++)
                {
                    var alreadyConnected = false;
                    foreach (
                        var axon in
                            TemporaryFieldByLocation[connectionIndexByLocation[firstLayer][neuronIndexPosition][0]][
                                connectionIndexByLocation[firstLayer][neuronIndexPosition][1]].Axons)
                    {
                        if (axon.Dendrite.PairedAxon.PairedDendrite.Neuron ==
                            TemporaryFieldByLocation[connectionIndexByLocation[firstLayer][neuronIndexPosition][0]][
                                connectionIndexByLocation[firstLayer][neuronIndexPosition][1]])
                        {
                            alreadyConnected = true;
                        }
                    }

                    if (alreadyConnected == false)
                    {
                        var xIndexInitiationNeuron = connectionIndexByLocation[firstLayer][neuronIndexPosition][0];
                        var yIndexInitiationNeuron = connectionIndexByLocation[firstLayer][neuronIndexPosition][1];

                        var xIndexTargetNeuron = connectionIndexByLocation[firstLayer][neuronIndexPosition + 1][0];
                        var yIndexTargetNeuron = connectionIndexByLocation[firstLayer][neuronIndexPosition + 1][1];

                        //if(xIndexInitiationNeuron)
                        var neuronInitiator = TemporaryFieldByLocation[xIndexInitiationNeuron][yIndexInitiationNeuron];
                        var neuronTarget = TemporaryFieldByLocation[xIndexTargetNeuron][yIndexTargetNeuron];

                        neuronInitiator.Axons.Add(
                            new InitiationAxonTwoWay(outboundThresholdBase: otherDirectionThresholdBase,
                                                     outboundThresholdSpike: otherDirectionThresholdSpike,
                                                     outboundThresholdDecayPercent: otherDirectionThresholdDecayPercent,
                                                     outboundThresholdDecayConstant: otherDirectionThresholdDecayConstant,
                                                     outboundSignalStrength: otherDirectionSignalStrength,
                                                     outboundDendriteType: "paired",
                                                     outboundDendriteThreshReductionMultiplier:
                                                         otherDirectionThreshReductionMultiplier,
                                                     inboundThresholdBase: otherDirectionThresholdBase,
                                                     inboundThresholdSpike: otherDirectionThresholdSpike,
                                                     inboundThresholdDecayPercent: otherDirectionThresholdDecayPercent,
                                                     inboundThresholdDecayConstant: otherDirectionThresholdDecayConstant,
                                                     inboundSignalStrength: otherDirectionSignalStrength,
                                                     inboundDendriteType: "paired",
                                                     inboundDendriteThreshReductionMultiplier: otherDirectionThreshReductionMultiplier,
                                                     targetNeuron: neuronTarget,
                                                     returnNeuron: neuronInitiator
                                                     ));
                    }
                }
            }

            //end XXXXXtreme haxor zone
        }

        public List<List<Direction>> TemporaryFieldByLocation { get; set; }
        public List<Direction> Field { get; set; }
        public DirectionRepresentative DirectionRepresentative { get; set; }

        public double WidthPercent { get; set; }
        public double HeightPercent { get; set; }
    }
}
