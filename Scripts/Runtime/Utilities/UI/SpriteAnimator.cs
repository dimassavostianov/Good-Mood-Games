using System.Collections;
using UnityEngine;

namespace Scripts.Runtime.Utilities.UI
{
    public class SpriteAnimator : MonoBehaviour
    {
        [SerializeField] Sprite[] _frames;

        [Space]
        [SerializeField] SpriteRenderer _animatedSprite;
        [Tooltip("In seconds")] [SerializeField] float _animationLength = 1;

        int _numberOfFrames;
        float _framerate;


        private void Awake()
        {
            _numberOfFrames = _frames.Length;
            _framerate = _animationLength / _numberOfFrames;
        }

        public void PlayForward()
        {
            StopAllCoroutines();
            StartCoroutine(PlayForwardCoroutine());
        }

        private IEnumerator PlayForwardCoroutine()
        {
            _animatedSprite.sprite = _frames[0];

            float timer = 0;
            int currentFrame = 0;
            while (currentFrame < (_numberOfFrames - 1))
            {
                timer += Time.deltaTime;

                if (timer >= _framerate)
                {
                    timer = 0;
                    currentFrame++;

                    _animatedSprite.sprite = _frames[currentFrame];
                }

                yield return null;
            }

            yield return null;
        }
    }
}