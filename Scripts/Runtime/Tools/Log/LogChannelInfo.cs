using System;
using UnityEngine;

namespace GoodMoodGames.Scripts.Tools.Log
{
    [Serializable]
    public sealed class LogChannelInfo
    {
        [SerializeField] private LogChannel _logChannel;
        [SerializeField] private bool _enabled = true;

        public LogChannel LogChannel => _logChannel;
        public bool LogEnabled => _enabled;
        
        public LogChannelInfo(LogChannel logChannel)
        {
            _logChannel = logChannel;
        }
    }
}