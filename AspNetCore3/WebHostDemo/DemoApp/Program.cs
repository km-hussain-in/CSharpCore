using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace DemoApp
{
	class CounterService
	{
		private IDictionary<string, int> entries = new Dictionary<string, int>();
		
		public int GetNextCount(string path)
		{
			lock(entries)
			{
				int count;
				entries.TryGetValue(path, out count);
				entries[path] = ++count;
				return count;
			}
		}		
	}
	
	class CounterMiddleware
	{
		private CounterService _counter;
		private RequestDelegate _next;
		
		public CounterMiddleware(CounterService counter, RequestDelegate next)
		{
			_counter = counter;
			_next = next;
		}
		
		public async Task Invoke(HttpContext context)
		{
			context.Items["VisitCount"] = _counter.GetNextCount(context.Request.Path.Value);
			await _next.Invoke(context);
		}
	}
	
	class Setup
	{
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddSingleton<CounterService>();
		}
		
		public void Configure(IApplicationBuilder app)
		{
			app.UseMiddleware<CounterMiddleware>();
			app.UseRouting(routes => 
			{
				routes.MapGet("/Time", Clock);
				routes.MapGet("/Greet/{name=World}", Greeter);
			});
		}
		
		private static async Task Clock(HttpContext context)
		{
			await context.Response.WriteAsync(DateTime.Now.ToString());
		}
		
		private static async Task Greeter(HttpContext context)
		{
			var visitor = context.GetRouteValue("name");
			var visits = context.Items["VisitCount"];
			await context.Response.WriteAsync
			($@"
				<html>
					<head>
						<title>DemoApp</title>
					</head>
					<body>
						<h1>Hello {visitor}</h1>
						<p>Number of visits is {visits}</p>
					</body>
				</html>
			");
		}
		
	}
	
    class Program
    {
        static void Main(string[] args)
        {
            Host.CreateDefaultBuilder(args)
            	.ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Setup>())
            	.Build()
            	.Run();
        }
    }
}

