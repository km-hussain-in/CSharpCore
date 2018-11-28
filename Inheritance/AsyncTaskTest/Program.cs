using System;
using System.Threading.Tasks;

namespace AsyncTaskTest
{
    static class Program
    {
        /*	
        private static Task DoComputation()
        {
            Console.Write("Computing...");

            Computation c = new Computation();

            return c.ComputeAsync(1, 20)
                .ContinueWith(t =>
                {
                    long r = t.Result;
                    Console.WriteLine("Done!");
                    Console.WriteLine("Result = {0}", r);
                });
        }
        */

        //async modifier indicates this method returns a Task using await statement
        private static async Task DoComputation()
        {
            Console.Write("Computing...");

            Computation c = new Computation();
            long r = await c.ComputeAsync(1, 20); //returns the task to the caller

            //following code continues after the awaited task is completed
            Console.WriteLine("Done!");
            Console.WriteLine("Result = {0}", r);

        }

        public static void Main()
        {
            Task job = DoComputation();
            while (!job.IsCompleted)
            {
                Console.Write(".");
                Task.Delay(500).Wait();
            }
        }
    }
}
