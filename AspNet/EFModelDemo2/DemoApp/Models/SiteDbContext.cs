using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DemoApp.Models
{
    public class SiteDbContext : DbContext, ISiteModel
    {
        public DbSet<Site> Sites {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("FileName = sitedb.sqlite");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Visitor>()
                .HasKey(e => new {e.Name, e.SiteId});
        }

        public async Task<IEnumerable<Site>> GetAllSitesAsync() => await Sites.ToListAsync();

        public async Task<Site> GetSiteByIdAsync(int siteId)
        {
            Site site = await Sites.FindAsync(siteId);
            await Entry(site).Collection(p => p.Visitors).LoadAsync();
            return site;
        }
    }
}
