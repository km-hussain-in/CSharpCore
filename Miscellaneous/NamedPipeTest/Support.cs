using System;
using System.Text;
using System.IO;
using System.IO.Pipes;

namespace NamedPipeTest
{
	class Support
	{
		private static void ProcessBuffer(byte[] buffer, int sz)
		{
			for(int i = 0, j = sz - 1; i < j; ++i, j--)
			{
				byte ib = buffer[i];
				byte jb = buffer[j];
				buffer[i] = jb;
				buffer[j] = ib;		
			}

		}

		public void Run(string[] args)
		{
			if(args.Length == 0)
				StartServer();
			else
				StartClient(args[0]);
		}

		public void StartServer()
		{
			byte[] buffer = new byte[80];
			using(var server = new NamedPipeServerStream("reverse", PipeDirection.InOut))
			{
				for(;;)
				{
					server.WaitForConnection();
					int sz = server.Read(buffer, 0, buffer.Length);
					ProcessBuffer(buffer, sz);
					server.Write(buffer, 0, sz);
					server.Disconnect();
				}
			}
		}
		
		public void StartClient(string text)
		{
			using(var client = new NamedPipeClientStream(".", "reverse", PipeDirection.InOut))
			{
				client.Connect();
				byte[] request = Encoding.UTF8.GetBytes(text);
				client.Write(request, 0, request.Length);
				client.Flush();
				byte[] response = new byte[80];
				int sz = client.Read(response, 0, response.Length);
				Console.WriteLine("Response: {0}", Encoding.UTF8.GetString(response, 0, sz));
			}
		}
		
	}
}
