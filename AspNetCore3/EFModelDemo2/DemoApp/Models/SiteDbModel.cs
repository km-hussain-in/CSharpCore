using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DemoApp.Models
{
	[Table("Visitors")]
	public class Visitor
	{
		public string Name {get; set;}
		
		[Column("Spot")]
		public int SiteId {get; set;}
		
		public int Frequency {get; set;}
		
		public DateTime? Recent {get; set;}
	}
	
	public class Site
	{
		public int Id {get; set;}
		
		public string Name {get; set;}
		
		public string Country {get; set;}
		
		public ICollection<Visitor> Visitors {get; set;}
	}
	
	public class SiteDbModel : DbContext
	{
		public DbSet<Site> Sites {get; set;}
		
		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			options.UseSqlite("FileName=sitedb.sqlite");
		}
		
		protected override void OnModelCreating(ModelBuilder model)
		{
			model.Entity<Visitor>()
				.HasKey(e => new {e.Name, e.SiteId});
		}
		
		public async Task<IEnumerable<Site>> GetAllSitesAsync() => await Sites.ToListAsync();
		
		public async Task<Site> GetSiteByIdAsync(int siteId)
		{
			Site site = await Sites.FindAsync(siteId);
			if(site != null)
				await Entry(site).Collection(e => e.Visitors).LoadAsync();
			return site;
		}
	}
}


