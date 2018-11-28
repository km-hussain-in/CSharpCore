using System;

namespace GenMethodTest
{
	static class Program
	{

		private static T Select<T>(int sign, T first, T second)
		{
			if(sign < 0)
				return first;
			return second;
		}


		public static void Main(string[] args)
		{
			int s = int.Parse(args[0]);		
			double sd = Select(s, 3.25, 4.75);
			Console.WriteLine("Selected double = {0}", sd);
			string ss = Select(s, "Monday", "Tuesday");
			Console.WriteLine("Selected string = {0}", ss);
		}
	}
}

