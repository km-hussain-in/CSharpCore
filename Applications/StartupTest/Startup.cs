using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;

namespace StartupTest
{
        public class Startup
        {
                public void Configure(IApplicationBuilder app)
                {
                        app.Run(Greet);
                }

                private static Task Greet(HttpContext context)
                {
                        return context.Response.WriteAsync($"Hello World, current time is {DateTime.Now}");
                }
        }
}
