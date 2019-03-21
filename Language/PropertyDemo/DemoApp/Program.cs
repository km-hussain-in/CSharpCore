using System;

namespace DemoApp
{
    class Interval
    {
        int minutes, seconds;
        static int printed;

        public int Time
        {
            get
            {
                return minutes + 60 * seconds;
            }
            set
            {
                minutes = value / 60;
                seconds = value % 60;
            }
        }

        public int this[int index]
        {
            get
            {
                return index == 0 ? seconds : minutes;
            }
        }

        public void Print(string label)
        {
            Console.WriteLine("{0} = {1}:{2:00}", label, minutes, seconds);
            printed += 1;
        }

        public static int Prints
        {
            get
            {
                return printed;
            }
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
            Console.WriteLine("Number of Intervals Printed = {0}", Interval.Prints);
        }
    }
}
