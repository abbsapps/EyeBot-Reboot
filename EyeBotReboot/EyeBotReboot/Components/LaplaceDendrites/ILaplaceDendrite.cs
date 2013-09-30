using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyeBotReboot.Components.LaplaceDendrites
{
    public interface ILaplaceDendrite
    {
        double Charge { get; set; }

        void Fire();
    }
}
