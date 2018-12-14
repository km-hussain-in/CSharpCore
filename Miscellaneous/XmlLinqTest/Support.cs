using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;


namespace XmlLinqTest
{
	public class Support
	{
		public void Run(string[] args)
		{
			if(args.Length > 1 && args[0] == "register")
				OnRegister(args[1]);
			else if(args.Length > 0 && args[0] == "view")
				OnView(args.Length > 1 ? int.Parse(args[1]) : 1);
			else
				Console.WriteLine("Invalid command");
			
		}

		private void OnRegister(string name)
		{
			XmlSerializer serializer = new XmlSerializer(typeof(Site));
			Site site = null;
			if(File.Exists("sitedoc.xml"))
			{
				using(var doc = File.OpenText("sitedoc.xml"))
					site = (Site)serializer.Deserialize(doc);
			}	
			else
				site = new Site {Title = "Great Wall"};
			site.RegisterVisit(name);
			using(var doc = File.CreateText("sitedoc.xml"))
				serializer.Serialize(doc, site);
		}

		private void OnView(int limit)
		{
			XElement doc = XElement.Load("sitedoc.xml");
			var selection = from v in doc.Element("Visitors").Elements("Visitor")
					where (int)v.Element("Frequency") >= limit
					select new
					{
						VisitorName = (string)v.Attribute("Id"),
						LastVisit = (DateTime)v.Element("Recent")
					};
			Console.WriteLine("Frequent visitors of {0} site", (string) doc.Element("Title"));
			foreach(var entry in selection)
				Console.WriteLine($"{entry.VisitorName}\t{entry.LastVisit}");		
		}
	}
}
