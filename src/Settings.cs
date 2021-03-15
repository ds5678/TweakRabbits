using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModSettings;

namespace TweakRabbits
{
    internal class TweakRabbitsSettings : JsonModSettings
    {
        [Name("Kill rabbit on stone hit")]
        public bool killOnHit = false;

        [Name("Stun duration, seconds")]
        [Description("Default value is 4 (as of October 29'th, 2018)")]
        [Slider(1, 30)]
        public int stunDuration = 4;
    }
    internal class Settings
    {
        public static TweakRabbitsSettings options;
        public static void OnLoad()
        {
            options = new TweakRabbitsSettings();
            options.AddToModSettings("Tweak Rabbits");
        }
    }
}
