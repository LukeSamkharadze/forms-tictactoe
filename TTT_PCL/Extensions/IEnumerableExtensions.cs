using System;
using System.Collections.Generic;

namespace TTT_PCL.Extensions
{
    public static class IEnumerableExtensions
    {
        public static TSource MoveNextOrFirst<TSource>(this IEnumerable<TSource> enumerable,TSource node) where TSource : class
        {
            var enumerator = enumerable.GetEnumerator();
            enumerator.MoveNext();

            bool flag = false;

            foreach (var item in enumerable)
            {
                if ( item == node)
                {
                    if (enumerator.MoveNext())
                        return enumerator.Current;
                    else
                    {
                        enumerator = enumerable.GetEnumerator();
                        enumerator.MoveNext();
                        return enumerator.Current;
                    }   
                }
                flag = enumerator.MoveNext();
            }

            return null;
        }
    }
}
