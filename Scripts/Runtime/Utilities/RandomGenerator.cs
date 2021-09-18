namespace GoodMoodGames.Scripts.Runtime.Utilities
{
    public static class RandomGenerator
    {
        public static int GetRandom(int min, int max) => UnityEngine.Random.Range(min, max + 1);
        public static float GetRandom(float min, float max) => UnityEngine.Random.Range(min, max);
    }
}