using System;
using Scripts.Runtime.Currencies.Enums;

namespace Scripts.Runtime.Managers.CurrencyReceive.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public sealed class CurrencyViewAttribute : Attribute
    {
        public CurrencyType CurrencyType { get; }
        public CurrencyViewAttribute(CurrencyType currencyType) => CurrencyType = currencyType;
    }
}