using System;
using System.IO.Pipes;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace DemoApp
{
    public class EncodingService : BackgroundService
    {
        private Encoder _encoder;

        public EncodingService(Encoder encoder) => _encoder = encoder;

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            using(var server = new NamedPipeServerStream("enc", PipeDirection.InOut))
            {
                Console.WriteLine("Server started...");
                byte[] buffer = new byte[80];
                while(!cancellationToken.IsCancellationRequested)
                {
                    await server.WaitForConnectionAsync(cancellationToken);
                    int n = await server.ReadAsync(buffer, 0, buffer.Length, cancellationToken);
                    _encoder.ProcessBuffer(buffer, n);
                    await server.WriteAsync(buffer, 0, n, cancellationToken);
                    server.Disconnect();
                }
            }
        }
    }
}
