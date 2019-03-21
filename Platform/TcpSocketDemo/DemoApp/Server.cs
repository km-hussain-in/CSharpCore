using System;
using System.Net;
using System.Net.Sockets;

namespace DemoApp
{
    public static class Server
    {
        private static void ProcessBuffer(byte[] buffer, int count)
        {
            for(int i = 0; i < count; ++i)
                buffer[i] = (byte)(buffer[i] ^ '#');
        }

        public static void Run()
        {
            EndPoint local = new IPEndPoint(IPAddress.Any, 6001);
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            server.Bind(local);
            server.Listen(10);
            Console.WriteLine("Server ready.");
            byte[] request = new byte[80];
            for(;;)
            {
                using(Socket client = server.Accept())
                {
                    int n = client.Receive(request);
                    ProcessBuffer(request, n);
                    client.Send(request);
                }
            }
        }
    }
}
