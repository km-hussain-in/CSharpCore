using System;

namespace OperatorTest
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

		public static Interval operator+(Interval lhs, Interval rhs)
		{
			return new Interval(lhs.min + rhs.min, lhs.sec + rhs.sec);
		} 

		public static Interval operator++(Interval val)
		{
			return new Interval(val.min, val.sec + 1);
		}

		//public static implicit operator double(Interval val)
		public static explicit operator double(Interval val)
		{
			return val.min + val.sec / 60.0;
		}

	}

    	class Program
    	{
        	static void Main(string[] args)
        	{
			Interval a = new Interval(5, 44);
			a.Print();
			Interval b = new Interval(4, 30);
			b.Print();
			Interval c = a + b;
			c.Print();
			Interval d = ++a;
			a.Print();
			d.Print();
			Interval e = b++;
			b.Print();
			e.Print();
			double f = (double)a;
			Console.WriteLine(f);
        	}
    	}
}
