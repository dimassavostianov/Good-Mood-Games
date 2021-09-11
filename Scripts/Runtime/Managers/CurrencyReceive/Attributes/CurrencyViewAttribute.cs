using System;
using GoodMoodGames.Scripts.Runtime.Currencies.Enums;

namespace GoodMoodGames.Scripts.Runtime.Managers.CurrencyReceive.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public sealed class CurrencyViewAttribute : Attribute
    {
        public CurrencyType CurrencyType { get; }
        public CurrencyViewAttribute(CurrencyType currencyType) => CurrencyType = currencyType;
    }
}