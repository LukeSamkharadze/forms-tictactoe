using System;
using System.Collections.Generic;

namespace TTT_PCL.Extentions
{
    public static class DictionaryExtensions
    {
        public static void SetupKeys<TSource1,TSource2>(this Dictionary<TSource1, TSource2> dictionary, IEnumerable<TSource1> keys, TSource2 defaultValue)
        {
            foreach (var key in keys)
                dictionary.Add(key, defaultValue);
        }

        public static void SetupValues<TSource1, TSource2>(this Dictionary<TSource1, TSource2> dictionary, IEnumerable<TSource1> keys, TSource2 defaultValue)
        {
            foreach (var key in keys)
                dictionary[key] = defaultValue;
        }
    }
}
