using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;

namespace MappingTest
{
	public static class Support
	{
		public static IApplicationBuilder MapWelcomePageTo(this IApplicationBuilder builder, string path)
		{
			return builder.Map(path, app => app.Run(MakeWelcomePage));
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
				output.WriteLine($"Current time is {System.DateTime.Now}");
				output.WriteLine("</body>");
				output.WriteLine("</html>");

				await output.FlushAsync();
			}
		}		
	}
}

