using System;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

static class Program
{
	[DllImport("natsup", EntryPoint="GCD")]
	private extern static long GreatestDivisor(long first, long second);

	[DllImport("natsup")]
	private extern static int ReverseString(string original, StringBuilder result);

	[DllImport("natsup")]
	private extern static int SquareAll(double[] values, int count);

	struct Range
	{
		public int Begin;

		public int End;
	}	

	delegate float Sequence(int at);

	[DllImport("natsup")]
	private extern static double SequenceSum(Sequence gen, in Range lim);


	public static void Main(string[] args)
	{
		if(args[0] == "gcd")
		{
			long m = long.Parse(args[1]);
			long n = long.Parse(args[2]);
			Console.WriteLine(GreatestDivisor(m, n));
		}
		else if(args[0] == "reverse")
		{
			var buffer = new StringBuilder(args[1].Length);
			ReverseString(args[1], buffer);
			Console.WriteLine(buffer);
		}
		else if(args[0] == "square")
		{
			double[] values = args.Skip(1).Select(double.Parse).ToArray();
			SquareAll(values, values.Length);
			Array.ForEach(values, Console.WriteLine);
		}
		else if(args[0] == "sequence")
		{
			var lim = new Range {Begin = 1};
			lim.End = int.Parse(args[1]) + 1;
			Console.WriteLine(SequenceSum(t => 2 * t - 1, lim));

		}
	}

}

