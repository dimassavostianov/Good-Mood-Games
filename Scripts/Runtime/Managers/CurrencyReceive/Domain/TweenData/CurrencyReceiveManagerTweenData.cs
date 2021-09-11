using UnityEngine;

namespace GoodMoodGames.Scripts.Runtime.Managers.CurrencyReceive.Domain.TweenData
{
    public sealed class CurrencyReceiveManagerTweenData : ScriptableObject
    {
        [SerializeField] private float _valueChangeDuration = 1;

        public float ValueChangeDuration => _valueChangeDuration;
    }
}