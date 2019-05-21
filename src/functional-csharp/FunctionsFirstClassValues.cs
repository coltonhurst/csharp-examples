/*
    Example of Functions as first class values.

    In functional programming, there should be no state mutation.
*/

using System;
using System.Linq;
using System.Collections.Generic;

namespace functional_csharp
{
    public static class FunctionsFirstClassValues
    {
        public static void Main(string[] args)
        {
            // Functions are first class values
            Func<int, int> triple = x => x * 3;
            var range = Enumerable.Range(1, 3);
            var triples = range.Select(triple);

            triples.ForEach(i => Console.Write(i + " ")); nl();

            // In functional programming, sorting or filtering the list should
            // not modify the list (no 'destructive updates' ever)
            Func<int, bool> isOdd = x => x % 2 == 1;
            int[] original = {7, 6, 1};
            var sorted = original.OrderBy(x => x);
            var filtered = original.Where(isOdd);

            original.ForEach(i => Console.Write(i + " ")); nl();
            sorted.ForEach(i => Console.Write(i + " ")); nl();
            filtered.ForEach(i => Console.Write(i + " ")); nl();
        }

        // Extension method on any class that implements IEnumerable<T>
        public static void ForEach<T>(this IEnumerable<T> list, Action<T> action) {
            foreach (var item in list) {
                action(item);
            }
        }

        public static void nl() => Console.WriteLine();
    }
}