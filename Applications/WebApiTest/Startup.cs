using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace WebApiTest
{
	using Models;

	public class Startup
	{
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<Models.AppDbContext>(options => options.UseSqlite("Filename=sitedb.sqlite"));
			services.AddMvc()
				.SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
		}

		public void Configure(IApplicationBuilder app)
		{
			app.UseDefaultFiles();
			app.UseStaticFiles();
			app.UseMvc();
		}
	}
}

