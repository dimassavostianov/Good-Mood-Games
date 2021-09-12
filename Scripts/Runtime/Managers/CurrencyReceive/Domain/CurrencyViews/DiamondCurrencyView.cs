using System;
using System.Collections.Generic;
using DG.Tweening;
using Scripts.Runtime.Managers.Audio;
using Scripts.Runtime.Managers.CurrencyReceive.Domain.CurrencyViewParticles;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Scripts.Runtime.Managers.CurrencyReceive.Domain.CurrencyViews
{
    public sealed class DiamondCurrencyView : CurrencyView
    {
        [SerializeField] private DiamondCurrencyViewParticle _currencyViewParticle;

        [Header("Show properties")]
        [SerializeField] private float _showDuration = .2f;
        [SerializeField] private float _maxShowDelay = 1f;
        [SerializeField] private float _startMinPositionOffset = .5f;
        [SerializeField] private float _startMaxPositionOffset = 1.3f;
        [SerializeField] private Ease _showEase = Ease.OutBack;

        [Header("Appear properties")] 
        [SerializeField] private float _appearDuration = .4f;
        [SerializeField] private float _appearDelay = .4f;
        [SerializeField] private Ease _appearEase = Ease.OutQuad;
        
        [Header("Move properties")] 
        [SerializeField] private float _moveDuration = 1f;
        [SerializeField] private Vector3 _endMoveRotation = new Vector3(0, 0, -10);
        [SerializeField] private Ease _moveEase = Ease.Linear;
        
        [Header("Hide properties")]
        [SerializeField] private float _hideDuration = 0.2f;
        
        [Header("Sfx")]
        [SerializeField] private AudioClip _diamondAppearSfx;
        [SerializeField] private AudioClip _diamondFlySfx;
        [SerializeField] private AudioClip _diamondCollectSfx;
        
        [Space]
        [SerializeField] private float _completeAnimationDelay = 1;

        private readonly List<DiamondCurrencyViewParticle> _diamondParticles = new List<DiamondCurrencyViewParticle>();

        public override Tween ShowView(Vector3 startPosition, Vector3 counterViewPosition, Action viewAppeared,
            int particleViewsCount = 1)
        {
            GenerateViewParticles();

            var sequence = DOTween.Sequence();
            
            sequence.AppendCallback(() => transform.position = startPosition);
            sequence.Append(GetSoundSequence());

            for (var diamond = 0; diamond < particleViewsCount; diamond++)
            {
                var diamondSequence = DOTween.Sequence();

                var startDiamondPositionAngle = Random.Range(0, 2 * Mathf.PI);
                var startDiamondPosition = startPosition +
                                           Random.Range(_startMinPositionOffset, _startMaxPositionOffset) *
                                           new Vector3(
                                               Mathf.Cos(startDiamondPositionAngle),
                                               Mathf.Sin(startDiamondPositionAngle));

                var showDelay = Random.Range(0, _maxShowDelay);
                var diamondParticle = _diamondParticles[diamond];

                diamondSequence.AppendInterval(showDelay);
                diamondSequence.AppendCallback(() => diamondParticle.ResetObject());
                diamondSequence.AppendCallback(() =>
                {
                    diamondParticle.transform.position =
                        Vector3.MoveTowards(startPosition, startDiamondPosition, _startMinPositionOffset);
                });
                
                diamondSequence.Append(ShowDiamond(diamondParticle.transform));
                if(particleViewsCount > 1) diamondSequence.Join(AppearDiamond(diamondParticle, startDiamondPosition));
                diamondSequence.Append(MoveDiamond(diamondParticle.transform, counterViewPosition));

                diamondSequence.Insert(showDelay + _showDuration + _moveDuration + (particleViewsCount > 1
                        ? _appearDuration + _appearDelay
                        : 0),
                    HideDiamond(diamondParticle.transform));

                sequence.Join(diamondSequence);
            }

            sequence.AppendCallback(() => viewAppeared?.Invoke());
            sequence.AppendInterval(_completeAnimationDelay);
            
            return sequence;

            void GenerateViewParticles()
            {
                var diamondParticlesCount = _diamondParticles.Count;
                if (diamondParticlesCount > particleViewsCount) return;

                for (var i = diamondParticlesCount; i < particleViewsCount; i++)
                    _diamondParticles.Add(Instantiate(_currencyViewParticle, transform));
            }
            
            Tween GetSoundSequence()
            {
                var soundSequence = DOTween.Sequence();
                
                soundSequence.AppendInterval(_maxShowDelay);
                soundSequence.AppendCallback(() =>
                {
                    if (_diamondAppearSfx != null)
                        AudioManager.Instance.PlaySound(_diamondAppearSfx);
                });
                soundSequence.AppendInterval(particleViewsCount > 1
                    ? Mathf.Max(_appearDuration + _appearDelay, _showDuration)
                    : _showDuration);
                soundSequence.AppendCallback(() =>
                {
                    if (_diamondFlySfx != null)
                        AudioManager.Instance.PlaySound(_diamondFlySfx);
                });
                soundSequence.AppendInterval(_moveDuration);
                soundSequence.AppendCallback(() =>
                {
                    if (_diamondCollectSfx != null)
                        AudioManager.Instance.PlaySound(_diamondCollectSfx);
                });

                return soundSequence;
            }
            
            Tween ShowDiamond(Transform diamond) => diamond.DOScale(1, _showDuration).SetEase(_showEase);

            Tween AppearDiamond(CurrencyViewParticle diamond, Vector3 position)
            {
                return DOTween.Sequence()
                    .Append(diamond.transform.DOMove(position, _appearDuration).SetEase(_appearEase))
                    .AppendCallback(diamond.PlayCollectAnimation)
                    .AppendInterval(_appearDelay);
            }

            Tween MoveDiamond(Transform diamond, Vector3 position) => DOTween.Sequence()
                .Append(diamond.DOMove(position, _moveDuration))
                .Join(diamond.DOLocalRotate(_endMoveRotation, _moveDuration)).SetEase(_moveEase);

            Tween HideDiamond(Transform diamond) => diamond.DOScale(0, _hideDuration);
        }
    }
}