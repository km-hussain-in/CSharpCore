using System;

namespace MethodTest1
{
	class Program
    	{
		private static double Average(double first, double second)
		{
			return (first + second) / 2;
		}

		private static double Average(double first, double second, double third)
		{
			return (first + second + third) / 3;
		}

		private static double Average(double first, double second, params double[] remaining)
		{
			double total = (first + second);
			foreach(double value in remaining)
				total += value;
			return total / (remaining.Length + 2);
		}

		static void Swap(ref double first, ref double second)
		{
			double third = first;
			first = second;
			second = third;
		}

		static double Average(double first, double second, out double dev)
		{
			dev = first > second ? (first - second) / 2 : (second - first) / 2;
			return (first + second) / 2;
		}


		static void Main(string[] args)
        	{
			double x = 23.6, y = 28.3;
            		Console.WriteLine("Average of two values = {0}", Average(x, y));
			Console.WriteLine("Average of three values = {0}", Average(x, y, 22.5));
			Console.WriteLine("Average of five values = {0}", Average(x, y, 22.4, 32.1, 17.8));
			Console.WriteLine($"Original values: {x}, {y}");
			Swap(ref x, ref y);
			Console.WriteLine($"Swapped values: {x}, {y}");
			double d;
			double a = Average(x, y, out d);
			Console.WriteLine($"Their average is {a} with a deviation of {d}");
        	}
    	}
}
