using System;
using System.Text;
using System.Runtime.InteropServices;

namespace DemoApp
{
    class Program
    {
		[DllImport("native")]        
		extern static int Encrypt(string key, StringBuilder buffer, int count);
			
		[StructLayout(LayoutKind.Sequential)]
		struct Loan
		{
			public double Amount;
			public short Period;
		}
			
		delegate float Scheme(short period);

		[DllImport("native", EntryPoint="EMI")]        
		extern static double GetInstallment(ref Loan info, Scheme policy);

        static void Main(string[] args)
        {
			if(args.Length == 1)
			{
				StringBuilder buf = new StringBuilder(args[0]);
				Encrypt("*#", buf, buf.Length);
				Console.WriteLine("Encrypted text = {0}", buf.ToString());
			}
			else if(args.Length > 1)
			{
				Loan loan;
				loan.Amount = double.Parse(args[0]);
				loan.Period = short.Parse(args[1]);
				double pmt = GetInstallment(ref loan, n => n < 3 ? 3.25f : 3.75f);
				Console.WriteLine("Monthly installment: {0:0.00}", pmt);  
			}
        }
    }
}
