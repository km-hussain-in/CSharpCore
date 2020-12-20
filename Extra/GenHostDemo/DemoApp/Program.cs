using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace DemoApp
{
    public class Encoder
    {
        public int ProcessBuffer(byte[] buffer, int count)
        {
            for(int i = 0; i < count; ++i)
                buffer[i] = (byte)(buffer[i] ^ '#');
            return count;
        }
    }

    public class Program
    {
        public static async Task Main(string[] args)
        {
            try
            {
                var builder = new HostBuilder()
                    .ConfigureServices((hostContext, services) =>
                    {
                        services.AddSingleton<Encoder>();
                        services.AddHostedService<EncodingService>();
                    });

                await builder.Build().RunAsync();
            }
            catch {}
        }
    }
}
