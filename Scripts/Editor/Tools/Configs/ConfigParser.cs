using System;
using System.IO;
using GoodMoodGames.Scripts.Runtime.Core.Configs;
using Newtonsoft.Json;
using UnityEditor;
using UnityEngine;

namespace GoodMoodGames.Scripts.Editor.Tools.Configs
{
    public static class ConfigParser
    {
        private const string ResourcesFolder = "Resources";

        public static Action<string, string> OnTryParseConfig;

        public static void TryParseConfig(string configName, string configSpreadSheetId) =>
            OnTryParseConfig?.Invoke(configName, configSpreadSheetId);

        public static void SerializeConfig(object config, string configName)
        {
            var configPath = GetConfigLocalPath();
            var configJson = GetConfigJson();

            File.WriteAllText(configPath, configJson);
            AssetDatabase.Refresh();

            string GetConfigLocalPath() => Path.Combine(Application.dataPath, ResourcesFolder, configName + ".json");
            string GetConfigJson() => JsonConvert.SerializeObject(config, ConfigsContainer.ConfigSerializerSettings);
        }
    }
}