using System;
using System.Collections.Generic;

namespace NetEasy
{
    internal static class InternalExtensions
    {
        internal static TValue GetOrCreate<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key, Func<TValue> factory)
        {
            if (dict.TryGetValue(key, out TValue value))
            {
                return value;
            }
            TValue obj = factory();
            dict.Add(key, obj);
            return obj;
        }
    }
}
