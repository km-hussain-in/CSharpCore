using System;

namespace DemoApp
{
    class Program
    {

        static double Average(double first, double second)
        {
            return (first + second) / 2;
        }

        static double Average(double first, double second, double third) => (first + second + third) / 3;
    
        static double Average(double first, double second, params double[] other)
        {
            double sum = first + second;
            foreach(double value in other)
                sum += value;
            return sum / (other.Length + 2);
        }

        static double Average(double first, double second, out double dev)
        {
            dev = first > second ? (first - second) / 2 : (second - first) / 2;
            return (first + second) / 2;
        }    

        static double Power(double value, uint index=2)
        {
            if(index == 2)
                return value * value;
            return value * Power(value, index - 1);
        }

        static void Swap<T>(ref T first, ref T second)
        {
            T third = first;
            first = second;
            second = third;
        }


        static void Main(string[] args)
        {
            if(args.Length < 2)
            {
                Console.WriteLine("Average of {0} values = {1}", 2, Average(22.3, 29.4));
                Console.WriteLine("Average of {0} values = {1}", 3, Average(22.3, 29.4, 20.6));
                Console.WriteLine("Average of {0} values = {1}", 5, Average(22.3, 29.4, 20.6, 32.7, 18.5));
            }
            else
            {
                double x = double.Parse(args[0]);
                double y = double.Parse(args[1]);
                double d;
                double a = Average(x, y, out d);
                Console.WriteLine($"Average is {a} with a deviation of {d}");
                Console.WriteLine("Square of first is {0}", Power(x));
                Console.WriteLine("Cube of second is {0}", Power(y, 3));
                Console.WriteLine($"Original double values: {x}, {y}");
                Swap(ref x, ref y);
                Console.WriteLine($"Swapped double values: {x}, {y}");
                string u = "Monday", v = "Tuesday";
                Console.WriteLine($"Original string values: {u}, {v}");
                Swap(ref u, ref v);
                Console.WriteLine($"Swapped double values: {u}, {v}");
            }
        }
    }
}
