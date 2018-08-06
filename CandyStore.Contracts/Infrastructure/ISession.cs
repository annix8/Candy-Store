namespace CandyStore.Contracts.Infrastructure
{
    public interface ISession
    {
        TValue Get<TValue>(string key);
        void Add(string key, object value);
        void Clear();
    }
}
