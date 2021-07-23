using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Tools.Log
{
    public enum LogChannel
    {
        Log,
        Firebase,
    }
    
    public static class MonoLog
    {
        private const string MonoLogSettingsAssetPath = "Assets/GoodMoodGames/Data/MonoLogSettings.asset";
        private static MonoLogSettings LogSettings { get; set; }

        [RuntimeInitializeOnLoadMethod]
        public static void DefineLogSettings()
        {
            var monoLogSettings = AssetDatabase.LoadAssetAtPath<MonoLogSettings>(MonoLogSettingsAssetPath);
            LogSettings = monoLogSettings;
            
            Debug.unityLogger.logEnabled = monoLogSettings.DebugLogsEnabled;
        }

        #region Log Functions

        public static void Log(string log, LogChannel channel = LogChannel.Log)
        {
            if (!IsChannelEnabled(channel)) return;
            Debug.Log(GetLogMessage(channel, log));
        }

        public static void LogWarning(string log, LogChannel channel = LogChannel.Log)
        {
            if (!IsChannelEnabled(channel)) return;
            Debug.LogWarning(GetLogMessage(channel, log));
        }

        public static void LogError(string log, LogChannel channel = LogChannel.Log)
        {
            if (!IsChannelEnabled(channel)) return;
            Debug.LogError(GetLogMessage(channel, log));
        }

        #endregion

        private static bool IsChannelEnabled(LogChannel logChannel)
        {
            return LogSettings != null && LogSettings.GetChannelInfo(logChannel).LogEnabled;
        }

        private static string GetLogMessage(LogChannel channel, string log)
        {
            return $"<color={GetLogChannelColor()}>[{channel}]</color>: {log}";

            string GetLogChannelColor() => ChannelColorsMap.TryGetValue(channel, out var color) ? color : "grey";
        }

        private static readonly IDictionary<LogChannel, string> ChannelColorsMap = new Dictionary<LogChannel, string>()
        {
            {LogChannel.Firebase, "green"}
        };
    }
}