namespace GoodMoodGames.Scripts.Runtime.Managers.Vibration.Interfaces
{
    public abstract class VibrationImplementer
    {
        protected const long DefaultVibrationTime = 30;
        protected const long WarningVibrationDelay = 60;
        
        public abstract bool CheckVibrator();
        
        public abstract void VibrateOnce();
        public abstract void VibrateWarning();
    }
}