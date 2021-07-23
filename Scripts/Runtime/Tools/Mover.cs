using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Tools
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] private List<Transform> _moveObjects;
        
        [Space]
        [Tooltip("Leave zero for random vector")]
        [SerializeField] private Vector3 _moveVector = Vector3.zero;
        [SerializeField] private Vector3 _scaleMoveVector = Vector3.one;
        
        [Space]
        [SerializeField] private float _minMoveSpeed = 1;
        [SerializeField] private float _maxMoveSpeed = 1;

        [Space]
        [SerializeField] private bool _move = true;

        public float MoveSpeed { get; private set; }

        public bool Move
        {
            get => _move;
            set => _move = value;
        }

        private void Start()
        {
            if (_moveVector == Vector3.zero)
                _moveVector = new Vector3(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
            
            _moveVector = Vector3.Scale(_moveVector, _scaleMoveVector);
            MoveSpeed = Random.Range(_minMoveSpeed, _maxMoveSpeed);
        }

        private void Update()
        {
            if(!Move) return;

            foreach (var @object in _moveObjects)
                @object.position += _moveVector * MoveSpeed * Time.deltaTime;
        }
    }
}