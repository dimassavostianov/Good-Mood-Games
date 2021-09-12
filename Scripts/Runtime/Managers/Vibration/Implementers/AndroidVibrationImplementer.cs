#if UNITY_ANDROID && !UNITY_EDITOR

using UnityEngine;

namespace Scripts.Runtime.Managers.Vibration.Implementers
{
    public class AndroidVibrationImplementer : VibrationImplementer
    {
        private static AndroidJavaObject _vibratorService;

        public AndroidVibrationImplementer()
        {
            var unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            var currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
            var context = currentActivity.Call<AndroidJavaObject>("getApplicationContext");
            var contextClass = new AndroidJavaClass("android.content.Context");
            var contextVibratorService = contextClass.GetStatic<string>("VIBRATOR_SERVICE");
            
            _vibratorService = context.Call<AndroidJavaObject>("getSystemService", contextVibratorService);
        }
        
        public override bool HasVibrator() => _vibratorService.Call<bool>("hasVibrator");

        public override void VibrateOnce(long duration = DefaultVibrationDuration) =>
            _vibratorService.Call("vibrate", duration);

        public override void VibrateWarning(long duration = DefaultVibrationDuration,
            long delay = WarningVibrationDelay)
        {
            var warningVibrationPattern = new [] { 0, duration, delay, duration, delay, duration };
            _vibratorService.Call("vibrate", warningVibrationPattern, -1);
        }
    }
}

#endif