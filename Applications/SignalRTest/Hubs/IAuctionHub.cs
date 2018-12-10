using System.Threading.Tasks;

namespace SignalRTest.Hubs
{
    public interface IAuctionHub
    {
        Task StartBidding(double currentPrice);

	Task BidAccepted(double newPrice);
    }
}