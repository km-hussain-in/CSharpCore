using Microsoft.EntityFrameworkCore;

namespace DemoApp.Models
{
	public class AppDbContext : DbContext
	{
		public DbSet<Visitor> Visitors {get; set;}
		
		public DbSet<Visit> Visits {get; set;}
				
		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			options.UseSqlite("FileName=appdb.sqlite");
			options.UseLazyLoadingProxies();
		}
	}
	
}

