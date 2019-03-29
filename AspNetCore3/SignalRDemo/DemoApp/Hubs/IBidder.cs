using System.Threading.Tasks;

namespace DemoApp.Hubs
{
    public interface IBidder
    {
        Task BidAccepted(double price);

        Task BidRejected(string reason);
    }
}
