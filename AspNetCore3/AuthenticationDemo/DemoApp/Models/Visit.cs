using System;

namespace DemoApp.Models
{
	public class Visit
	{
		public int Id {get; set;}
		
		public string Spot {get; set;}
		
		public int Frequency {get; set;}
		
		public DateTime Recent {get; set;}
		
		public virtual Visitor Visitor {get; set;}
		
		public Visit()
		{
			Frequency = 1;
			Recent = DateTime.Now;
		}
		
		public Visit(string spot, Visitor visitor) : this()
		{
			Spot = spot;
			Visitor = visitor;
		}
	}
}

