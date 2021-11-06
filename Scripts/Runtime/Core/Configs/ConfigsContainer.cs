using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GoodMoodGames.Scripts.Runtime.Core.Configs
{
    public static class ConfigsContainer
    {
        private static readonly Dictionary<Type, Config> Configs = new Dictionary<Type, Config>();

        public static void SetData(params object[] configContainers)
        {
            if (configContainers == null || !configContainers.Any()) return;
            foreach (var configContainer in configContainers)
            {
                var configContainerFields = configContainer.GetType().GetFields();
                var configs = configContainerFields.Where(x => x.FieldType.IsSubclassOf(typeof(Config)));

                foreach (var config in configs) Configs[config.FieldType] = (Config) config.GetValue(configContainer);
            }

            Debug.Log($"Parsed configs:\n{string.Join("\n", Configs.Select(x => x.Key))}");
        }

        public static T Get<T>() where T : Config => (T) Get(typeof(T));

        private static Config Get(Type configType)
        {
            if (Configs.TryGetValue(configType, out var configObj)) return configObj;
            
            Debug.LogError($"Unable to find config for type '{configType}'");
            return null;
        }
    }
}