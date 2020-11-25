using Shopping;
using Grpc.Core;
using System;
using System.Threading.Tasks;

namespace ClientApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
		 	var channel = new Channel("localhost:6001", ChannelCredentials.Insecure);
			var client = new ShopKeeper.ShopKeeperClient(channel);

			if(args.Length > 0)
			{
            	var info = client.GetItemInfo(new ItemInfoRequest{Name = args[0]});
           		if(info.CurrentStock > 0) 
            		Console.WriteLine($"Unit Price: {info.UnitPrice}");
				else
					Console.WriteLine("Not available");
			}
			else
			{
				Console.WriteLine("Available items");
				var result = client.GetItemNames(new Google.Protobuf.WellKnownTypes.Empty());
				await foreach(var item in result.ResponseStream.ReadAllAsync())
					Console.WriteLine(item.Name);
			}

			await channel.ShutdownAsync();
			
        }
    }
}

