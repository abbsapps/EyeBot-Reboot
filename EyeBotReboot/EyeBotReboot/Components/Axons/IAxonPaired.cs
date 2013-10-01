using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyeBotReboot.Components.Dendrites;

namespace EyeBotReboot.Components.Axons
{
    public interface IAxonPaired: IAxon
    {
        PairedDendrite Dendrite { get; set; }
        double Threshold { get; set; }
        double ThresholdBase { get; set; }
        double ThresholdSpike { get; set; }
        double ThresholdDecayConstant { get; set; }
        double ThresholdDecayPercent { get; set; }
        double SignalStrength { get; set; }
        void Fire();
    }
}
