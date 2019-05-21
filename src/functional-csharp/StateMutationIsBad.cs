/*
    In functional programming, there should be no state mutation.

    Below, if we didn't use nums.OrderBy(), but used a method that did
    destructive updates, the sums wouldn't both be zero.
*/

using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace functional_csharp
{
    public static class StateMutationIsBad
    {
        public static void Main(string[] args)
        {
            var nums = Enumerable.Range(-10000, 20001); // range of nums from -10k to 10k

            Action task1 = () => Console.WriteLine(nums.Sum());
            Action task2 = () => { nums.OrderBy(x => x); Console.WriteLine(nums.Sum()); };  // we need that OrderBy

            Parallel.Invoke(task1, task2);
        }
    }
}