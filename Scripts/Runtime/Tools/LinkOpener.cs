using UnityEngine;

namespace Runtime.Scripts.Tools
{
    public class LinkOpener : MonoBehaviour
    {
        [SerializeField] string _url;

        public void OpenURL()
        {
            Application.OpenURL(_url);
        }
    }
}