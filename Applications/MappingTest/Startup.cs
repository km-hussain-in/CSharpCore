using System;
using Microsoft.AspNetCore.Builder;

namespace MappingTest
{
	public class Startup
	{
		public void Configure(IApplicationBuilder app)
		{
			app.MapWelcomePageTo("/hello");
		}
	}
}

