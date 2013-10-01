﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyeBotReboot.Components.Dendrites;

namespace EyeBotReboot.Components.Axons
{
    public interface IAxonPaired: IAxon
    {
        PairedDendrite Dendrite { get; set; }
    }
}
