using System;

namespace MethodTest2
{
    	class Program
    	{
		private static double GetIncome(double invest, int period=3, float rate=2.5f)
		{
			double amount = invest * Math.Pow(1 + rate / 100, period);
			return amount - invest;
		}

		private static (int, float) GetGoldInfo(double amount)
		{
			int period = amount < 10000 ? 5 : 4;
			float rate = amount < 25000 ? 3.25f : 3.75f;
			return (period, rate);
		}

        	static void Main(string[] args)
        	{
            		try
			{
				double inv = double.Parse(args[0]);
				Console.WriteLine("Income in bronze scheme: {0:0.00}", GetIncome(inv));
				Console.WriteLine("Income in silver scheme: {0:0.00}", GetIncome(inv, rate:3));
				(int n, float r) = GetGoldInfo(inv);
				Console.WriteLine("Income in gold scheme: {0:0.00}", GetIncome(inv, n, r));
				
			}
			catch(FormatException)
			{
				Console.WriteLine("Bad input!");
			}
			catch(IndexOutOfRangeException)
			{
				Console.WriteLine("No input!");
			}
        	}
    	}
}
