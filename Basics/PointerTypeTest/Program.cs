using System;

namespace PointerTypeTest
{
    	class Program
    	{
		private static double SumOf(double[] values)
		{
			double total = 0;
			foreach(double value in values)
				total += value;
			return total;
		}

		private unsafe static void FastSquareAll(double[] values)
		{
			fixed(double* pinned = &values[0])
			{
				for(int i = 0; i < values.Length; ++i)
					pinned[i] *= pinned[i];					
			}
		}

        	static void Main(string[] args)
        	{
            		double[] list = new double[args.Length];
			for(int i = 0; i < args.Length; ++i)
				list[i] = double.Parse(args[i]);
			Console.WriteLine("Sum of original values = {0}", SumOf(list));
			FastSquareAll(list);
			Console.WriteLine("Sum of their squares = {0}", SumOf(list));

        	}
    	}
}
