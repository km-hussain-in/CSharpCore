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
            EndPoint local = new IPEndPoint(IPAddress.Any, 7001);
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            server.Bind(local);
            Console.WriteLine("Server ready.");
            byte[] request = new byte[80];
            for(;;)
            {
                EndPoint remote = new IPEndPoint(IPAddress.Any, 0);
                int n = server.ReceiveFrom(request, ref remote);
                ProcessBuffer(request, n);
                server.SendTo(request, remote);
            }
        }
    }
}
