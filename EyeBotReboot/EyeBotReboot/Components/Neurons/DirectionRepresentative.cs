using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyeBotReboot.Components.Neurons
{
    public class DirectionRepresentative: INeuron
    {
        public double Charge { get; set; }
        public double Direction { get; set; } //for debugging purposes  Probably wont be necessary ultimately

        public DirectionRepresentative(double direction)
        {
            Direction = direction;
        }

        public void NewTurn()
        {
            if (Charge > 0)
            {
                var stop = "stop";
            }
        }
    }
}
