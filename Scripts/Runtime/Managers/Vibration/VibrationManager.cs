using Scripts.Runtime.Managers.Vibration.Implementers;
using UnityEngine;

namespace Scripts.Runtime.Managers.Vibration
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
#elif UNITY_IOS
            Implementer = new IOSVibrationImplementer();
#elif UNITY_ANDROID
            Implementer = new AndroidVibrationImplementer();
#endif

            HasVibrator = Implementer.HasVibrator();
        }

        public static void Vibrate()
        {
            if (!VibrationsEnabled || !HasVibrator) return;
            Implementer.VibrateOnce();
        }

        public static void Vibrate(long duration)
        {
            if (!VibrationsEnabled || !HasVibrator) return;
            Implementer.VibrateOnce(duration);
        }

        public static void VibrateWarning()
        {
            if (!VibrationsEnabled || !HasVibrator) return;
            Implementer.VibrateWarning();
        }

        public static void VibrateWarning(long duration, long delay)
        {
            if (!VibrationsEnabled || !HasVibrator) return;
            Implementer.VibrateWarning(duration, delay);
        }
    }
}