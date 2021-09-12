using UnityEngine;

namespace Scripts.Runtime.Utilities.Rotation
{
    [ExecuteInEditMode]
    public class RotationSetter : MonoBehaviour
    {
        [SerializeField] private Transform _objectToRotate;
        [SerializeField] private Transform _objectToFace;
        
        [Space]
        [SerializeField] private bool _rotate = true;

        private void Update()
        {
            if (!_rotate) return;
            _objectToRotate.LookAt(_objectToFace == null
                ? Vector3.zero
                : _objectToFace.position);
        }
    }
}