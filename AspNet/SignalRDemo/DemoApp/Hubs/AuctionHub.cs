using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace DemoApp.Hubs
{
    using Models;

    public class AuctionHub : Hub<IBidder>
    {
        private AuctionItem _item;

        public AuctionHub(AuctionItem item) => _item = item;

        public async Task AcceptBid(double newPrice)
        {
            if(newPrice == 0)
                await Clients.Caller.BidAccepted(_item.CurrentPrice);
            else if(_item.UpdatePrice(newPrice))
                await Clients.All.BidAccepted(newPrice);
            else
                await Clients.Caller.BidRejected("Invalid new price");
        }
    }
}
