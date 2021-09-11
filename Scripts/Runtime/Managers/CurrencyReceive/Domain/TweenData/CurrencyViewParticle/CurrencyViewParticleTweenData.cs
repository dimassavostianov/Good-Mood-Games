using UnityEngine;

namespace GoodMoodGames.Scripts.Runtime.Managers.CurrencyReceive.Domain.TweenData.CurrencyViewParticle
{
    public abstract class CurrencyViewParticleTweenData : ScriptableObject
    {
        [SerializeField] private float _animationDuration = 1;

        public float AnimationDuration => _animationDuration;
    }
}