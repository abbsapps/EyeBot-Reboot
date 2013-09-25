using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyeBotReboot.Sections;

namespace EyeBotReboot.Components.Muscle
{
    public class EyeMuscle: INeuron
    {
        public float Charge { get; set; }
        public ReceptorField ReceptorField { get; set; } //should this be an axon->dendrite connection instead?  Probably, but not sure, since the muscle actually, literally, moves the eye causing its relationship with the environment to change instead of just executing internal state changes through charge-exchange.  Need to look into more
        public int EnvironmentFocusX { get; set; }
        public int EnvironmentFocusY { get; set; }

        public void ChangePosition(int triggerXValue, int triggerYValue)
        {
            ReceptorField.EnvironmentFocusX += triggerXValue;
            ReceptorField.EnvironmentFocusY += triggerYValue;

            //hack
            foreach (var receptor in GlobalLayersKnowledge.ReceptorField.Field)
            {
                receptor.Move(EnvironmentFocusX, EnvironmentFocusY);
            }
            foreach (var laplaceFilter in GlobalLayersKnowledge.LaplaceFilterField.Field)
            {
                laplaceFilter.Charge = 0;
            }
            foreach (var sector in GlobalLayersKnowledge.MicroSectorField.Field)
            {
                sector.Charge = 0;
            }
            foreach (var sector in GlobalLayersKnowledge.MacroSectorField.Field)
            {
                sector.Charge = 0;
            }
            //end hack
        }
    }
}
