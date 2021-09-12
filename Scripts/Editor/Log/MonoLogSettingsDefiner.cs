using Scripts.Runtime.Utilities.Log;
using UnityEditor;
using UnityEngine;

namespace Scripts.Editor.Log
{
    public static class MonoLogSettingsDefiner
    {
        private const string MonoLogSettingsAssetPath = "Assets/Data/Logs/LogSettings.asset";

        [RuntimeInitializeOnLoadMethod]
        public static void DefineLogSettings()
        {
            if (MonoLog.LogSettingsDefined) return;

            var monoLogSettings = AssetDatabase.LoadAssetAtPath<MonoLogSettings>(MonoLogSettingsAssetPath);
            MonoLog.InjectLogSettings(monoLogSettings);
            
            Debug.unityLogger.logEnabled = monoLogSettings.DebugLogsEnabled;
        }
    }
}