using GoodMoodGames.Scripts.Runtime.Currencies.Enums;

namespace GoodMoodGames.Scripts.Runtime.Managers.CurrencyReceive.Delegates
{
    public delegate void CurrencyValueChangeDelegate(CurrencyType currencyType, int value, float duration);
}