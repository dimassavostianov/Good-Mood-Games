using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Runtime.Log
{
    public sealed class MonoLogSettings : ScriptableObject
    {
        [SerializeField] private bool _debugLogsEnabled = true;

        [Space]
        [SerializeField] private List<LogChannelInfo> _channelInfos;

        private IDictionary<LogChannel, LogChannelInfo> _channelsMap;

        public bool DebugLogsEnabled => _debugLogsEnabled;

        public LogChannelInfo GetChannelInfo(LogChannel logChannel)
        {
            if (_channelsMap == null)
            {
                _channelsMap = new Dictionary<LogChannel, LogChannelInfo>();
                foreach (var info in _channelInfos) _channelsMap[info.LogChannel] = info;
            }

            if (_channelsMap.TryGetValue(logChannel, out var channelInfo))
                return channelInfo;

            Debug.LogError($"Can't find log channel info {logChannel}");
            return new LogChannelInfo(logChannel);
        }
    }
}