using UnityEngine;

namespace Tools.Collision
{
    public class DestroyOnCollision : MonoBehaviour
    {
        [SerializeField] private LayerMask _layerMask;
        
        private void OnCollisionEnter(UnityEngine.Collision other)
        {
            TryDestroy(other.gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            TryDestroy(other.gameObject);
        }
        
        private void TryDestroy(GameObject @object)
        {
            var canDestroy = _layerMask == (_layerMask | (1 << @object.layer));
            if (!canDestroy) return;

            Destroy(@object);
        }
    }
}