using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Routing;

namespace DemoApp
{
    class Counter
    {
        IDictionary<string, int> store = new Dictionary<string, int>();

        public int GetNextCount(string id)
        {
            lock(store)
            {
                int count;
                store.TryGetValue(id, out count);
                store[id] = ++count;
                return count;
            }
        }
    }

    class Counting
    {
        private Counter _counter;
        private RequestDelegate _next;

        public Counting(Counter counter, RequestDelegate next)
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
            services.AddSingleton<Counter>();
            services.AddRouting();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMiddleware<Counting>();
            //app.Run(Clock);
            app.UseRouter(routes => 
            {
                routes.MapGet("Time", Clock);
                routes.MapGet("Greet/{name=World}", Greeter);
            });
        }

        private async Task Clock(HttpContext context)
        {
            await context.Response.WriteAsync(DateTime.Now.ToString());
        }

        private async Task Greeter(HttpContext context)
        {
            var visits = context.Items["VisitCount"];
            var visitor = context.GetRouteValue("name");
            await context.Response.WriteAsync
            ($@"
                <html>
                    <head><title>WebHostTest</title></head>
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
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Setup>()
                .Build()
                .Run();
        }
    }
}
