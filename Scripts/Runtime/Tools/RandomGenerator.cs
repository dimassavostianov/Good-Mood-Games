namespace GoodMoodGames.Scripts.Tools
{
    public static class RandomGenerator
    {
        public static readonly System.Random Random = new System.Random();

        public static int GetRandom(int min, int max)
        {
            return UnityEngine.Random.Range(min, max + 1);
        }
        
        public static float GetRandom(float min, float max)
        {
            return UnityEngine.Random.Range(min, max);
        }
    }
}