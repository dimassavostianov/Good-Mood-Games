namespace Scripts.Runtime.Managers.Vibration.Implementers
{
    public abstract class VibrationImplementer
    {
        protected const long DefaultVibrationDuration = 30;
        protected const long WarningVibrationDelay = 60;
        
        public abstract bool HasVibrator();
        
        public abstract void VibrateOnce(long duration = DefaultVibrationDuration);
        public abstract void VibrateWarning(long duration = DefaultVibrationDuration, long delay = WarningVibrationDelay);
    }
}