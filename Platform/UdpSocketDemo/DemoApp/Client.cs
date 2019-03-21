using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace DemoApp
{
    public static class Client
    {
        public static void Run(string textToProcess, string host)
        {
            using(UdpClient client = new UdpClient())
            {
                byte[] request = Encoding.UTF8.GetBytes(textToProcess);
                client.Send(request, request.Length, host, 7001);
                IPEndPoint remote = null;                
                byte[] response = client.Receive(ref remote);
                Console.WriteLine("Response: {0}", Encoding.UTF8.GetString(response));
            }
        }
    }
}
