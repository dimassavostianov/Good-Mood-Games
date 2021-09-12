using Scripts.Runtime.Currencies.Enums;

namespace Scripts.Runtime.Managers.CurrencyReceive.Delegates
{
    public delegate void CurrencyValueChangeDelegate(CurrencyType currencyType, int value, float duration);
}