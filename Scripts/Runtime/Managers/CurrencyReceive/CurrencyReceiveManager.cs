using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DG.Tweening;
using Scripts.Runtime.Currencies.Enums;
using Scripts.Runtime.Managers.CurrencyReceive.Attributes;
using Scripts.Runtime.Managers.CurrencyReceive.Delegates;
using Scripts.Runtime.Managers.CurrencyReceive.Domain;
using Scripts.Runtime.Managers.CurrencyReceive.Domain.CurrencyViews;
using Scripts.Runtime.Managers.CurrencyReceive.Domain.TweenData;
using Scripts.Runtime.Managers.CurrencyReceive.Interfaces;
using Scripts.Runtime.Patterns.Pool;
using Scripts.Runtime.Patterns.Singleton;
using UnityEngine;

namespace Scripts.Runtime.Managers.CurrencyReceive
{
    public class CurrencyReceiveManager : MonoBehaviourSingleton<CurrencyReceiveManager>, ICurrencyReceiveManager
    {
        [SerializeField] private Camera _uiCamera;
        
        [Space]
        [SerializeField] private Transform _currencyViewsContainer;
        [SerializeField] private CurrencyReceiveManagerTweenData _tweenData;

        #region Currency views

        [Header("Currency views")] 
        [CurrencyView(CurrencyType.Diamond)]
        [SerializeField] private CurrencyView _diamondCurrencyView;

        #endregion

        public event CurrencyValueChangeDelegate ValueChangeStarted;
        public event CurrencyValueChangeDelegate ValueChangeEnded;
        
        private readonly IDictionary<CurrencyType, CurrencyDescriptor> _currencyDescriptors =
            new Dictionary<CurrencyType, CurrencyDescriptor>();

        protected void Awake()
        {
            foreach (var field in GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance))
            {
                var attributes = field.GetCustomAttributes<CurrencyViewAttribute>().ToArray();
                if (attributes.Length == 0) continue;

                foreach (var attribute in attributes)
                {
                    _currencyDescriptors[attribute.CurrencyType] =
                        new CurrencyDescriptor((CurrencyView) field.GetValue(this), _currencyViewsContainer);
                }
            }
        }

        public void SetCurrencyCounterView(CurrencyType currencyType, CurrencyCounterView counterView) =>
            _currencyDescriptors[currencyType].CurrencyCounterView = counterView;

        public Tween ChangeCurrencyValue(CurrencyType currencyType, int valueDifference, Vector3 startViewPoint, int particleViewsCount = 1)
        {
            if (!_currencyDescriptors.ContainsKey(currencyType)) return null;

            _currencyDescriptors[currencyType].Value += valueDifference;
            return ShowCurrencyView();
            
            Tween ShowCurrencyView()
            {
                var currencyDescriptor = _currencyDescriptors[currencyType];
                var view = currencyDescriptor.CurrencyViewPool.Get();
            
                var value = currencyDescriptor.Value;
                var duration = _tweenData.ValueChangeDuration;
                ValueChangeStarted?.Invoke(currencyType, value, duration);
            
                view.transform.localScale = Vector3.one;
                view.gameObject.SetActive(true);

                return view.ShowView(startViewPoint,
                        _uiCamera.WorldToScreenPoint(currencyDescriptor.CurrencyCounterView.CurrencyViewDestinationPoint
                            .position), () => ValueChangeEnded?.Invoke(currencyType, value, duration), particleViewsCount)
                    .OnComplete(ReleaseView)
                    .OnKill(ReleaseView);

                void ReleaseView() => currencyDescriptor.CurrencyViewPool.Release(view);
            }
        }

        public int GetValue(CurrencyType currencyType) =>
            _currencyDescriptors.TryGetValue(currencyType, out var currencyDescriptor) ? currencyDescriptor.Value : 0;

        private class CurrencyDescriptor
        {
            public int Value;
            public readonly ObjectPool<CurrencyView> CurrencyViewPool;
            public CurrencyCounterView CurrencyCounterView;

            public CurrencyDescriptor(CurrencyView currencyView, Transform viewContainer) =>
                CurrencyViewPool = new ObjectPool<CurrencyView>(currencyView, viewContainer);
        }
    }
}