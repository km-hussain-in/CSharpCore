using System;
using static System.Linq.Enumerable;

namespace LinqTest
{
    static class Program
    {

        private static Interval CombineIntervals(Interval a, Interval b)
        {
            return new Interval(a.Minutes + b.Minutes, a.Seconds + b.Seconds);
        }

        public static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //var squares = numbers.Where(n => (n % 2) == 1).Select(n => n * n);
            var squares = from n in numbers where (n % 2) == 1 select n * n;
            Console.WriteLine("Selected integers from array");
            foreach (var entry in squares)
                Console.WriteLine(entry);
            int limit = args.Length > 0 ? int.Parse(args[0]) : 0;
            double distance = 500;
            SimpleStack<Interval> intervals = new SimpleStack<Interval>();
            intervals.Push(new Interval(5, 41));
            intervals.Push(new Interval(4, 52));
            intervals.Push(new Interval(7, 23));
            intervals.Push(new Interval(3, 34));
            intervals.Push(new Interval(6, 15));
            intervals.Push(new Interval(2, 6));
            var selection = from i in intervals
                            where i.Time > limit
                            orderby i.Seconds descending
                            select new
                            {
                                Duration = i,
                                Speed = 3.6 * distance / i.Time
                            };
            Console.WriteLine("Selected Intervals from stack");
            foreach (var entry in selection)
                Console.WriteLine("{0}\t{1:0.0}", entry.Duration, entry.Speed);

            Interval sum = (from i in intervals where i.Time > limit select i).Aggregate(CombineIntervals);
            Console.WriteLine("Total Interval = {0}", sum);
        }
    }
}
