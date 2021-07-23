using System;
using UnityEngine;

namespace GoodMoodGames.Scripts.Patterns.Pool
{
    public class PoolableObject : MonoBehaviour
    {
        [SerializeField] private GameObject _gameObject;

        public event Action OnSpawned;
        public event Action OnReset;
        
        public GameObject GameObject
        {
            get => _gameObject;
        }

        public virtual void OnObjectSpawned()
        {
            OnSpawned?.Invoke();
        }

        public virtual void ResetObject()
        {
            OnReset?.Invoke();
        }
    }
}