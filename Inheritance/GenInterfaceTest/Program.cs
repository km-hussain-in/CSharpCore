using System;

namespace GenInterfaceTest
{
    static class Program
    {

        private static T Select<T>(T first, T second) where T : IComparable<T>
        {
            if (first.CompareTo(second) > 0)
                return first;
            return second;

        }

        private static void PrintStack(IStackReader<object> store)
        {
            for (int i = 0; !store.Empty(); ++i)
            {
                if (i > 0) Console.Write(", ");
                Console.Write(store.Pop());
            }
            Console.WriteLine();
        }

        public static void Main()
        {
            double sd = Select(6.5, 5.6);
            Console.WriteLine("Selected double = {0}", sd);
            Interval si = Select(new Interval(2, 30), new Interval(3, 45));
            Console.WriteLine("Selected Interval = {0}", si);

            SimpleStack<string> a = new SimpleStack<string>();
            a.Push("Monday");
            a.Push("Tuesday");
            a.Push("Wednesday");
            a.Push("Thursday");
            a.Push("Friday");

            FiniteStack<string> b = new FiniteStack<string>(16);
            b.Push("June");
            b.Push("May");
            b.Push("April");
            b.Push("March");
            a.Copy(b);

            var c = new SimpleStack<Interval>();
            c.Push(new Interval(5, 41));
            c.Push(new Interval(4, 52));
            c.Push(new Interval(7, 23));
            c.Push(new Interval(3, 34));
            c.Push(new Interval(6, 15));

            var d = new SimpleStack<object>();
            d.Push(new Interval(2, 30));
            d.Push("Sunday");
            d.Push(3.45);
            c.Copy(d);

            PrintStack(a);
            PrintStack(b);
            PrintStack(c);
            PrintStack(d);

        }
    }
}
