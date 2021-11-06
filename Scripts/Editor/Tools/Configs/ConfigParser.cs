using System;

namespace GoodMoodGames.Scripts.Editor.Tools.Configs
{
    public static class ConfigParser
    {
        public static Action<string, string> OnTryParseConfig;

        public static void TryParseConfig(string configName, string configSpreadSheetId) =>
            OnTryParseConfig?.Invoke(configName, configSpreadSheetId);
    }
}