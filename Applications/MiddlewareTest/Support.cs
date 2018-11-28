using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;

namespace MiddlewareTest
{
	public static class Support
	{
		public static IApplicationBuilder UseCounter(this IApplicationBuilder builder)
		{
			return builder.UseMiddleware<CounterMiddleware>();
		}

		public static void RunWelcomePage(this IApplicationBuilder builder)
		{
			builder.Run(MakeWelcomePage);
		}


		private static async Task MakeWelcomePage(HttpContext context)
		{
			string path = context.Request.Path;
			string name = path.Length > 1 ? path.Substring(1) : "Visitor";

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

		class CounterMiddleware
		{
			private int numberOfRequests = 0;
			private RequestDelegate _next;

			public CounterMiddleware(RequestDelegate next)
			{
				_next = next;
			}

			public async Task Invoke(HttpContext context)
			{
				context.Items["RequestCount"] = System.Threading.Interlocked.Increment(ref numberOfRequests);
				await _next.Invoke(context);
			}
		
		}		
	}
}

