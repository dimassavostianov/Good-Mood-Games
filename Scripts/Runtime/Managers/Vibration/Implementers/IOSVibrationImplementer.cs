#if UNITY_IOS && !UNITY_EDITOR

using System.Runtime.InteropServices;

namespace Scripts.Runtime.Managers.Vibration.Implementers
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

        public override bool HasVibrator() => _HasVibrator();
        
        public override void VibrateOnce(long duration = DefaultVibrationDuration) => _Vibrate(duration);
        public override void VibrateWarning(long duration = DefaultVibrationDuration,
            long delay = WarningVibrationDelay) => _VibrateWarning(duration, delay);
    }
}

#endif