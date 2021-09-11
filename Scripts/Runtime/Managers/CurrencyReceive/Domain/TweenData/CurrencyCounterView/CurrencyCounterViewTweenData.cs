using UnityEngine;

namespace GoodMoodGames.Scripts.Runtime.Managers.CurrencyReceive.Domain.TweenData.CurrencyCounterView
{
    public abstract class CurrencyCounterViewTweenData : ScriptableObject
    {
        [SerializeField] private float _receiveAnimationDuration = 1;

        public float ReceiveAnimationDuration => _receiveAnimationDuration;
    }
}