using p3ppc.expandedfemcost.Configuration;
using p3ppc.expandedfemcost.Template;
using Reloaded.Hooks.ReloadedII.Interfaces;
using Reloaded.Mod.Interfaces;
using Ryo.Interfaces;

namespace p3ppc.expandedfemcost
{
    /// <summary>
    /// Your mod logic goes here.
    /// </summary>
    public class Mod : ModBase // <= Do not Remove.
    {
        /// <summary>
        /// Provides access to the mod loader API.
        /// </summary>
        private readonly IModLoader _modLoader;

        /// <summary>
        /// Provides access to the Reloaded.Hooks API.
        /// </summary>
        /// <remarks>This is null if you remove dependency on Reloaded.SharedLib.Hooks in your mod.</remarks>
        private readonly IReloadedHooks? _hooks;

        /// <summary>
        /// Provides access to the Reloaded logger.
        /// </summary>
        private readonly ILogger _logger;

        /// <summary>
        /// Entry point into the mod, instance that created this class.
        /// </summary>
        private readonly IMod _owner;

        /// <summary>
        /// Provides access to this mod's configuration.
        /// </summary>
        private Config _configuration;

        /// <summary>
        /// The configuration of the currently executing mod.
        /// </summary>
        private readonly IModConfig _modConfig;

        public Mod(ModContext context)
        {
            _modLoader = context.ModLoader;
            _hooks = context.Hooks;
            _logger = context.Logger;
            _owner = context.Owner;
            _configuration = context.Configuration;
            _modConfig = context.ModConfig;

            var ryoController = _modLoader.GetController<IRyoApi>();
            if (ryoController == null || !ryoController.TryGetTarget(out var ryoControllerApi))
            {
                _logger.WriteLine($"Ryo Framework Controller returned as null! p3ppc.expandedfemcost will not work properly!", System.Drawing.Color.Red);
                return;
            }

            InitializeMusic(ryoControllerApi);
        }

        private void InitializeMusic(IRyoApi ryo)
        {
            var MusicRegistry = new Dictionary<string, bool>()
            {
                //Add the relative path from OST/FILE.ryo
                {"Tranquility", _configuration.Tranquility},
                {"LastBattle", _configuration.LastBattle},
                {"WayOfLife", _configuration.PaulowniaMall}
            };

            foreach (KeyValuePair<string, bool> register in MusicRegistry)
            {
                if (register.Value)
                {
                    string musicfolder = Path.Combine(_modLoader.GetDirectoryForModId(_modConfig.ModId), "OST", register.Key);
                    if(Path.Exists(musicfolder))
                        ryo.AddAudioFolder(musicfolder);
                }
            }
        }

        #region Standard Overrides
        public override void ConfigurationUpdated(Config configuration)
        {
            // Apply settings from configuration.
            // ... your code here.
            _configuration = configuration;
            _logger.WriteLine($"[{_modConfig.ModId}] Config Updated: You will need to restart the game for changes to appear.");
        }
        #endregion

        #region For Exports, Serialization etc.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Mod() { }
#pragma warning restore CS8618
        #endregion
    }
}