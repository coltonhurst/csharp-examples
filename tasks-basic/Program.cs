/*
    This is a basic example of Tasks in C#.
    A Task represents a concurrent operation that may or may not be backed by a thread.

    Notes

    - Tasks are compositional- they can be chained via continuations.
    - Tasks use pooled threads by default (background threads). When the main thread ends,
      so do any that were made (so you may need to block the main thread after starting the task).
      For example...If this was our only code, we would need something to block on the main thread
      so the task could finish:

        Task.Run(() => Console.WriteLine("Hello"));
        Console.ReadLine(); // add this so above task would finish
    
    - The default tasks running on pooled threads are better for short-running compute-bound work.
    - When running multiple long running / blocking operations, don't use a pooled thread...
      Prevent the use of a pooled thread like this: `Task t = Task.Factory.StartNew (() => {...});`
*/

using System;
using System.Threading;
using System.Threading.Tasks;

namespace tasks_basic
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create & run task `t`. It sleeps for 2 seconds and then prints: Hello
            Task t = Task.Run(()=> {
                Thread.Sleep(2000);
                Console.WriteLine("Hello");
            });

            Console.WriteLine(t.IsCompleted);       // this will be false

            t.Wait();                               // this is like calling Join() on a thread
                                                    // if we don't have this, task `t` will not finish in time
        }
    }
}
