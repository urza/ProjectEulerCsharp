using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEulerCsharp
{
    public static class IEnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> @enum, Action<T> mapFunction)
        {
            foreach (var item in @enum) mapFunction(item);
        }
    }

    public static class Int32Extensions
    {
        public static IEnumerable<int> To(this int first, int last)
        {
            for (int i = first; i <= last; i++)
            {
                yield return i;
            }
        }

        public static bool IsPalindrome(this int val)
        {
            var digits = val.ToString().ToCharArray();
            return digits.SequenceEqual(digits.Reverse());
        }
    }
}