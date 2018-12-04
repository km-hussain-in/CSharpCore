using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace EFDBFirstTest2.Models
{
	public class Visitor
	{
		public string Id {get; set;}

		public int SiteId {get; set;}

		public int Frequency {get; set;}

		public DateTime Recent {get; set;}
	}

	public class Site
	{
		public int Id {get; set;}

		public string Name {get; set;}

		public string Location {get; set;}

		public decimal? Ticket {get; set;}

		public virtual ICollection<Visitor> Visitors {get; set;}
	}

	public class AppDbContext : DbContext
	{
		public DbSet<Site> Sites {get; set;}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite("Data Source=appdb.sqlite");
			optionsBuilder.UseLazyLoadingProxies();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Visitor>()
				    .ToTable("Visitors")
				    .Property(e => e.Id)
				    .HasColumnName("Name");
			modelBuilder.Entity<Visitor>()
				    .Property(e => e.SiteId)
				    .HasColumnName("Spot");				
		}
	}
}
