﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Routing;

namespace DemoApp
{
    class Setup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCounter();
            //services.AddCounter(options => options.Increment = 2);
            services.AddRouting();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseCounter();
            //app.Run(Greeter);
            app.UseRouter(route => route.MapGet("Greet/{name=World}", Greeter));
        }

        private async Task Greeter(HttpContext context)
        {
            var visits = context.GetVisitCount();
            var visitor = context.GetRouteValue("name");//context.GetRouteData().Values["name"];
            await context.Response.WriteAsync
            ($@"
                <html>
                    <head><title>WebHostTest</title></head>
                    <body>
                        <h1>Hello {visitor}</h1>
                        <p>Current time is {DateTime.Now}</p>
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
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Setup>()
                .Build()
                .Run();
        }
    }
}
