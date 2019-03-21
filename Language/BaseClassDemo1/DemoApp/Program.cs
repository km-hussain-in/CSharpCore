
using System;

namespace DemoApp
{

    class Program
    {
        static double GetTotalIncome(Employee[] group)
        {
            double total = 0;
            foreach(Employee emp in group)
            {
                total += emp.GetIncome();
            }
            return total;
        }

        static double GetTotalSales(Employee[] group)
        {
            double total = 0;
            foreach(Employee emp in group)
            {
                if(emp is SalesPerson)
                {
                    SalesPerson spn = (SalesPerson)emp;
                    total += spn.Sales;
                }
            }
            return total;
        }

        static void Main(string[] args)
        {
            Employee jack = new Employee();
            jack.Hours = 48;
            Console.WriteLine("Jack's weekly income is {0:0.00}", jack.GetIncome());
            Employee jill = new Employee(45, 15);
            Console.WriteLine("Jill's weekly income is {0:0.00}", jill.GetIncome());
            SalesPerson john = new SalesPerson(50, 10, 24000);
            Console.WriteLine("John's weekly income is {0:0.00}", john.GetIncome());
            Employee[] dept = {jack, jill, john};
            Console.WriteLine("Total income : {0:0.00}", GetTotalIncome(dept));
            Console.WriteLine("Total sales  : {0:0.00}", GetTotalSales(dept));
        }
    }
}
