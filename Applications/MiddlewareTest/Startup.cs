using System;
using Microsoft.AspNetCore.Http;
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
			app.MapWelcomePage();
            		app.Run(async (context) =>
            		{
                		await context.Response.WriteAsync("<a href='welcome'>Hello World!</a>");
            		});

		}
	}
}


