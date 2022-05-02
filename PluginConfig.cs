using Exiled.API.Interfaces;
using System.ComponentModel;

namespace LifeForMoreStamina
{
    public class PluginConfig : IConfig
    {
        [Description("Defines if the plugin is enabled or it isn't")]
        public bool IsEnabled { get; set; } = true;
        [Description("Defines how many life gets removed for every time stamina is depleted")]
        public int HpRemoved { get; set; } = 1;
        [Description("Defines how many stamina gets added after the stamina gets to 0.025\n (There is no config for this because the counter bugs if you put a smaller value on there.)\n the values of the stamina are from 0 to 1 being 0.50 the half")]
        public double StaminaAdded { get; set; } = 0.050;
    }
}