using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyeBotReboot.Components.LaplaceDendrites
{
    public interface ILaplaceDendrite
    {
        float Charge { get; set; }

        void Fire();
    }
}
