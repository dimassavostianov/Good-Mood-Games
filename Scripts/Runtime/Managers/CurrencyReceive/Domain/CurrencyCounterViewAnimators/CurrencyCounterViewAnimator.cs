using DG.Tweening;
using Scripts.Runtime.Managers.CurrencyReceive.Domain.TweenData.CurrencyCounterView;
using UnityEngine;

namespace Scripts.Runtime.Managers.CurrencyReceive.Domain.CurrencyCounterViewAnimators
{
    public abstract class CurrencyCounterViewAnimator : MonoBehaviour
    {
        [SerializeField] protected CurrencyCounterViewTweenData _tweenData;

        protected Tween ReceiveAnimationTween;

        public abstract void PlayReceiveAnimation();
    }
}