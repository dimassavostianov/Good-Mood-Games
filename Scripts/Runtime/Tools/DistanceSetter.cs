using UnityEngine;

namespace Tools
{
    [ExecuteInEditMode]
    public class DistanceSetter : MonoBehaviour
    {
        [SerializeField] private Transform _objectToMove;
        [SerializeField] private Transform _objectToSetDistanceTo;
        
        [Space]
        [SerializeField] private float _distance;
        [SerializeField] private bool _setDistance = true;

        private void Update()
        {
            if (!_setDistance) return;
            _objectToMove.position = _objectToSetDistanceTo.forward * _distance;
        }
    }
}