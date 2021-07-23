namespace GoodMoodGames.Scripts.Patterns.Pool.Interfaces
{
    public interface IObjectPool<T> where T : PoolableObject
    {
        T Get();
        void Release(T @object);
        void ReleaseAll();
    }
}