using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace XmlLinqTest
{

	public class Visitor
	{
		[XmlAttribute("Id")]
		public string Name {get; set;}

		[XmlElement("Frequency")]
		public int VisitCount {get; set;} = 1;

		public DateTime Recent {get; set;} = DateTime.Now;

	}

	public class Site
	{
		public string Title {get; set;}

		public List<Visitor> Visitors {get; set;} = new List<Visitor>();

		public void RegisterVisit(string visitorName)
		{
			var visitor = Visitors.Find(e => e.Name == visitorName);
			if(visitor == null)
				Visitors.Add(new Visitor {Name = visitorName});
			else
			{
				visitor.VisitCount += 1;
				visitor.Recent = DateTime.Now;
			}
		}
		
	}
}
