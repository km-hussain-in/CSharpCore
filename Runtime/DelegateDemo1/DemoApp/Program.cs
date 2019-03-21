using System;

namespace DemoApp
{
    class Program
    {
        static bool IsOdd(int n)
        {
            return (n % 2) == 1;        
        }

        class IsGreaterThan
        {
            int limit;

            internal IsGreaterThan(int small)
            {
                limit = small;
            }

            public bool Check(int value)
            {
                return value > limit;
            }
        }

        static void Main(string[] args)
        {
            int[] squares = {1, 4, 9, 16, 25, 36, 49, 64, 81};
            Console.Write("All squares:");
            foreach(int s in squares)
                Console.Write(" {0}", s);
            Console.WriteLine();
            Console.WriteLine("Number of odd squares: {0}", Counter.Count(squares, IsOdd));
            Console.WriteLine("Number of big squares: {0}", Counter.Count(squares, new IsGreaterThan(50).Check));
            Console.WriteLine("Number of even squares: {0}", Counter.Count(squares, delegate(int n){ return (n % 2) == 0; }));
            Console.WriteLine("Number of small squares: {0}", Counter.Count(squares, n => n < 10));
        }
    }
}
