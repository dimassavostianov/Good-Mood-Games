#if UNITY_ANDROID

using GoodMoodGames.Scripts.Runtime.Managers.Vibration.Interfaces;
using UnityEngine;

namespace GoodMoodGames.Scripts.Runtime.Managers.Vibration.Implementers
{
    public class AndroidVibrationImplementer : VibrationImplementer
    {
        private static readonly AndroidJavaClass UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        private static readonly AndroidJavaObject CurrentActivity = UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        private static readonly AndroidJavaObject Vibrator = CurrentActivity.Call<AndroidJavaObject>("getSystemService", "vibrator");
        private static readonly AndroidJavaObject Context = CurrentActivity.Call<AndroidJavaObject>("getApplicationContext");

        private static readonly long[] WarningPattern =
        {
            DefaultVibrationTime, 
            WarningVibrationDelay, 
            DefaultVibrationTime,
            WarningVibrationDelay,
            DefaultVibrationTime
        };

        public override bool CheckVibrator() => Vibrator.Call<bool>("hasVibrator");

        public override void VibrateOnce() => Vibrator.Call("vibrate", DefaultVibrationTime);
        public override void VibrateWarning() => Vibrator.Call("vibrate", WarningPattern, -1); // -1 = do not repeat
    }
}

#endif