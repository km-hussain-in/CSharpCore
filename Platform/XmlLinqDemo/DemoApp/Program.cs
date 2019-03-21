using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace DemoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length > 2)
            {
                DepartmentDoc doc = new DepartmentDoc();
                Department dept = doc.Open();
                if(dept == null)
                    dept = new Department{Title = "Sales"};  
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
                int m = args.Length == 1 ? int.Parse(args[0]) : 0;
                var doc = XElement.Load("dept.xml");
                var selection = from e in doc.Element("Employees").Elements("Employee")
                                where (short)e.Element("Hours") > m
                                select new 
                                {
                                    Id = (string)e.Attribute("Name"),
                                    Income = (float)e.Element("Rate") * (short)e.Element("Hours")
                                };
                foreach(var entry in selection)
                    Console.WriteLine($"{entry.Id}\t{entry.Income:0.00}");
            }
        }
    }
}
