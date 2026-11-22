using Colossal.IO.AssetDatabase;
using Game.Modding;
using Game.Settings;

namespace TrafficManager
{
    public class Settings : ModSetting
    {
        public const string kTabGeneral = "TabGeneral";
        public const string kGroupVersion = "GroupVersion";

        [SettingsUISection(kTabGeneral, kGroupVersion)]
        public string ReleaseChannel => Mod.s_ReleaseChannel;

        [SettingsUISection(kTabGeneral, kGroupVersion)]
        public string Version => Mod.s_InformationalVersion;

        public Settings(IMod mod)
            : base(mod)
        {
            onSettingsApplied += (Setting setting) =>
            {
                Normalize();
                RegisterInOptionsUI();
                RegisterKeyBindings();
            };
            SetDefaults();
        }

        public void Normalize() { }

        public override void SetDefaults() { }
    }
}
