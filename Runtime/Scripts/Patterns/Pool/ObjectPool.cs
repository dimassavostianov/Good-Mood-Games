using System.Collections.Generic;
using Runtime.Scripts.Patterns.Pool.Interfaces;
using UnityEngine;

namespace Runtime.Scripts.Patterns.Pool
{
    public class ObjectPool<T> : IObjectPool<T> where T : PoolableObject
    {
        private readonly Queue<T> _freeObjects = new Queue<T>();
        private readonly List<T> _objectsInUse = new List<T>();

        private T _origin = null;
        private Transform _root = null;

        public ObjectPool(T origin, Transform root)
        {
            _origin = origin;
            _root = root;
        }
        
        public ObjectPool(T origin, Transform root, IEnumerable<T> freeObjects) : this(origin, root)
        {
            foreach (var freeObject in freeObjects)
                _freeObjects.Enqueue(freeObject);
            
            _origin = origin;
            _root = root;
        }

        public T Get()
        {
            T @object;

            if (_freeObjects.Count > 0)
            {
                @object = _freeObjects.Dequeue();
                @object.GameObject.SetActive(true);
            }
            else
            {
                @object = Object.Instantiate(_origin, _root, true);
            }

            @object.OnObjectSpawned();
            _objectsInUse.Add(@object);
            
            return @object;
        }

        public void Release(T @object)
        {
            if(@object == null || _freeObjects.Contains(@object))
                return;;
            
            _freeObjects.Enqueue(@object);
            _objectsInUse.Remove(@object);
            
            @object.ResetObject();
            @object.GameObject.SetActive(false);
        }

        public void ReleaseAll()
        {
            new List<T>(_objectsInUse).ForEach(Release);
            _objectsInUse.Clear();
        }
    }
}