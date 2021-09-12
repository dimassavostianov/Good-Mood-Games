using DG.Tweening;
using Scripts.Runtime.Currencies.Enums;
using Scripts.Runtime.Managers.CurrencyReceive.Delegates;
using Scripts.Runtime.Managers.CurrencyReceive.Domain;
using UnityEngine;

namespace Scripts.Runtime.Managers.CurrencyReceive.Interfaces
{
    public interface ICurrencyReceiveManager
    {
        event CurrencyValueChangeDelegate ValueChangeStarted;
        event CurrencyValueChangeDelegate ValueChangeEnded;
        
        void SetCurrencyCounterView(CurrencyType currencyType, CurrencyCounterView counterView);
        Tween ChangeCurrencyValue(CurrencyType currencyType, int valueDifference, Vector3 startViewPoint, int particleViewsCount = 1);
        int GetValue(CurrencyType currencyType);
    }
}