using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace MvcRouteTest
{
	public class Startup
	{
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc();
		}

		public void Configure(IApplicationBuilder app)
		{
			app.UseMvc(routes => routes.MapRoute("greeting", "{controller=Greeter}/{action=Greet}/{Name=Visitor}"));
		}
	}
}

