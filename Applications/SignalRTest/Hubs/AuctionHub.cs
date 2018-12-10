using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace SignalRTest.Hubs
{
    public class AuctionHub : Hub<IAuctionHub>
    {
        private static double currentPrice = 50;
        private static object sync = new object();

        public async Task AcceptBid(double newPrice)
        {
            lock(sync)
            {
                if(newPrice - currentPrice < 5)
                    throw new HubException("Invalid new price");
                currentPrice = newPrice;
            }
            await Clients.All.BidAccepted(newPrice);
        }

        public override async Task OnConnectedAsync()
        {
	    await Clients.Caller.StartBidding(currentPrice);
        }
    }
}