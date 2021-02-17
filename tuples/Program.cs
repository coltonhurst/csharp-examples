/*
    This is an example of Tuples in C#.
    Tuples are value types in C#. They allow you to group multiple
    data elements together into a data structure. Often they are used
    to return multiple values from a function.
*/

using System;

namespace tuples
{
    class Program
    {
        static void Main(string[] args)
        {
            // create an unnamed and named tuple
            var unnamedTuple = ("apple", "banana", 5);
            var namedTuple = (first: "one", age: 100);
            Console.WriteLine(unnamedTuple);
            Console.WriteLine(unnamedTuple.Item2); // getting a specific item from the unnamed tuple

            Console.WriteLine(namedTuple);
            Console.WriteLine(namedTuple.age); // for named tuples we can get the item by the name given

            // get a tuple from a function
            Console.WriteLine(GetATuple());

            // tuple deconstruction
            var (name, age) = GetATuple();
            Console.WriteLine("Today {0} is turning {1}! Happy birthday {0}!", name, age);
        }

        public static (string, int) GetATuple()
        {
            return ("Joseph", 99);
        }
    }
}

/*
    This should be the output:

    (apple, banana, 5)
    banana
    (one, 100)
    100
    (Joseph, 99)
    Today Joseph is turning 99! Happy birthday Joseph!
*/