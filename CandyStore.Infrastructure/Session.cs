using CandyStore.Contracts.Infrastructure;
using System;
using System.Collections.Generic;

namespace CandyStore.Infrastructure
{
    public class Session : ISession
    {
        private readonly IDictionary<string, object> _values;

        public Session()
        {
            _values = new Dictionary<string, object>();
        }

        public TValue Get<TValue>(string key)
        {
            return (TValue)Get(key);
        }

        public object Get(string key)
        {
            if (!_values.ContainsKey(key))
            {
                throw new ArgumentException("Key not present in session.");
            }

            return _values[key];
        }

        public void Add(string key, object value)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException("Cannot set null or empty value as a key.");
            }

            _values[key] = value;
        }

        public void Clear()
        {
            _values.Clear();
        }
    }
}
