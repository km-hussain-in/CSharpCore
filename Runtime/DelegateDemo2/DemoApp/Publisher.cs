using System;

namespace DemoApp
{
    public class QuoteEventArgs : EventArgs
    {
        public readonly double Value;

        public QuoteEventArgs(double val)
        {
            Value = val;
        }
    }

    public delegate void QuoteEventHandler(object sender, QuoteEventArgs e);

    public class Publisher
    {
        private Random source = new Random();

        private double Fetch(int id)
        {
            for(int t = Environment.TickCount + 1000 * id; t > Environment.TickCount;);
            return source.Next(1000, 10000) / 100.0;
        }

        public event QuoteEventHandler Available;

        public void Publish(int count)
        {
            for(int i = 1; i <= count; ++i)
            {
                double val = Fetch(i);
                Available?.Invoke(this, new QuoteEventArgs(val));
            }
        }
    }

}
