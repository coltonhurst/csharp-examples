/*
    A simple Tuple example

    Read more here: https://docs.microsoft.com/en-us/dotnet/csharp/tuples
*/

using System;

public class TupleExample
{
    public static void Main(string[] args)
    {
        // creating tuples
        var unnamedTuple = ("apple", "banana");
        var namedTuple = (first: "one", second: "two");
        Console.WriteLine(namedTuple);

        // get a tuple from a function
        Console.WriteLine(GetATuple());

        // tuple deconstruction
        var (leftItem, rightItem) = GetATuple();
        Console.WriteLine(leftItem + rightItem);
    }

    public static (int, int) GetATuple()
    {
        return (1, 2);
    }
}