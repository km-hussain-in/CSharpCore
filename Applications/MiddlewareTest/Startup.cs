using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace MiddlewareTest
{
	public class Startup
	{

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddCounter();
		}

		public void Configure(IApplicationBuilder app)
		{
			app.UseCounter();
			app.MapWelcomePageTo("/hello");
		}
	}
}


