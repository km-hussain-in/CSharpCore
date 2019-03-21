using System;

namespace DemoApp
{
    class Interval
    {
        public Interval(int seconds = 0)
        {
            Time = seconds;
        }   

        public int Time {get; set;}

        public static int Prints {get; private set;}

        public int this[int index] => index == 0 ? Time % 60 : Time / 60;

        public void Print(string label)
        {
            Console.WriteLine("{0} = {1}:{2:00}", label, Time / 60, Time % 60);
            Prints += 1;
        }    

        public static Interval operator+(Interval lhs, Interval rhs)
        {
            return new Interval(lhs.Time + rhs.Time);            
        }

        public static Interval operator++(Interval val)
        {
            return new Interval(val.Time + 1);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Interval a = new Interval();
            a.Time = 125;
            a.Print("First Interval");
            Interval b = new Interval {Time = 200};
            b.Print("Second Interval");
            Interval c = new Interval();
            c.Time = 60 * a[1] + b[0];
            c.Print("Third Interval");
            Interval d = new Interval(290);
            d.Print("Fourth Interval");
            Interval e = c + d++;
            d.Print("Incremented Fourth Interval");
            e.Print("Fifth Interval");
            Console.WriteLine("Number of Intervals Printed = {0}", Interval.Prints);
        }
    }
}
