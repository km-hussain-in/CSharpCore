using System;
using System.Runtime.InteropServices;

class LegacyTaxPayer
{

	[DllImport("txnshim")]
	private extern static double IncomeTaxFunc(short age, double income);


	private short age;

	internal LegacyTaxPayer(short age) => this.age = age;

	public double GetIncomeTax(double income)
	{
		return IncomeTaxFunc(age, income);
	}

}

static class Program
{

	public static void Main(string[] args)
	{
		double i = double.Parse(args[0]);
		short a = short.Parse(args[1]);
		var tp = new LegacyTaxPayer(a);

		Console.WriteLine("Income Tax: {0:0.00}", tp.GetIncomeTax(i));
	}

}

