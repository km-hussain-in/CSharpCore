using Shopping;
using Grpc.Core;
using System;
using System.Threading.Tasks;

namespace ServerApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
			var server = new Server()
			{
				Services = {ShopKeeper.BindService(new ShopKeeperService())},
				Ports = {new ServerPort("localhost", 6001, ServerCredentials.Insecure)}
			};			
			server.Start();

			Console.WriteLine("Server started on port 6001.");
			Task.Delay(-1).Wait();
        }
    }

	public class ShopKeeperService : ShopKeeper.ShopKeeperBase
	{
		private static string[] items = {"cpu", "hdd", "keyboard", "monitor", "motherboard", "mouse", "ram"};
		private static Random rdm = new Random();

		public override Task<ItemInfoReply> GetItemInfo(ItemInfoRequest request, ServerCallContext context)
		{
			double[] prices = {24000, 5000, 1000, 9500, 15000, 500, 2000};
			var info = new ItemInfoReply();
			int i = Array.IndexOf(items, request.Name);
			if(i >= 0)
			{
				info.UnitPrice = prices[i];
				info.CurrentStock = 50 * rdm.Next(2, 7); 
			}
			return Task.FromResult(info);
		}

		public override async Task GetItemNames(Google.Protobuf.WellKnownTypes.Empty _, IServerStreamWriter<ItemInfoRequest> response, ServerCallContext context)
		{
			foreach(string item in items)
				await response.WriteAsync(new ItemInfoRequest{Name = item});
		}
	}
}

