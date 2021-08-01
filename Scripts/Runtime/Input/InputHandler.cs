namespace GoodMoodGames.Scripts.Runtime.Input
{
    public static class InputHandler
    {
        public static bool InputEnabled { get; private set; } = true;
        
        
        public static void EnableMultiTouch(bool enable = true)
        {
            UnityEngine.Input.multiTouchEnabled = enable;
        }
        
        public static void EnableInput(bool enable = true)
        {
            InputEnabled = enable;
        }
    }
}