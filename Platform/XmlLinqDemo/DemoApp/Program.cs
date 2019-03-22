using System;
using System.Linq;
using System.Xml.Linq;

namespace DemoApp
{
    using Models;

    class Program
    {
        static void Main(string[] args)
        {
            IVisitorModel model = new VisitorDocModel();

            if(args.Length == 0)
            {
                Console.WriteLine("Our Visitors");
                Console.WriteLine("Name\tVisit Count");
                foreach(Visitor item in model.ReadVisitors())
                    Console.WriteLine($"{item.Id}\t{item.Frequency}");
            }
            else if(args[0] == "-register")
            {
                Visitor input = new Visitor{Id = args[1]};
                model.WriteVisitor(input);
            }
            else if(args[0] == "-frequent")
            {
                var doc = XElement.Load("appdoc.xml");
                var selection = from v in doc.Elements("Visitor")
                                where (int)v.Element("Frequency") >= int.Parse(args[1])
                                select new 
                                {
                                    VisitorName = (string)v.Attribute("Id"),
                                    LastVisit = (DateTime)v.Element("Recent")
                                };
                Console.WriteLine("Our Frequent Visitors");
                Console.WriteLine("Name\tLast Visited");
                foreach(var entry in selection)
                    Console.WriteLine($"{entry.VisitorName}\t{entry.LastVisit}");
            }
            else
                Console.WriteLine("Invalid command");
        }
    }
}
