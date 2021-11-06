using System.IO;
using GoodMoodGames.Scripts.Runtime.Core.Storage.Interfaces;
using Newtonsoft.Json;
using UnityEngine;

namespace GoodMoodGames.Scripts.Runtime.Core.Storage
{
    public class ScriptableSave<TData, TInterface> : ScriptableSave
        where TData : DataContainer, TInterface, IStorageData, new()
    {
        private readonly JsonSerializerSettings _serializerSettings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All
        };

        [SerializeField] private TData _data;
        [SerializeField] private bool _resetOnAppUpdate;

        public static TInterface Instance { get; protected set; }

        public void SaveData()
        {
            var json = JsonConvert.SerializeObject(_data, _serializerSettings);
            var path = $"{Application.persistentDataPath}/{name}";
            File.WriteAllText(path, json);
        }

        public override void LoadData(bool isAppUpdated = false)
        {
            Debug.Log($"Trying to load data: {name}");

            if (_data != null) _data.Changed -= SaveData;
            var path = $"{Application.persistentDataPath}/{name}";

            if (File.Exists(path) && !(isAppUpdated && _resetOnAppUpdate))
            {
                var json = File.ReadAllText(path);
                _data = JsonConvert.DeserializeObject<TData>(json, _serializerSettings);
            }
            if (_data == null) _data = new TData();

            _data.Changed += SaveData;
            _data.OnDataLoaded();

            Instance = _data;
        }

        public override void ResetData()
        {
            _data = new TData();
        }
    }

    public abstract class ScriptableSave : ScriptableObject
    {
        public abstract void LoadData(bool isAppUpdated = false);
        public abstract void ResetData();
    }
}