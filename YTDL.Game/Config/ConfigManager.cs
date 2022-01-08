using System.Collections.Generic;
using osu.Framework.Configuration;
using osu.Framework.Platform;

namespace YtdlGui.Game.Config
{
    public class ConfigManager : IniConfigManager<Configuration>
    {
        public ConfigManager(Storage storage, IDictionary<Configuration, object> defaultOverrides = null)
            : base(storage, defaultOverrides)
        {
        }
    }
}
