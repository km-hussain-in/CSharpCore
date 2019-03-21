using System;
using System.Linq;

namespace DemoApp
{

    class Program
    {
        static long Calculated(int value)
        {
            Console.Write(".");
            for(int t = Environment.TickCount + 100 * value; t > Environment.TickCount;);
            return value * value;
        }

        static void Main(string[] args)
        {
            var intervals = new LinkedStack<Interval>
            {
                new Interval(13, 21),
                new Interval(17, 32),
                new Interval(14, 43),
                new Interval(15, 24),
                new Interval(16, 55)
            };
            Console.WriteLine("All Intervals");
            foreach(Interval i in intervals)
                Console.WriteLine(i);

            int m = args.Length > 0 ? int.Parse(args[0]) : 15;
            var selection = from i in intervals
                            where i.Minutes >= m
                            orderby i.Seconds
                            select new
                            {
                                Duration = i,
                                Distance = i.Time / 480.0
                            };
            Console.WriteLine("Distances for big Intervals");
            foreach(var entry in selection)
                Console.WriteLine("{0}\t{1:0.00}", entry.Duration, entry.Distance);

            int start = Environment.TickCount;
            Console.Write("Calculating");
            var sequence = from v in Enumerable.Range(1, 20).AsParallel() select Calculated(v);
            long total = sequence.Sum();
            Console.WriteLine("Done!");
            Console.WriteLine("Result = {0}", total);
            Console.WriteLine("Calculation time: {0:0.0} sec", 0.001 * (Environment.TickCount - start));
        }
    }
}
