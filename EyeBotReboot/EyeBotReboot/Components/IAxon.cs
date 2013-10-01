using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyeBotReboot.Components
{
    public interface IAxon
    {
        double Threshold { get; set; }
        double ThresholdBase { get; set; }
        double ThresholdSpike { get; set; }
        double ThresholdDecayConstant { get; set; }
        double ThresholdDecayPercent { get; set; }
        double SignalStrength { get; set; }
        void Fire();
    }
}
