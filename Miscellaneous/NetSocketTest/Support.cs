using System;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace NetSocketTest
{
	class Support
	{
		public void Run(string[] args)
		{
			if(args.Length == 0)
				StartServer();
			else
				StartClient(args);
		}

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

		private static void StartServer()
		{
			EndPoint local = new IPEndPoint(IPAddress.Any, 2345);
			Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			server.Bind(local);
			server.Listen(10);
			for(int i = 0; i < 3; ++i)
			{
				Thread servant = new Thread(delegate()
				{
					for(;;)
					{
						Socket client = server.Accept();
						byte[] buffer = new byte[80];
						try
						{
							int sz = client.Receive(buffer);
							ProcessBuffer(buffer, sz);
							client.Send(buffer);
						}
						catch(Exception ex)
						{
							Console.WriteLine("Communication failure: {0}", ex.Message);
						}
						client.Close();
					}
				});
				servant.Start();
			}
		}

		private static void StartClient(string[] args)
		{
			string host = args.Length > 1 ? args[1] : "localhost";
			TcpClient client = new TcpClient();
			client.Connect(host, 2345);
			NetworkStream connection = client.GetStream();
			byte[] request = Encoding.UTF8.GetBytes(args[0]);
			connection.Write(request, 0, request.Length);
			byte[] response = new byte[80];
			int n = connection.Read(response, 0, 80);
			Console.WriteLine("RESPONSE: {0}", Encoding.UTF8.GetString(response, 0, n));
			connection.Close();
			client.Close();			
		}
		
	}
}
