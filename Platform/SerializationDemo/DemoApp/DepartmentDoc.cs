using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace DemoApp
{
    public class DepartmentDoc
    {
	    static BinaryFormatter serializer = new BinaryFormatter();
        const string store = "dept.dat";

        public void Save(Department info)
        {
            using(var target = new FileStream(store, FileMode.Create))
                serializer.Serialize(target, info);
        }

        public Department Open()
        {   
            if(File.Exists(store))
            {
                using(var source = new FileStream(store, FileMode.Open))
                    return (Department) serializer.Deserialize(source);
            }
            return null;
        }
    }
}

