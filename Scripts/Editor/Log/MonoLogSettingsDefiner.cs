using GoodMoodGames.Scripts.Runtime.Log;
using UnityEditor;
using UnityEngine;

namespace GoodMoodGames.Scripts.Editor.Log
{
    public static class MonoLogSettingsDefiner
    {
        private const string MonoLogSettingsAssetPath = "Packages/com.goodmoodgames.tools/Data/MonoLogSettings.asset";
        
        [RuntimeInitializeOnLoadMethod]
        public static void DefineLogSettings()
        {
            var monoLogSettings = AssetDatabase.LoadAssetAtPath<MonoLogSettings>(MonoLogSettingsAssetPath);
            MonoLog.InjectLogSettings(monoLogSettings);
            
            Debug.unityLogger.logEnabled = monoLogSettings.DebugLogsEnabled;
        }
    }
}