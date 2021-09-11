using System.Globalization;
using DG.Tweening;
using GoodMoodGames.Scripts.Runtime.Utilities.Text.Domain.TweenData;
using TMPro;
using UnityEngine;

namespace GoodMoodGames.Scripts.Runtime.Utilities.Text
{
    public class TextCounter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;

        [Space] [SerializeField] private TextCounterTweenData _tweenData;

        private int Count { get; set; }

        public Tween SetCounter(int value)
        {
            Count = value;
            return SetText();
        }

        public Tween ResetCounter(int value = 1)
        {
            Count += value;
            return SetText();
        }

        private Tween SetText()
        {
            var countSequence = DOTween.Sequence();
            var currentCount = int.Parse(_text.text);

            countSequence.Append(DOTween
                .To(count => _text.text = Mathf.CeilToInt(count).ToString(CultureInfo.InvariantCulture),
                    currentCount, Count, _tweenData.CountDuration).SetEase(_tweenData.CountCurve));

            return countSequence;
        }
    }
}