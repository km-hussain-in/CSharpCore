using System;

namespace PayrollApp
{
	using Payroll;

    	class Program
    	{
		private static double GetIncomeTax(Employee emp)
		{
			double i = emp.GetIncome();
			return i > 10000 ? 0.15 * (i - 10000) : 0;
		}

		private static double GetAverageIncome(Employee[] group)
		{
			double sum = 0;
			foreach(Employee entry in group)
			{
				sum += entry.GetIncome();
			}
			return sum / group.Length;
		}

		private static double GetTotalBonus(Employee[] group)
		{
			double sum = 0;
			foreach(Employee entry in group)
			{
				if(entry is SalesPerson)
					sum += 0.08 * entry.GetIncome();
				else
					sum += 0.12 * entry.GetIncome();
			}
			return sum;
		}

		private static double GetTotalSales(Employee[] group)
		{
			double sum = 0;
			foreach(Employee entry in group)
			{
				SalesPerson special = entry as SalesPerson;
				if(special != null)
					sum += special.Sales;
			}
			return sum;
		}

        	static void Main(string[] args)
        	{
			Employee jack = new Employee();
			jack.Hours = 186;
			jack.Rate = 52;
			Console.WriteLine("Jack's ID is {0}, Income is {1:0.00} and Tax is {2:0.00}", jack.Id, jack.GetIncome(), GetIncomeTax(jack));
			SalesPerson jill = new SalesPerson(186, 52, 48000); 
			Console.WriteLine("Jill's ID is {0}, Income is {1:0.00} and Tax is {2:0.00}", jill.Id, jill.GetIncome(), GetIncomeTax(jill));
			Employee[] dept = {jack, jill};
			Console.WriteLine("Average Income: {0:0.00}", GetAverageIncome(dept));
			Console.WriteLine("Total Bonus   : {0:0.00}", GetTotalBonus(dept));
			Console.WriteLine("Total Sales   : {0:0.00}", GetTotalSales(dept));
			Console.WriteLine("Number of Employees = {0}", Employee.CountInstances());
        	}
	
    	}
}

