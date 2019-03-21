using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace DemoApp
{
    public class CounterOptions
    {
        public int Increment {get; set;} = 1;
    }

    public class CounterService
    {
        IDictionary<string, int> counters = new Dictionary<string, int>();

        private CounterOptions options = new CounterOptions();

        public CounterService(Action<CounterOptions> initialize) 
        {
            initialize?.Invoke(options);
        }

        public int GetNextCount(string id)
        {
            lock(counters)
            {
                int count;
                counters.TryGetValue(id, out count);
                counters[id] = count += options.Increment;
                return count;
            }
        }
    }

    public class CounterMiddleware
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
            string id = context.Request.Path.Value.Substring(1);
            int count = _counter.GetNextCount(id);
            context.Items["Visitor"] = new {Name = id, Frequency = count};
            await _next.Invoke(context);
        }
    }

    public static class Counters
    {
        public static IServiceCollection AddCounter(this IServiceCollection services, Action<CounterOptions> options = null) 
            => services.AddSingleton(new CounterService(options));

        public static IApplicationBuilder UseCounter(this IApplicationBuilder app) 
            => app.UseMiddleware<CounterMiddleware>();
    }
}
