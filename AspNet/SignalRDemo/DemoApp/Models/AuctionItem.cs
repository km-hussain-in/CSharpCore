namespace DemoApp.Models
{
    public class AuctionItem
    {
        public double CurrentPrice {get; private set;}

        public AuctionItem(double initialPrice) => CurrentPrice = initialPrice;

        public bool UpdatePrice(double value)
        {
            lock(this)
            {
                if(value >= 1.05 * CurrentPrice)
                {
                    CurrentPrice = value;
                    return true;
                }
                return false;
            }
        }
    }
}