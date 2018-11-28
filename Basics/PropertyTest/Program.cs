using System;

namespace PropertyTest
{
	struct Interval
	{
		private int min, sec;

		public Interval(int m, int s)
		{
			min = m + s / 60;
			sec = s % 60;
		}

		public int Time
		{
			get
			{
				return 60 * min + sec;
			}
		
			set
			{
				min = value / 60;
				sec = value % 60;
			}		
		}

		public int Minutes
		{
			get { return min; }
		}

		public int Seconds
		{
			get { return sec; }
		}

		public int this[int index]
		{
			get { return index == 0 ? sec : min; }
		}
		
		public void Print()
		{
			Console.WriteLine($"{min}:{sec:00}");
		}

	}

	class Customer
	{
		public string Name {get; set;}

		public decimal Credit {get; set;} = 5000;
	}

    	class Program
    	{
        	static void Main(string[] args)
        	{
	            	Interval jack = new Interval();
			jack.Time = 125;
			Console.Write("Jack's Interval = ");
			jack.Print();
			Interval jill = new Interval(2, 80);
			Console.Write("Jill's Interval = ");
			jill.Print();
			Interval total = new Interval(jack.Minutes + jill.Minutes, jack.Seconds + jill.Seconds);
			Console.WriteLine("Total = {0} minutes and {1} seconds.", total[1], total[0]);
            		Customer a = new Customer { Name = "Jack", Credit = 4000};
			Console.WriteLine($"{a.Name}'s credit is {a.Credit}");
            		var b = new Customer { Name = "Jill"};
			Console.WriteLine($"{b.Name}'s credit is {b.Credit}");
			var c = new {Id = 23, Score = 67};
			Console.WriteLine($"Student {c.Id} has scored {c.Score}");
			var d = new {Id = c.Id + 1, Score = 76};
			Console.WriteLine($"Student {d.Id} has scored {d.Score}");
		
        	}
    	}
}
