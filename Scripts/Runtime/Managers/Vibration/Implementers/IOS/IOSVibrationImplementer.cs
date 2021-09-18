#if UNITY_IOS && !UNITY_EDITOR

using System.Runtime.InteropServices;

namespace GoodMoodGames.Scripts.Runtime.Managers.Vibration.Implementers.IOS
{
    public sealed class IOSVibrationImplementer : VibrationImplementer
    {
        #region __Internal

        [DllImport ( "__Internal" )]
        private static extern bool _HasVibrator();

        [DllImport("__Internal")]
        private static extern void _VibrateDefault();

        [DllImport("__Internal")]
        private static extern void _VibratePeek();

        [DllImport("__Internal")]
        private static extern void _VibratePop();

        [DllImport("__Internal")]
        private static extern void _VibrateWarning();

        #endregion

        public override bool HasVibrator() => _HasVibrator();
        
        public void Vibrate(IOSVibrationType vibrationType)
        {
            switch (vibrationType)
            {
                case IOSVibrationType.Default:
                    _VibrateDefault();
                    break;
                case IOSVibrationType.Peek:
                    _VibratePeek();
                    break;
                case IOSVibrationType.Pop:
                    _VibratePop();
                    break;
                case IOSVibrationType.Warning:
                    _VibrateWarning();
                    break;
                default: return;
            }
        }
    }
}

#endif