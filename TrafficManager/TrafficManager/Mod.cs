using System.Reflection;
using Colossal.IO.AssetDatabase;
using Colossal.Logging;
using Game;
using Game.Modding;
using Game.SceneFlow;

namespace TrafficManager
{
    public class Mod : IMod
    {
        public static Mod s_Instance;
        public static ILog s_Log = LogManager.GetLogger($"{nameof(TrafficManager)}.{nameof(Mod)}").SetShowsErrorsInUI(false);
        public static readonly string s_ReleaseChannel =
#if STABLE
            "Stable"
#elif BETA
            "Beta"
#else
            "UNKNOWN"
#endif
        ;
        public static readonly string s_InformationalVersion = Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;
        public Settings m_Settings;

        private void RegisterSystems(UpdateSystem updateSystem) { }

        public void OnLoad(UpdateSystem updateSystem)
        {
            s_Log.Info(nameof(OnLoad));

            if (GameManager.instance.modManager.TryGetExecutableAsset(this, out var asset))
                s_Log.Info($"Current mod asset at {asset.path}");

            m_Settings = new Settings(this);
            AssetDatabase.global.LoadSettings(nameof(TrafficManager), m_Settings);
            m_Settings.Apply();

            RegisterSystems(updateSystem);

            s_Instance = this;
        }

        public void OnDispose()
        {
            s_Log.Info(nameof(OnDispose));
        }
    }
}
