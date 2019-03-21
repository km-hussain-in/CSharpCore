using System;
using System.Threading;

namespace DemoApp
{
    class Program
    {
        [ThreadStatic]
        static int job;

        static int count;

        static void HandleJob(int id)
        {
            Interlocked.Increment(ref count);
            Console.WriteLine("Thread<{0}> has accepted job[{1}]", Thread.CurrentThread.ManagedThreadId, id);
            job = id;
            Worker.DoWork(id);
            Console.WriteLine("Thread<{0}> has finished job[{1}]", Thread.CurrentThread.ManagedThreadId, job);
        }

        static void Main(string[] args)
        {
            int n = args.Length > 0 ? int.Parse(args[0]) : 50;
            Thread child = new Thread(delegate()
            {
                HandleJob(n);
            });
            child.IsBackground = n > 75;
            child.Start();
            HandleJob(60);
            Console.WriteLine("Number of jobs = {0}", count);
        }
    }
}
