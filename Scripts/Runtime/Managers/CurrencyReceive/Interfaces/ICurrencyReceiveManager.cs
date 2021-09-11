using DG.Tweening;
using GoodMoodGames.Scripts.Runtime.Currencies.Enums;
using GoodMoodGames.Scripts.Runtime.Managers.CurrencyReceive.Delegates;
using GoodMoodGames.Scripts.Runtime.Managers.CurrencyReceive.Domain;
using UnityEngine;

namespace GoodMoodGames.Scripts.Runtime.Managers.CurrencyReceive.Interfaces
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