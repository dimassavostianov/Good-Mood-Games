using DG.Tweening;
using Scripts.Runtime.Managers.CurrencyReceive.Domain.TweenData.CurrencyViewParticle;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Runtime.Managers.CurrencyReceive.Domain.CurrencyViewParticles
{
    public class DiamondCurrencyViewParticle : CurrencyViewParticle
    {
        [SerializeField] private Image _flareImage;

        [Space]
        [SerializeField] private DiamondCurrencyViewParticleTweenData _tweenData;
        
        private static readonly int FlarePosition = Shader.PropertyToID("_FlarePosition");

        public override void PlayCollectAnimation()
        {
            var flareMaterial = _flareImage.material;
            DOTween.To(v => flareMaterial.SetFloat(FlarePosition, v), 0, 1, _tweenData.AnimationDuration);
        }
    }
}