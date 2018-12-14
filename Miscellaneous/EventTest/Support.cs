using System;

namespace EventTest
{
	class QuoteEventArgs : EventArgs
	{
		public double Value {get;}

		public QuoteEventArgs(double val)
		{
			Value = val;
		}
	}

	delegate void QuoteEventHandler(object sender, QuoteEventArgs e);

	//quote event source
	class Publisher
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
			for(int i = 0; i < count; ++i)
			{
				double val = Fetch(i);
				QuoteEventArgs e = new QuoteEventArgs(val);
				Available?.Invoke(this, e);
			}
		}
	}

	//quote event sink
	class Support
	{
		private Publisher pub = new Publisher();

		private void pub_Available(object sender, QuoteEventArgs e)
		{
			Console.WriteLine("Received quote with value {0}", e.Value);
		}

		//contravariant substitution for second parameter
		private void ShowTime(object sender, EventArgs e)
		{
			Console.WriteLine(DateTime.Now);
		}

		public void Run(string[] args)
		{
			pub.Available += pub_Available;
			pub.Available += ShowTime;
			pub.Publish(4);
		}
	}

}

