using System;
using System.IO;
using System.IO.Pipes;

namespace DemoApp
{
    class Server
    {
        private static void ProcessBuffer(byte[] buffer, int count)
        {
            for(int i = 0; i < count; ++i)
                buffer[i] = (byte)(buffer[i] ^ '#');
        }

        public static void Run()
        {
            using(var server = new NamedPipeServerStream("enc", PipeDirection.InOut))
            {
                Console.WriteLine("Server ready.");
                byte[] buffer = new byte[80];
                for(;;)
                {
                    server.WaitForConnection();
                    int n = server.Read(buffer, 0, buffer.Length);
                    ProcessBuffer(buffer, n);
                    server.Write(buffer, 0, n);
                    server.Disconnect();
                }
            }
        }
    }
}