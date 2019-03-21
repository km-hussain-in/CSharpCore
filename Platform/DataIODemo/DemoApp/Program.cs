using System;
using System.IO;

namespace DemoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var doc = new DepartmentTextDoc(); // new DepartmentDoc();
            Department dept = doc.Open();
            if(dept == null)
                dept = new Department{Title = "Sales"};
            if(args.Length > 2)
            {
                dept.Employees.Add(new Employee
                {
                    Name = args[0],
                    Hours = short.Parse(args[1]),
                    Rate = float.Parse(args[2])
                });
                doc.Save(dept);
            }
            else
            {
                foreach(Employee emp in dept.Employees)
                    Console.WriteLine($"{emp.Name}\t{emp.GetIncome():0.00}");
            }
        }
    }
}
