using GoodMoodGames.Scripts.Runtime.Managers.Vibration.Interfaces;
using UnityEngine;

#if UNITY_IOS || UNITY_ANDROID
using GoodMoodGames.Scripts.Runtime.Managers.Vibration.Implementers;
#endif

namespace GoodMoodGames.Scripts.Runtime.Managers.Vibration
{
    public static class VibrationManager
    {
        public static bool VibrationsEnabled => PlayerPrefs.GetInt("VibrationManager_VibrationsEnabled", 1) == 1;

        public static void EnableVibrations(bool enable) =>
            PlayerPrefs.SetInt("VibrationManager_VibrationsEnabled", enable ? 1 : 0);

        private static readonly VibrationImplementer Implementer;
        private static readonly bool HasVibrator;
        
        static VibrationManager()
        {
#if UNITY_EDITOR
            return;
#endif

#if UNITY_IOS
            Implementer = new IOSVibrationImplementer();
#elif UNITY_ANDROID
            Implementer = new AndroidVibrationImplementer();
#endif

            HasVibrator = Implementer.CheckVibrator();
        }

        public static void Vibrate()
        {
            if (!(VibrationsEnabled && HasVibrator)) return;
            Implementer.VibrateOnce();
        }

        public static void VibrateWarning()
        {
            if (!(VibrationsEnabled && HasVibrator)) return;
            Implementer.VibrateWarning();
        }
    }
}