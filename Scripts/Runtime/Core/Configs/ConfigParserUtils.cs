using System;
using System.IO;
using Newtonsoft.Json;
using UnityEditor;
using UnityEngine;

namespace GoodMoodGames.Scripts.Runtime.Core.Configs
{
    public static class ConfigParserUtils
    {
        private const string ResourcesFolder = "Resources";

        private static readonly JsonSerializerSettings ConfigSerializerSettings = new JsonSerializerSettings
        {
            Formatting = Formatting.Indented,
            TypeNameHandling = TypeNameHandling.All
        };

        public static Action<string, string> OnTryParseConfig;

        public static void TryParseConfig(string configName, string configSpreadSheetId) =>
            OnTryParseConfig?.Invoke(configName, configSpreadSheetId);

        #region Serialization

        public static void SerializeConfig(object config, string configName)
        {
            var configPath = GetConfigLocalPath();
            var configJson = GetConfigJson();

            File.WriteAllText(configPath, configJson);
            AssetDatabase.Refresh();

            string GetConfigLocalPath() => Path.Combine(Application.dataPath, ResourcesFolder, configName + ".json");
            string GetConfigJson() => JsonConvert.SerializeObject(config, ConfigSerializerSettings);
        }

        public static TConfig DeserializeConfig<TConfig>(string configName)
        {
            var config = Resources.Load<TextAsset>(configName).text;
            return JsonConvert.DeserializeObject<TConfig>(config, ConfigSerializerSettings);
        }

        #endregion
    }
}