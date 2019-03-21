using System;

namespace DemoApp
{
    static class LinkedStackOperators
    {
        public static LinkedStack<V> Where<V>(this LinkedStack<V> source, Func<V, bool> check)
        {
            var target = new LinkedStack<V>();
            source.Peek(delegate(V item)
            {
                if(check(item)) target.Push(item);
            });
            return target;
        }

        public static LinkedStack<W> Select<V, W>(this LinkedStack<V> source, Func<V, W> change)
        {
            var target = new LinkedStack<W>();
            source.Peek(item => target.Push(change(item)));
            return target;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var intervals = new LinkedStack<Interval>();
            intervals.Push(new Interval(13, 21));
            intervals.Push(new Interval(17, 32));
            intervals.Push(new Interval(14, 43));
            intervals.Push(new Interval(15, 24));
            intervals.Push(new Interval(16, 55));
            Console.WriteLine("All Intervals");
            intervals.Peek(Console.WriteLine);
            //var selection = intervals.Where(i => (i.Seconds % 2) == 1).Select(i => i.Time / 60.0);
            var selection = from i in intervals where (i.Seconds % 2) == 1 select i.Time / 60.0;
            Console.WriteLine("Minutes in odd intervals");
            selection.Peek(t => Console.WriteLine($"{t:0.00}"));
        }
    }
}
