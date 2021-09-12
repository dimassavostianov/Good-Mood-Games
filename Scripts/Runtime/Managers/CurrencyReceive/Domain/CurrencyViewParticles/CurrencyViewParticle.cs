using UnityEngine;

namespace Scripts.Runtime.Managers.CurrencyReceive.Domain.CurrencyViewParticles
{
    public abstract class CurrencyViewParticle : MonoBehaviour
    {
        public virtual void ResetObject()
        {
            var viewParticleTransform = transform;
            viewParticleTransform.localScale = Vector3.one;
            viewParticleTransform.localPosition = Vector3.zero;
            viewParticleTransform.localRotation = Quaternion.Euler(Vector3.zero);
        }

        public abstract void PlayCollectAnimation();
    }
}