using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace EFDBFirstTest
{
	public class Startup
	{
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc();
			services.AddSingleton<Models.IAppDbModel, Models.Annotational.AppDbContext>();
			//services.AddSingleton<Models.IAppDbModel, Models.Fluent.AppDbContext>();
		}

		public void Configure(IApplicationBuilder app)
		{
			app.UseMvcWithDefaultRoute();
		}
	}
}
