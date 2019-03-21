using System;

namespace DemoApp
{
    class Subscriber
    {
        private Publisher pub;

        public void Subscribe()
        {
            pub = new Publisher();
            pub.Available += pub_Available;
            pub.Available += ShowTime;
            pub.Publish(5);
        }

        private void pub_Available(object sender, QuoteEventArgs e)
        {
            Console.WriteLine("Received quote with value {0:0.00}", e.Value);
        }

        private void ShowTime(object sender, EventArgs e)
        {
            Console.WriteLine(DateTime.Now);
        }
            
    }

    class Program
    {
        static void Main(string[] args)
        {
            Subscriber sub = new Subscriber();
            sub.Subscribe();
        }
    }
}
