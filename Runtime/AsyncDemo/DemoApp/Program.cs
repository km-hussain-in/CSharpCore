using System;
using System.Threading.Tasks;

namespace DemoApp
{
    class Program
    {
        static void DoComputation()
        {
            Console.Write("Computing...");
            Computation c = new Computation();
            long r = c.Compute(1, 20);
            Console.WriteLine("Done!");
            Console.WriteLine("Result = {0}", r);
            Console.WriteLine("Calculation count = {0}", c.Calculations);            
        }
 
        static Task DoComputationRaw()
        {
            Console.Write("Computing...");
            Computation c = new Computation();
            return c.ComputeAsync(1, 20)
                    .ContinueWith(t => 
                    {
                        long r = t.Result;
                        Console.WriteLine("Done!");
                        Console.WriteLine("Result = {0}", r);
                        Console.WriteLine("Calculation count = {0}", c.Calculations);
                    });
        }

        static async Task DoComputationNeat()
        {
            Console.Write("Computing...");
            Computation c = new Computation();
            long r = await c.ComputeAsync(1, 20);
            Console.WriteLine("Done!");
            Console.WriteLine("Result = {0}", r);
            Console.WriteLine("Calculation count = {0}", c.Calculations);
        }

        static async Task DoComputationSplit()
        {
            Console.Write("Computing...");
            Computation c = new Computation();
            var lower = c.ComputeAsync(1, 10);
            var upper = c.ComputeAsync(11, 20);
            long[] r = await Task.WhenAll(lower, upper);
            Console.WriteLine("Done!");
            Console.WriteLine("Result = {0}", r[0] + r[1]);
            Console.WriteLine("Calculation count = {0}", c.Calculations);
        }        

        static async Task DoComputationFast()
        {
            Console.Write("Computing...");
            Computation c1 = new Computation();
            var lower = c1.ComputeAsync(1, 14);
            Computation c2 = new Computation();
            var upper = c2.ComputeAsync(15, 20);
            long[] r = await Task.WhenAll(lower, upper);
            Console.WriteLine("Done!");
            Console.WriteLine("Result = {0}", r[0] + r[1]);
            Console.WriteLine("Calculation count = {0}", c1.Calculations + c2.Calculations);
        }                

        static void Main(string[] args)
        {
            //DoComputation();
            var job = DoComputationFast();
            int n;
            for(n = 0; !job.IsCompleted; ++n)
            {
                Console.Write(".");
                job.Wait(500);
            }
            Console.WriteLine("Calculation time: {0:0.0} sec", 0.5 * n);
       }
    }
}
