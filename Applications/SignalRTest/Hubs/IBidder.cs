using System.Threading.Tasks;

namespace SignalRTest.Hubs
{
    public interface IBidder
    {
        Task StartBidding(double currentPrice);

	Task BidAccepted(double newPrice);
    }
}