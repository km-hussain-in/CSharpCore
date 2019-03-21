using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace DemoApp
{
    class Setup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCounter();
            //services.AddCounter(options => options.Increment = 2);
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseCounter();
            app.Run(Welcome);
        }

        private async Task Welcome(HttpContext context)
        {
            dynamic visitor = context.Items["Visitor"];
            await context.Response.WriteAsync
            ($@"
                <html>
                    <head><title>WebHostTest</title></head>
                    <body>
                        <h1>Welcome {visitor.Name}</h1>
                        <p>Current time is {DateTime.Now}</p>
                        <p>Number of visit is {visitor.Frequency}</p>
                    </body>
                </html>
            ");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Setup>()
                .Build()
                .Run();
        }
    }
}
