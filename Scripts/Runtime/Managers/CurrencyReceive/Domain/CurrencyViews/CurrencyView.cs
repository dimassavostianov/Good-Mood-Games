using System;
using DG.Tweening;
using GoodMoodGames.Scripts.Runtime.Patterns.Pool;
using UnityEngine;

namespace GoodMoodGames.Scripts.Runtime.Managers.CurrencyReceive.Domain.CurrencyViews
{
    public abstract class CurrencyView : PoolableObject
    {
        public abstract Tween ShowView(Vector3 startPosition, Vector3 counterViewPosition, Action viewAppeared,
            int particleViewsCount = 1);
    }
}