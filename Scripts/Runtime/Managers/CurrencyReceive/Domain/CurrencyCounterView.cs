using DG.Tweening;
using GoodMoodGames.Scripts.Runtime.Currencies.Enums;
using GoodMoodGames.Scripts.Runtime.Managers.CurrencyReceive.Domain.CurrencyCounterViewAnimators;
using GoodMoodGames.Scripts.Runtime.Managers.CurrencyReceive.Enums;
using GoodMoodGames.Scripts.Runtime.Managers.CurrencyReceive.Interfaces;
using TMPro;
using UnityEngine;

namespace GoodMoodGames.Scripts.Runtime.Managers.CurrencyReceive.Domain
{
    public sealed class CurrencyCounterView : MonoBehaviour
    {
        [SerializeField] private CurrencyType _currencyType;
        [SerializeField] private CurrencyCounterViewChangeType _counterViewChangeType = CurrencyCounterViewChangeType.Instant;
        
        [Space]
        [SerializeField] private TextMeshProUGUI _counterText;
        [SerializeField] private string _counterTextFormat = "{0}";
        
        [Space]
        [SerializeField] private RectTransform _currencyViewDestinationPoint;
        [SerializeField] private CurrencyCounterViewAnimator _counterViewAnimator;

        public RectTransform CurrencyViewDestinationPoint => _currencyViewDestinationPoint;
        
        private ICurrencyReceiveManager _currencyReceiveManager;

        private Tween _valueChangeTween;
        private int _value;

        private void Start()
        {
            _currencyReceiveManager = CurrencyReceiveManager.Instance;

            _currencyReceiveManager.ValueChangeStarted += OnValueChangeStarted;
            _currencyReceiveManager.ValueChangeEnded += OnValueChangeEnded;
            
            _currencyReceiveManager.SetCurrencyCounterView(_currencyType, this);
            OnValueChanged(_currencyType, _currencyReceiveManager.GetValue(_currencyType), 0);
        }

        private void OnDestroy()
        {
            if (_currencyReceiveManager == null) return;
            _currencyReceiveManager.ValueChangeStarted -= OnValueChangeStarted;
            _currencyReceiveManager.ValueChangeEnded -= OnValueChangeEnded;
        }

        private void OnValueChangeStarted(CurrencyType currencyType, int value, float duration)
        {
            if (_counterViewChangeType == CurrencyCounterViewChangeType.Instant || duration <= float.Epsilon)
                OnValueChanged(currencyType, value, duration);
        }
        
        private void OnValueChangeEnded(CurrencyType currencyType, int value, float duration)
        {
            if (_counterViewChangeType != CurrencyCounterViewChangeType.AfterCurrencyView) return;
            
            OnValueChanged(currencyType, value, duration);
            if(_counterViewAnimator != null) _counterViewAnimator.PlayReceiveAnimation();
        }

        private void OnValueChanged(CurrencyType currencyType, int value, float duration)
        {
            if (currencyType != _currencyType) return;

            _valueChangeTween?.Kill();

            if (duration <= float.Epsilon) SetValue(value);
            else
            {
                _valueChangeTween = DOTween.To(v => SetValue(Mathf.CeilToInt(v)), _value, value, duration)
                    .SetEase(Ease.Linear);
            }

            _value = value;
            
            void SetValue(int v)
            {
                if (_counterText == null) return;
                _counterText.text = string.Format(_counterTextFormat, v);
            }
        }
    }
}