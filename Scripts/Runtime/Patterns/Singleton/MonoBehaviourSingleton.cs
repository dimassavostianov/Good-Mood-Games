using UnityEngine;

namespace GoodMoodGames.Scripts.Runtime.Patterns.Singleton
{
    public class MonoBehaviourSingleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<T>();

                    if (_instance == null)
                    {
                        GameObject go = new GameObject(typeof(T).Name);
                        DontDestroyOnLoad(go);
                    
                        _instance = go.AddComponent<T>();
                    }
                }
            
                return _instance;
            }
        }
    }
}