using UnityEngine;

namespace GoodMoodGames.Scripts.Runtime.Tools.Text.Domain
{
    public class TextCounterTweenData : ScriptableObject
    {
        [SerializeField] private float _countDuration = 1;

        [Space] [SerializeField] private AnimationCurve _countCurve;

        public float CountDuration => _countDuration;

        public AnimationCurve CountCurve => _countCurve;
    }
}