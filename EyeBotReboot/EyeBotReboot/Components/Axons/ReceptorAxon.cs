using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyeBotReboot.Components.Dendrites;
using EyeBotReboot.Components.LaplaceDendrites;
using EyeBotReboot.Components.Neurons;

namespace EyeBotReboot.Components.Axons
{
    public class ReceptorAxon
    {
        public ReceptorAxon(string dendriteType, LaplaceFilter targetNeuron)
        {
            if (dendriteType == "center")
            {
                Dendrite = new UnpairedCenterDentrite(targetNeuron);
                Dendrite.Charge = BrightnessCharge;
                Dendrite.Fire();
            }
            else if (dendriteType == "surround")
            {
                Dendrite = new UnpairedSurroundDendrite(targetNeuron);
            }
        }

        public ILaplaceDendrite Dendrite { get; set; }
        public double BrightnessCharge { get; set; }

        public void Fire()
        {
            Dendrite.Charge = BrightnessCharge;
            Dendrite.Fire();
        }
    }
}
