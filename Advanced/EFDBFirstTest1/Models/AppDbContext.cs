using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFDBFirstTest1.Models
{
	[Table("Visitors")] //without explicit mapping this entity class will be conventionally mapped to 'Visitor' table 
	public class Visitor
	{
		[Column("Name")] //without explicit mapping this property will be conventionally mapped to 'Id' column
		public string Id {get; set;}

		[Column("Spot")]
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

		public ICollection<Visitor> Visitors {get; set;} = new List<Visitor>();
	}

	public class AppDbContext : DbContext
	{
		public DbSet<Site> Sites {get; set;} //by convention Site entity will now be mapped to 'Sites' table 

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite("Data Source=appdb.sqlite");
		}
	}
}
