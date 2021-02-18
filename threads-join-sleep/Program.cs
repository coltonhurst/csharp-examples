/*
    In this example, we look at the basics of Thread.Join() and Thread.Sleep().
    We create a new thread `t`, passing the function `Do` to the constructor.
    We start the thread with `t.Start()`, and then "join" thread `t` with
    the main thread, so the main thread waits until thread `t` is complete to continue.

    Halfway through the Do() function, we sleep (on that thread, `t`) for 1 second.

    Notes:

    - "Thread.Sleep(0) relinquishes the thread's current time slice immediately,
      voluntarily handing over the CPU to other threads."
    - "Thread.Yield() does the same thing - except that it relinquishes only to
      threads running on the same processor.
    - "While waiting on a Sleep or Join, a thread is blocked."
    - A thread is considered "blocked" if the thread execution is paused (like when
      the thread is sleeping or waiting for another thread via Join).
    - "A blocked thread immediately yields its processor time slice, and from then on
      consumes no processor time until its blocking condition is satisfied."
    - Use ThreadState to test if a thread is blocked.
    - Each thread "ties up" about 1MB of memory as long as it's alive.

    - When a thread blocks or unblocks, the OS performs a context switch, which has small
      overhead (~1-2 microseconds).
    - An operation that spends most of it's time waiting for something is called "I/O-bound".
      These usually involve input or output. Ex: Console.ReadLine(), downloading a web page,
      Thread.Sleep().
    - An operation that spends most of it's time performing CPU work is called "compute-bound".
*/

using System;
using System.Threading;

namespace threads_join_sleep
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t = new Thread(Do);

            t.Start();
            t.Join();   // by using Join(), we wait until thread `t` has finished to continue in this thread
            
            Console.WriteLine("\nThread t has ended!");
        }

        /*
            This function is executed when thread `t` starts.
            It sleeps for 1 second halfway through.
        */
        public static void Do()
        {
            for (int i = 0; i < 1000; i++) {
                Console.Write("a");

                // halfway through, sleep for 1 second
                if (i == 499) {
                    Thread.Sleep(1000);
                }
            }
        }
    }
}
