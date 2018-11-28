using System.Collections.Generic;

namespace EFModelTest.Models
{
	public class TransientVisitorRegistry : IVisitorRegistry
	{
		private static readonly List<Visitor> Visitors = new List<Visitor>();

		public IEnumerable<Visitor> GetVisitors()
		{
			return Visitors.ToArray();	
		}		

		public void RegisterVisit(string name)
		{
			Visitor visitor = Visitors.Find(entry => entry.Name == name);
			
			if(visitor == null)
				lock(Visitors) Visitors.Add(new Visitor {Name = name, Id = Visitors.Count + 1});
			else
				visitor.NewVisit();			
		}
	}	
}

