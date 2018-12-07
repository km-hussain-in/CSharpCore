using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;

namespace EFDBFirstTest.Models.Fluent
{
	using EFDBFirstTest.Models;

	public class Visitor : IVisitor
	{
		public string Id {get; set;}

		public int SiteId {get; set;}

		public int Frequency {get; set;}

		public DateTime Recent {get; set;}
	}

	public class Site : ISite
	{
		public int Id {get; set;}

		public string Name {get; set;}

		public string Location {get; set;}

		public decimal? Ticket {get; set;}

		//virtual required for lazy loading so the property can be overridden by the proxy 
		public virtual ICollection<Visitor> Visitors {get; set;}

		IEnumerator<IVisitor> ISite.GetEnumerator() => Visitors.GetEnumerator();
	}

	public class AppDbContext : DbContext, IAppDbModel
	{
		public DbSet<Site> Sites {get; set;}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite("Data Source=appdb.sqlite");
			optionsBuilder.UseLazyLoadingProxies(); //required for lazy loading
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Visitor>()
				    .ToTable("Visitors") //conventionally maps to Visitor (entity class name) table
				    .Property(e => e.Id) 
				    .HasColumnName("Name"); //conventinally maps to Id (property name) column
			modelBuilder.Entity<Visitor>()
				    .Property(e => e.SiteId)
				    .HasColumnName("Spot");				
		}

		public IEnumerable<ISite> GetAllSites()
		{
			return Sites.ToList();
		}

		public ISite GetSiteById(int siteId)
		{
			return Sites.Find(siteId); //automatic lazy loading of child entities
		}
	}
}
