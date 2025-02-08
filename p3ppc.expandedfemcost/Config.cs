using p3ppc.expandedfemcost.Template.Configuration;
using Reloaded.Mod.Interfaces.Structs;
using System.ComponentModel;

namespace p3ppc.expandedfemcost.Configuration
{
    public class Config : Configurable<Config>
    {
        /*
            User Properties:
                - Please put all of your configurable properties here.
    
            By default, configuration saves as "Config.json" in mod user config folder.    
            Need more config files/classes? See Configuration.cs
    
            Available Attributes:
            - Category
            - DisplayName
            - Description
            - DefaultValue

            // Technically Supported but not Useful
            - Browsable
            - Localizable

            The `DefaultValue` attribute is used as part of the `Reset` button in Reloaded-Launcher.
        */

        [DisplayName("Soul Phrase -last battle-")]
        [Description("Replaces Burn My Dread -last battle- with Soul Phrase -last battle- by karma.")]
        [DefaultValue(true)]
        public bool LastBattle { get; set; } = true;

        [DisplayName("A Way of Life")]
        [Description("Replaces Paulownia Mall (the shop theme) with A Way of Life -Deep inside my mind Remix-.")]
        [DefaultValue(true)]
        public bool PaulowniaMall { get; set; } = true;

        [DisplayName("Tranquility -FEMC version-")]
        [Description("Replaces Tranquility with Tranquility | FEMC ver | by MineFormer.")]
        [DefaultValue(true)]
        public bool Tranquility { get; set; } = true;
    }

    /// <summary>
    /// Allows you to override certain aspects of the configuration creation process (e.g. create multiple configurations).
    /// Override elements in <see cref="ConfiguratorMixinBase"/> for finer control.
    /// </summary>
    public class ConfiguratorMixin : ConfiguratorMixinBase
    {
        // 
    }
}
