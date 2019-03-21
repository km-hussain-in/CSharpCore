using System;
using System.Text;
using System.Net.Http;

namespace DemoApp
{
    public static class Client
    {
        public static void Run(string textToProcess, string host)
        {
            Uri remote = new Uri($"http://{host}:8001/process");
            HttpContent request = new ByteArrayContent(Encoding.UTF8.GetBytes(textToProcess));
            using(HttpClient client = new HttpClient())
            {
                var response = client.PostAsync(remote, request).Result;
                byte[] buffer = response.Content.ReadAsByteArrayAsync().Result;
                Console.WriteLine("Response: {0}", Encoding.UTF8.GetString(buffer));
            }
        }
    }
}
