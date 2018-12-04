using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace EFDBFirstTest1
{
	public class Startup
	{
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc();
			services.AddSingleton<Models.AppDbContext>();
		}

		public void Configure(IApplicationBuilder app)
		{
			app.UseMvcWithDefaultRoute();
		}
	}
}
