using UnityEngine;

namespace GoodMoodGames.Scripts.Runtime.Tools
{
    public static class PlayerPrefsExtension
    {
        public static void SetBool(string name, bool value) => PlayerPrefs.SetInt(name, value ? 1 : 0);
        public static bool GetBool(string name) => PlayerPrefs.GetInt(name) == 1;
    }
}