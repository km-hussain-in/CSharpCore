using System;
using System.IO;

namespace DemoApp
{
    public class DepartmentDoc
    {
        const string store = "dept.dat";

        public void Save(Department info)
        {
            using(var writer = new BinaryWriter(new FileStream(store, FileMode.Create)))
            {
                writer.Write(info.Title);
                foreach(var entry in info.Employees)
                {
                    writer.Write(entry.Name);
                    writer.Write(entry.Hours);
                    writer.Write(entry.Rate);
                }
            }
        }

        public Department Open()
        {
            if(File.Exists(store))
            {
                using(var reader = new BinaryReader(new FileStream(store, FileMode.Open)))
                {
                    Department info = new Department();
                    info.Title = reader.ReadString();
                    for(;;)
                    {
                        try
                        {
                            info.Employees.Add(new Employee
                            {
                                Name = reader.ReadString(),
                                Hours = reader.ReadInt16(),
                                Rate = reader.ReadSingle()
                            });
                        }
                        catch(EndOfStreamException)
                        {
                            break;
                        }
                    }
                    return info;
                }
            }
            return null;
        }
    }
}
