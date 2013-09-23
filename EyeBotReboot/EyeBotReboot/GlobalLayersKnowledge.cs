using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using EyeBotReboot.Components;
using EyeBotReboot.Components.Muscle;
using EyeBotReboot.Sections;

namespace EyeBotReboot
{
    public static class GlobalLayersKnowledge
    {
        public static ReceptorField ReceptorField;
        public static LaplaceFilterField LaplaceFilterField;
        public static MacroSectorField MacroSectorField;
        public static MicroSectorField MicroSectorField;
        public static EyeMuscle EyeMuscle;

        public static Bitmap Environment;
        public static Bitmap Perception;

        public static Random Randomer;

        public static int Counter;
    }
}
