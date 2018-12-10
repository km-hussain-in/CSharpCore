using System;
using Microsoft.AspNetCore.Builder;

namespace MiddlewareTest
{
	public class Startup
	{
		public void Configure(IApplicationBuilder app)
		{
			app.UseCounter();
			app.MapWelcomePageTo("/hello");
		}
	}
}


