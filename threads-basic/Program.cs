/*
    Here is a simple threading example in C#.

    On a single core system, the OS must allocate "slices"
    of time to each thread (on Windows around 20ms each) to
    simulate concurrency, resulting in blocks of A's and B's.
    
    On a multi core system, the two threads can actually execute in parallel.
    In this example we still get blocks of A's and B's due to subtleties
    in how `Console` handles concurrent requests.

    Notes:

    - A thread's `IsAlive` property will return true once it's started and until it ends.
    - Once ended, a thread cannot restart. It ends when the delegate passed to the Thread's
      constructor finishes executing.
    - You can name threads for debugging purposes (`Name` property). You can only name it once.
    - The static `Thread.CurrentThread` property gives the currently executing thread.
      Ex: `Console.WriteLine(Thread.CurrentThread.Name);`
*/

using System;
using System.Threading;

namespace threads_basic
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t = new Thread(WriteA);      // Kick off a new thread (passing in the WriteA func)
            t.Start();                          // Start running SayHello()

            // At the same time, do something different on the main thread (write some B's)
            for (int i = 0; i < 1000; i++) {
                Console.Write("B");
            }

            Console.WriteLine();
        }

        public static void WriteA()
        {
            for (int i = 0; i < 1000; i++) {
                Console.Write("A");
            }
        }
    }
}

/*
    The output will usually be a mix of A's and B's, like so:

    BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
    AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABAABBBBBBBBBBBBBBBBBBBBBBBBBBBBBABB
    BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB
    BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBABBBBBBBBBBBBBBBBBABB
    BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB
    BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB
    BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB
    BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB
    BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB
    BBBBBBBBBBBBBBBBBBAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
    AABAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
    AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
    AAAABBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB
    BBBBBBBBBBBBBBBBBBBAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABAAAAAAABAAAAAAAAAAAAAAAA
    AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
    AAAAAAAAAAAAAAAAAABBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB

    ... etc (newlines in output added for readability)
*/