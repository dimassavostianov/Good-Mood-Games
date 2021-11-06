using UnityEngine;

namespace GoodMoodGames.Scripts.Runtime.Core.GoogleServices
{
    public abstract class GoogleSheetDescriptor : ScriptableObject
    {
        [SerializeField] private string _configName;
        [SerializeField] private string _configSpreadSheetId;

        public string ConfigName => _configName;
        public string ConfigSpreadSheetId => _configSpreadSheetId;
    }
}