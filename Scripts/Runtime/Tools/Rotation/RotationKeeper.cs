using UnityEngine;

namespace GoodMoodGames.Scripts.Runtime.Tools.Rotation
{
    public class RotationKeeper : MonoBehaviour
    {
        [SerializeField] private Vector3 _angles = Vector3.zero;
        [SerializeField] private bool _useAngles;
        
        [Space]
        [SerializeField] private bool _x = true; 
        [SerializeField] private bool _y = true; 
        [SerializeField] private bool _z = true;

        [Space]
        [SerializeField] private bool _doLocal = true;

        private bool X => _x;
        private bool Y => _y;
        private bool Z => _z;

        private Vector3 _idleRotation;

        private void Start()
        {
            _idleRotation = _useAngles ? _angles : transform.eulerAngles;
        }

        private void Update()
        {
            var eulerAngles = transform.eulerAngles;
            eulerAngles = new Vector3(X ? _idleRotation.x : eulerAngles.x,
                Y ? _idleRotation.y : eulerAngles.y,
                Z ? _idleRotation.z : eulerAngles.z);

            if (_doLocal)
            {
                transform.localRotation = Quaternion.Euler(eulerAngles);
            }
            else
            {
                transform.rotation = Quaternion.Euler(eulerAngles);
            }
        }
    }
}