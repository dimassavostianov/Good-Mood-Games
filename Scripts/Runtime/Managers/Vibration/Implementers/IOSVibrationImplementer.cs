#if UNITY_IOS

using GoodMoodGames.Scripts.Runtime.Managers.Vibration.Interfaces;
using System.Runtime.InteropServices;

namespace GoodMoodGames.Scripts.Runtime.Managers.Vibration.Implementers
{
    public class IOSVibrationImplementer : VibrationImplementer
    {
        #region __Internal

        [DllImport ( "__Internal" )]
        private static extern bool _HasVibrator();

        [DllImport("__Internal")]
        private static extern void _Vibrate(long defaultVibrationTime);

        [DllImport("__Internal")]
        private static extern void _VibrateWarning(long defaultVibrationTime, long warningVibrationDelay);

        #endregion

        public override bool CheckVibrator() => _HasVibrator();
        
        public override void VibrateOnce() => _Vibrate(DefaultVibrationTime);
        public override void VibrateWarning() => _VibrateWarning(DefaultVibrationTime, WarningVibrationDelay);
    }
}

#endif