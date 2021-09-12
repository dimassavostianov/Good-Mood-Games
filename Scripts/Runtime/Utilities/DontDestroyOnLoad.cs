using UnityEngine;

namespace Scripts.Runtime.Utilities
{
    public class DontDestroyOnLoad : MonoBehaviour
    {
        private static bool _created = false;


        void Awake()
        {
            if (!_created)
            {
                DontDestroyOnLoad(gameObject);
                _created = true;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}