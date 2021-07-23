using System.Collections.Generic;
using UnityEngine;

namespace Tools
{
    public class Follower : MonoBehaviour
    {
        [SerializeField] private Vector3 _followVector = Vector3.forward;
        [SerializeField] private Vector3 _followOffset = Vector3.back;
        [SerializeField] private Transform _objectToFollow;
        [SerializeField] private bool _follow = true;
        
        [Space]
        [Range(0, 1f)]
        [Tooltip("In seconds")]
        [SerializeField] private float _followDelay = 0;

        private List<Vector3> _storedPositions;
        private float _followTimer = 0;

        public bool Follow
        {
            get => _follow;
            set => _follow = value;
        }
        
        private bool HasDelay { get; set; }
        
        private void Awake()
        {
            if (_followDelay <= 0) return;
            
            HasDelay = true;
            _storedPositions = new List<Vector3>();
        }

        private void Update()
        {
            if(!HasDelay) return;
            
            if (_followTimer >= _followDelay)
            {
                _storedPositions.RemoveAt(0);
            }
            else
            {
                _followTimer += Time.deltaTime;
            }
            
            _storedPositions.Add(_objectToFollow.position);
        }
        
        private void LateUpdate()
        {
            DoFollow();
        }

        private void DoFollow()
        {
            if (!Follow) return;

            var followPosition = (HasDelay ? _storedPositions[0] : _objectToFollow.position) + _followOffset;
            var currentPosition = transform.position;

            currentPosition = new Vector3((_followVector.x == 0) ? currentPosition.x : followPosition.x,
                (_followVector.y == 0) ? currentPosition.y : followPosition.y,
                (_followVector.z == 0) ? currentPosition.z : followPosition.z);

            transform.position = currentPosition;
        }

        private void OnDestroy()
        {
            _storedPositions?.Clear();
        }
    }
}