using DG.Tweening;
using GoodMoodGames.Scripts.Runtime.Managers.CurrencyReceive.Domain.TweenData.CurrencyCounterView;
using UnityEngine;

namespace GoodMoodGames.Scripts.Runtime.Managers.CurrencyReceive.Domain.CurrencyCounterViewAnimators
{
    public abstract class CurrencyCounterViewAnimator : MonoBehaviour
    {
        [SerializeField] protected CurrencyCounterViewTweenData _tweenData;

        protected Tween ReceiveAnimationTween;

        public abstract void PlayReceiveAnimation();
    }
}