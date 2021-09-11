using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace GoodMoodGames.Scripts.Runtime.Managers.CurrencyReceive.Domain.CurrencyCounterViewAnimators
{
    public class DiamondCurrencyCounterViewAnimator : CurrencyCounterViewAnimator
    {
        [SerializeField] private Image _flareImage;
        
        private static readonly int FlarePosition = Shader.PropertyToID("_FlarePosition");

        public override void PlayReceiveAnimation()
        {
            if (ReceiveAnimationTween != null) return;

            var flareMaterial = _flareImage.material;
            ReceiveAnimationTween = DOTween
                .To(v => flareMaterial.SetFloat(FlarePosition, v), 0, 1, _tweenData.ReceiveAnimationDuration)
                .OnComplete(() =>
                {
                    ReceiveAnimationTween?.Kill();
                    ReceiveAnimationTween = null;
                });
        }
    }
}