using System;
using System.Net;
using System.Net.Http;

namespace DemoApp
{
    public static class Server
    {
        public static void Run()
        {
            HttpListener server = new HttpListener();
            server.Prefixes.Add("http://*:8001/process/");
            server.Start();
            Console.WriteLine("Server started.");
            var processor = ProcessorFactory.Provider.CreateProcessor();
            for(;;)
            {
                HttpListenerContext context = server.GetContext();
                byte[] response = processor.Process(context.Request.InputStream, (int)context.Request.ContentLength64);
                context.Response.ContentLength64 = response.Length;
                context.Response.OutputStream.Write(response, 0, response.Length);
                context.Response.OutputStream.Close();
            }
        }
    }
}

//Windows (as administrator) netsh http add urlacl url=http://*:8001/ user="NT AUTHORITY\Authenticated Users"