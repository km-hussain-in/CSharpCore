using System;
using System.IO;
using System.Xml.Serialization;

namespace DemoApp
{
    public class DepartmentDoc
    {
	    static XmlSerializer serializer = new XmlSerializer(typeof(Department));
        const string store = "dept.xml";

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

