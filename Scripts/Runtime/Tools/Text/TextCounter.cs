using TMPro;
using UnityEngine;

namespace Tools.Text
{
    public class TextCounter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private Animation _onCounterUpdateAnimation;
        
        public int Count { get; private set; }

        public void SetCounter(int value)
        {
            Count = value;
            SetText();
        }
        
        public void ResetCounter(int value = 1)
        {
            Count += value;
            SetText();
        }

        private void SetText()
        {
            _text.text = Count.ToString();

            if (!_onCounterUpdateAnimation) return;
            if (!_onCounterUpdateAnimation.isPlaying)
                _onCounterUpdateAnimation.Play();
        }
    }
}