using System;
using Microsoft.EntityFrameworkCore;

namespace WebApiTest.Models
{
	public class AppDbContext : DbContext
	{
		public DbSet<FeedbackInfo> Feedbacks {get; set;}

		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
			Database.EnsureCreated();
		}
	}
}

