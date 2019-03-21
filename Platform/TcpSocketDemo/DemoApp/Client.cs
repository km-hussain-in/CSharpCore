using System;
using System.Text;
using System.Net.Sockets;

namespace DemoApp
{
    public static class Client
    {
        public static void Run(string textToProcess, string host)
        {
            using(TcpClient client = new TcpClient(host, 6001))
            {
                using(NetworkStream connection = client.GetStream())
                {
                    byte[] request = Encoding.UTF8.GetBytes(textToProcess);
                    byte[] response = new byte[80];
                    connection.Write(request, 0, request.Length);
                    int n = connection.Read(response, 0, 80);
                    Console.WriteLine("Response: {0}", Encoding.UTF8.GetString(response, 0, n));
                }
            }
        }
    }
}
