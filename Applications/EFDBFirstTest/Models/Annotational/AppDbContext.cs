using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFDBFirstTest.Models.Annotational
{
	using EFDBFirstTest.Models;

	[Table("Visitors")] //conventionally maps to Visitor (entity class name) table
	public class Visitor : IVisitor
	{
		[Column("Name")] //conventionally maps to Id column
		public string Id {get; set;}

		[Column("Spot")]
		public int SiteId {get; set;}

		public int Frequency {get; set;}

		public DateTime Recent {get; set;}
	}

	public class Site : ISite //conventionally maps to Sites (DbSet name in DbContext) table
	{
		public int Id {get; set;}

		public string Name {get; set;}

		public string Location {get; set;}

		public decimal? Ticket {get; set;}

		public ICollection<Visitor> Visitors {get; set;}

		IEnumerator<IVisitor> ISite.GetEnumerator() => Visitors.GetEnumerator();
	}

	public class AppDbContext : DbContext, IAppDbModel
	{
		public DbSet<Site> Sites {get; set;}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite("Data Source=appdb.sqlite");
		}

		public IEnumerable<ISite> GetAllSites()
		{
			return Sites.ToList();
		}

		public ISite GetSiteById(int siteId)
		{
			Site site = Sites.Find(siteId);
			Entry(site).Collection(e => e.Visitors).Load(); //explicit loading of child entities
			return site;
		}

	}
}
