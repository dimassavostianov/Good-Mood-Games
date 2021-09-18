using System.IO;
using GoodMoodGames.Scripts.Runtime.Utilities.Storage.Interfaces;
using Newtonsoft.Json;
using UnityEngine;

namespace GoodMoodGames.Scripts.Runtime.Utilities.Storage
{
    public class ScriptableSave<TData, TInterface> : ScriptableSave
        where TData : DataContainer, TInterface, IData, new()
    {
        private readonly JsonSerializerSettings _serializationSettings = new JsonSerializerSettings
            {TypeNameHandling = TypeNameHandling.All};

        [SerializeField] protected TData Data;
        [SerializeField] private bool _resetOnFirstLaunch = true;

        public static TInterface Instance { get; protected set; }

        public virtual void Save()
        {
            var json = JsonConvert.SerializeObject(Data, _serializationSettings);
            var path = $"{Application.persistentDataPath}/{name}";
            File.WriteAllText(path, json);
        }

        public override void Load()
        {
            if (Data != null) Data.Changed -= Save;

            var path = $"{Application.persistentDataPath}/{name}";

            if (File.Exists(path))
            {
                var json = File.ReadAllText(path);
                Data = JsonConvert.DeserializeObject<TData>(json, _serializationSettings);
            }

            if (Data == null) Data = new TData();

            Data.Changed += Save;
            Data.OnDataLoaded();

            Instance = Data;
        }

        public void Delete()
        {
            var path = $"{Application.persistentDataPath}/{name}";
            if (File.Exists(path)) File.Delete(path);
        }

        public override void ResetData()
        {
            if (_resetOnFirstLaunch) Data = new TData();
        }
    }

    public abstract class ScriptableSave : ScriptableObject
    {
        public abstract void Load();
        public abstract void ResetData();
    }
}