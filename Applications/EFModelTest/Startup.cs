using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace EFModelTest
{
	public class Startup
	{
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc();
			//services.AddSingleton<Models.IVisitorRegistry, Models.TransientVisitorRegistry>();
			services.AddSingleton<Models.IVisitorRegistry, Models.PersistentVisitorRegistry>();
		}

		public void Configure(IApplicationBuilder app)
		{
			app.UseMvcWithDefaultRoute();
		}
	}
}
