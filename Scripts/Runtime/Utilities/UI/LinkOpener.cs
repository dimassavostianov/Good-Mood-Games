using UnityEngine;

namespace GoodMoodGames.Scripts.Runtime.Utilities.UI
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