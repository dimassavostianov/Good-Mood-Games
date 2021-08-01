using UnityEngine;

namespace GoodMoodGames.Scripts.Runtime.Tools
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