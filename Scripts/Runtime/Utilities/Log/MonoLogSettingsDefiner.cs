using System;
using GoodMoodGames.Scripts.Runtime.Patterns.Singleton;
using UnityEditor;
using UnityEngine;

namespace GoodMoodGames.Scripts.Runtime.Utilities.Log
{
    public sealed class MonoLogSettingsDefiner : MonoBehaviourSingleton<MonoLogSettingsDefiner>
    {
        [SerializeField] private string _monoLogSettingsAssetPath = "Assets/Data/Logs/LogSettings.asset";

        private static event Action DefineLogSettings;

        private void Awake() => DefineLogSettings += OnDefineLogSettings;
        private void OnDestroy() => DefineLogSettings -= OnDefineLogSettings;
        
        [RuntimeInitializeOnLoadMethod]
        public static void TryDefineLogSettings()
        {
            if (MonoLog.LogSettingsDefined) return;
            DefineLogSettings?.Invoke();
        }

        private void OnDefineLogSettings()
        {
            var monoLogSettings = AssetDatabase.LoadAssetAtPath<MonoLogSettings>(_monoLogSettingsAssetPath);
            MonoLog.InjectLogSettings(monoLogSettings);
            
            Debug.unityLogger.logEnabled = monoLogSettings.DebugLogsEnabled;
        }
    }
}