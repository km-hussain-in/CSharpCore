using Finance;
using System;
using System.Reflection;

namespace AttributeTest
{
    	class Program
    	{
        	static void Main(string[] args)
        	{
			try
			{
				double amount = Convert.ToDouble(args[0]);
				Type ofClass = args.Length > 1 ? Type.GetType(args[1], true) : typeof(PersonalLoan);
				dynamic scheme = Activator.CreateInstance(ofClass);
				MaxDurationAttribute md = (MaxDurationAttribute)Attribute.GetCustomAttribute(ofClass, typeof(MaxDurationAttribute));
				int m = md != null ? md.Limit : 5;
				for(int n = 1; n <= m; ++n)
				{
					float i = scheme.GetInterestRate(n) / 1200;
					double emi = amount * i / (1 - Math.Pow(1 + i, -12 * n));
					Console.WriteLine("{0, -6}{1, 12:0.00}", n, emi); 
				}
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
        	}
	}
}
