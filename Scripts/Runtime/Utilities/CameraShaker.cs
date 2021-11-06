using Cinemachine;
using DG.Tweening;
using UnityEngine;

namespace GoodMoodGames.Scripts.Runtime.Utilities
{
    public sealed class CameraShaker : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera _virtualCamera;

        private CinemachineBasicMultiChannelPerlin _channelPerlin;

        private void Start()
        {
            _channelPerlin = _virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        }

        public void Shake(float intensity, float duration, AnimationCurve animationCurve = null)
        {
            _channelPerlin.m_AmplitudeGain = intensity;
            var shakeTween = DOTween.To(amplitude => _channelPerlin.m_AmplitudeGain = amplitude,
                intensity, 0, duration);

            if (animationCurve != null) shakeTween.SetEase(animationCurve);
        }
    }
}