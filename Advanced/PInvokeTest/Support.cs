using System;
using System.Text;
using System.Runtime.InteropServices;

namespace PInvokeTest
{
	class Support
	{
		[DllImport("legacy")]
		extern static int GreatestDivisor(int first, int second);

		[DllImport("legacy")]        
		extern static int Encrypt(StringBuilder buffer, int count, string key);

		[StructLayout(LayoutKind.Sequential)]
		struct Loan
		{
			public double Amount;
			public short Period;
		}
        
		delegate float Scheme(short period);

		[DllImport("legacy", EntryPoint="EMI")]        
		extern static double GetInstallment(ref Loan info, Scheme policy);

		public void Run(string[] args)
		{
			if(args.Length > 2 && args[0] == "gcd")
			{
				int m = int.Parse(args[1]);
				int n = int.Parse(args[2]);
				Console.WriteLine("Greatest divisor = {0}", GreatestDivisor(m, n));
			}
			else if(args.Length > 1 && args[0] == "encrypt")
			{
				var buf = new StringBuilder(args[1]);
				Encrypt(buf, buf.Length, "#*");
				Console.WriteLine("Encrypted text = {0}", buf.ToString());
			}
			else if(args.Length  > 2 && args[0] == "emi")
			{
				Loan loan;
				loan.Amount = double.Parse(args[1]);
				loan.Period = short.Parse(args[2]);
				double pmt = GetInstallment(ref loan, n => n < 3 ? 3.25f : 3.75f);
				Console.WriteLine("Monthly installment: {0:0.00}", pmt);  
			}
			else
				Console.WriteLine("Invalid command!");
		}
	}
}

