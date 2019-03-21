using System.Threading.Tasks;
using System.Net.WebSockets;

namespace DemoApp.Handlers
{
    public class AuctionHandler : WebSocketHandler
    {
        private double currentPrice;

        public AuctionHandler(double initialPrice) => currentPrice = initialPrice;

        protected override async Task OnReceiveTextAsync(string bid, WebSocket bidder)
        {
            double newPrice = double.Parse(bid);
            if(newPrice == 0)
                await SendTextAsync(currentPrice, bidder);
            else if(UpdatePrice(newPrice))
                await SendTextAsync(newPrice);
            else
                await SendTextAsync("Invalid new price", bidder);
        }

        private bool UpdatePrice(double value)
        {
            lock(this)
            {
                if(value >= 1.05 * currentPrice)
                {
                    currentPrice = value;
                    return true;
                }
                return false;
            }
        }
    }
}