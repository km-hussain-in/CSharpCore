using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EFModelTest.Models
{
	public class PersistentVisitorRegistry : DbContext, IVisitorRegistry
	{
		public DbSet<Visitor> Visitors {get; set;}

		protected override void OnConfiguring(DbContextOptionsBuilder builder)
		{
			builder.UseSqlite("Filename=sitedb.sqlite");
		}

		public IEnumerable<Visitor> GetVisitors()
		{
			return Visitors.ToArray();	
		}		

		public void RegisterVisit(string name)
		{
			Visitor visitor = Visitors.FirstOrDefault(entry => entry.Name == name);
			
			if(visitor == null)
				Visitors.Add(new Visitor {Name = name});
			else
				visitor.NewVisit();	

			SaveChanges();		
		}
	}	
}

