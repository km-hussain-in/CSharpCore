using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace MiddlewareTest
{
	public static class Support
	{
		public static IServiceCollection AddCounter(this IServiceCollection services)
		{
			return services.AddSingleton(new CounterService());
		}

		public static IApplicationBuilder UseCounter(this IApplicationBuilder builder)
		{
			return builder.UseMiddleware<CounterMiddleware>();
		}

		public static IApplicationBuilder MapWelcomePage(this IApplicationBuilder builder)
		{
			return builder.Map("/welcome", app => app.Run(MakeWelcomePage));
		}

		class CounterService
		{
			private int current = 0;

			public int GetNextCount()
			{
				return System.Threading.Interlocked.Increment(ref current);
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
				if(context.Request.Path.Value.Contains("/welcome"))
					context.Items["RequestCount"] = _counter.GetNextCount();
				await _next.Invoke(context);
			}
		
		}		

		private static async Task MakeWelcomePage(HttpContext context)
		{
			var names = context.Request.Query["visitor"];
			string name = names.Count > 0 ? names[0] : "Visitor";

			using(var output = new System.IO.StreamWriter(context.Response.Body))
			{
				output.WriteLine("<html>");
				output.WriteLine("<head><title>Learning Asp.Net Core</title></head>");
				output.WriteLine("<body>");
				output.WriteLine($"<h1>Welcome {name}</h1>");
				output.WriteLine($"Number of requests is {context.Items["RequestCount"]}");
				output.WriteLine("</body>");
				output.WriteLine("</html>");

				await output.FlushAsync();
			}
		}

	}
}

