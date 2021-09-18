using UnityEngine;
using GoodMoodGames.Scripts.Runtime.Managers.Vibration.Implementers.IOS;

#if UNITY_ANDROID && !UNITY_EDITOR
using GoodMoodGames.Scripts.Runtime.Managers.Vibration.Implementers.Android;
#endif

namespace GoodMoodGames.Scripts.Runtime.Managers.Vibration
{
    public static class VibrationManager
    {
        public static bool VibrationsEnabled => PlayerPrefs.GetInt("VibrationManager_VibrationsEnabled", 1) == 1;

        public static void EnableVibrations(bool enable) =>
            PlayerPrefs.SetInt("VibrationManager_VibrationsEnabled", enable ? 1 : 0);

        private const long DefaultAndroidVibrationDuration = 30;
        private const long DefaultAndroidWarningVibrationDelay = 60;
        
        private static readonly bool HasVibrator;

#if UNITY_ANDROID && !UNITY_EDITOR
        private static readonly AndroidVibrationImplementer AndroidVibrationImplementer;
#elif UNITY_IOS && !UNITY_EDITOR
        private static readonly IOSVibrationImplementer IOSVibrationImplementer;
#endif

        static VibrationManager()
        {
#if UNITY_EDITOR
            return;

#elif UNITY_ANDROID
            AndroidVibrationImplementer = new AndroidVibrationImplementer();
            HasVibrator = AndroidVibrationImplementer.HasVibrator();
#elif UNITY_IOS
            IOSVibrationImplementer = new IOSVibrationImplementer();
            HasVibrator = IOSVibrationImplementer.HasVibrator();
#endif
        }

        public static void Vibrate(long androidVibrationDuration = DefaultAndroidVibrationDuration,
            IOSVibrationType iosVibrationType = IOSVibrationType.Default)
        {
            if (!(VibrationsEnabled && HasVibrator)) return;

#if UNITY_EDITOR
            return;
            
#elif UNITY_ANDROID
            AndroidVibrationImplementer.Vibrate(androidVibrationDuration);
#elif UNITY_IOS
            IOSVibrationImplementer?.Vibrate(iosVibrationType);
#endif
        }

        public static void VibrateWarning(long duration = DefaultAndroidVibrationDuration,
            long delay = DefaultAndroidWarningVibrationDelay)
        {
            if (!(VibrationsEnabled && HasVibrator)) return;

#if UNITY_EDITOR
            return;

#elif UNITY_ANDROID
            AndroidVibrationImplementer.VibrateWarning(duration, delay);
#elif UNITY_IOS
            IOSVibrationImplementer?.Vibrate(IOSVibrationType.Warning);
#endif
        }
    }
}