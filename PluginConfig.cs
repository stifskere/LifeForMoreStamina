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
    }
}