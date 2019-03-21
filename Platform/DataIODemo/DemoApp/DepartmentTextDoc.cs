using System;
using System.IO;

namespace DemoApp
{
    public class DepartmentTextDoc
    {
        const string store = "dept.txt";

        public void Save(Department info)
        {
            using(var writer = new StreamWriter(new FileStream(store, FileMode.Create)))
            {
                writer.WriteLine(info.Title);
                foreach(var entry in info.Employees)
                    writer.WriteLine($"{entry.Name}|{entry.Hours}|{entry.Rate}");
            }
        }

        public Department Open()
        {
            if(File.Exists(store))
            {
                using(var reader = new StreamReader(new FileStream(store, FileMode.Open)))
                {
                    Department info = new Department();
                    info.Title = reader.ReadLine();
                    string line;
                    while((line = reader.ReadLine()) != null)
                    {
                        string[] values = line.Split('|');
                        info.Employees.Add(new Employee
                        {
                            Name = values[0],
                            Hours = short.Parse(values[1]),
                            Rate = float.Parse(values[2])
                        });
                    }
                    return info;
                }
            }
            return null;
        }
    }
}
