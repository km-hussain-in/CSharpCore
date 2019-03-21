using System;
using System.Collections.Generic;

namespace DemoApp
{
    public class Department
    {
        public string Title {get; set;}

        public List<Employee> Employees {get; set;} = new List<Employee>();
    }
}
