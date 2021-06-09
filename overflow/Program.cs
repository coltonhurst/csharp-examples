/*
    In C#, arithmetic operations on integrals can overflow during runtime.
    The behavior is a "wraparound" behavior...

    The `checked` keyword tells the runtime to throw an OverflowException
    rather than overflowing silently.
    
    We can also avoid this (doing the opposite) with the `unchecked` keyword.

    Example:

    2147483647 is the max number for a Int32.
    This means 2147483647 (base 10) = 01111111 11111111 11111111 11111111 (base 2)
    if we add 1 to that number... it will become 10000000 00000000 00000000 00000000 (base 2)
    This is equal to -2147483648 (base 10), which is the lowest number a Int32 in C# can be.

    That's why we call it a "wraparound" behavior... because when you go above the max
    value, you "wraparound" to the smallest value. As you keep increasing, you go from
    negative to 0 to positive, and back "around" again.

    You can see this in the example below, and how the overflow "wraparound" behavior works.
*/

using System;

namespace overflow
{
    class Program
    {
        static void Main(string[] args)
        {
            Int32 value = Int32.MaxValue;
            Console.WriteLine("The maximum Int32 value is: " + value + " (base 10)");

            string binaryValue = Convert.ToString(value, 2);
            Console.WriteLine("This in binary is: " + binaryValue + " (base 2)\n");

            Console.WriteLine("Now we will add 1, giving us:");
            Console.WriteLine("This " + (value + 1) + " (base 10)");
            Console.WriteLine("This in binary is: " + Convert.ToString(value + 1, 2) + " (base 2)\n");
        
            Console.WriteLine("We can also check if overflow happens...");

            try
            {
                checked
                {
                    Console.WriteLine("This will overflow: " + (value + 1));
                }
            } catch (OverflowException) {
                Console.WriteLine("We caught the OverflowException!");
            }
        }
    }
}
