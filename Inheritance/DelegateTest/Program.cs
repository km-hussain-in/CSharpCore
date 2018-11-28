using System;

namespace DelegateTest
{

    delegate bool Filter(int value);

    static class ArrayCounter
    {
        public static int CountIf(int[] values, Filter check)
        {
            int count = 0;

            foreach (int value in values)
            {
                if (check.Invoke(value))
                    count += 1;
            }

            return count;
        }
    }

    static class Program
    {
        private static bool IsOdd(int m)
        {
            return (m % 2) == 1;
        }

        class IsBiggerThan
        {
            private int limit;

            public IsBiggerThan(int limit)
            {
                this.limit = limit;
            }

            public bool Confirm(int value)
            {
                return value > limit;
            }
        }

        public static void Main()
        {
            int[] squares = { 1, 4, 9, 16, 25, 36, 49, 64, 81, 100 };
            Console.Write("All squares:");
            foreach (int n in squares)
                Console.Write(" {0}", n);
            Console.WriteLine();
            //passing static method reference
            Console.WriteLine("Number of odd squares = {0}", ArrayCounter.CountIf(squares, IsOdd));
            //passing instance method reference
            Console.WriteLine("Number of big squares = {0}", ArrayCounter.CountIf(squares, new IsBiggerThan(50).Confirm));
            //passing anonymous method: delegate(arguments){ return expression; }
            Console.WriteLine("Number of even squares = {0}", ArrayCounter.CountIf(squares, delegate (int n) { return (n & 1) == 0; }));
            //passing lambda expression: (arguments) => expression
            Console.WriteLine("Number of small squares = {0}", ArrayCounter.CountIf(squares, n => n < 25));

        }
    }
}