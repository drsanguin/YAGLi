using System;
using System.Collections.Generic;

namespace YAGLi.Extensions.Collection
{
    public static class ForEachExtension
    {
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var element in source.ReplaceByEmptyIfNull())
            {
                action(element);
            }

            return source;
        }
    }
}
