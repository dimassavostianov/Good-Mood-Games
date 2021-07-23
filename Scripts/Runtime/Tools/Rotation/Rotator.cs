using UnityEngine;
using Random = UnityEngine.Random;

namespace GoodMoodGames.Scripts.Tools.Rotation
{
    public class Rotator : MonoBehaviour
    {
        [SerializeField] private Transform _rotateObject;

        [Tooltip("Leave zero for random vector")] [SerializeField]
        private Vector3 _rotateVector = Vector3.zero;

        [Range(-1, 1)] [SerializeField] private int _rotateDirection = 1;


        [Space] [SerializeField] private float _minRotateSpeed = 1;
        [SerializeField] private float _maxRotateSpeed = 1;

        [Space] [SerializeField] private bool _rotate = true;

        [Space] [SerializeField] private bool _bounce;
        [SerializeField] private int _bounceClampAngle = 45;

        private Vector3 _currentEulerAngles;

        public float RotateSpeed { get; private set; }

        public bool Rotate
        {
            get => _rotate;
            set => _rotate = value;
        }

        public bool Bounce
        {
            get => _bounce;
            set => _bounce = value;
        }

        private void Start()
        {
            if (_rotateVector == Vector3.zero)
                _rotateVector = new Vector3(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));

            RotateSpeed = Random.Range(_minRotateSpeed, _maxRotateSpeed);
            _currentEulerAngles = _rotateObject.eulerAngles;
        }

        private void Update()
        {
            if (!Rotate) return;

            var direction = Bounce ? GetRotationDirection(Vector3.Scale(_currentEulerAngles, _rotateVector))
                : _rotateDirection;

            _currentEulerAngles += _rotateVector * RotateSpeed * direction * Time.deltaTime;
            _rotateObject.eulerAngles = _currentEulerAngles;
        }

        private int GetRotationDirection(Vector3 rotatedEuler)
        {
            var changeDirection = (rotatedEuler.x >= _bounceClampAngle && _rotateDirection > 0)
                                  | (rotatedEuler.x <= -_bounceClampAngle && _rotateDirection < 0)
                                  | (rotatedEuler.y >= _bounceClampAngle && _rotateDirection > 0)
                                  | (rotatedEuler.y <= -_bounceClampAngle && _rotateDirection < 0)
                                  | (rotatedEuler.z >= _bounceClampAngle && _rotateDirection > 0)
                                  | (rotatedEuler.z <= -_bounceClampAngle && _rotateDirection < 0);

            if (changeDirection) _rotateDirection = -_rotateDirection;
            return _rotateDirection;
        }
    }
}