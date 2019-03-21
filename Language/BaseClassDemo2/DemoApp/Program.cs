using System;

namespace DemoApp
{
    partial class Interval
    {
        public static bool operator==(Interval lhs, Interval rhs)
        {
            return lhs.GetHashCode() == rhs.GetHashCode() && lhs.Equals(rhs);
        }

        public static bool operator!=(Interval lhs, Interval rhs) => !(lhs == rhs);
    }

    struct Frame
    {
        public int Width, Height;

        public Frame(int w, int h)
        {
            Width = w;
            Height = h;
        }

        public override string ToString() => $"{Width} x {Height}";
    }

    static class Printing
    {
    
        /*
        public static void PrintVariable(this Interval value, string name)
        {
            Console.WriteLine("{0} -> Interval({1})", name, value.ToString());
        }

        public static void PrintVariable(this Frame value, string name)
        {
            Console.WriteLine("{0} = Frame({1})", name, value.ToString());
        }
        */
        
        public static void PrintVariable(this object value, string name)
        {
            Type t = value.GetType();
            if(t.IsValueType)
                Console.WriteLine("{0} = {1}({2})", name, t.Name, value);
            else
                Console.WriteLine("{0} -> {1}({2})", name, t.Name, value);
        }  
    }    

    class Program
    {
        static void Main(string[] args)
        {
            Interval a = new Interval(5, 10);
            a.PrintVariable("a"); //Printing.PrintVariable(a, "a");
            Interval b = new Interval(3, 40);
            b.PrintVariable("b");
            Interval c = new Interval(4, 70);
            c.PrintVariable("c");
            Interval d = b;
            d.PrintVariable("d");

            Console.WriteLine("a is identical to b: {0}", ReferenceEquals(a, b));
            Console.WriteLine("a is identical to c: {0}", ReferenceEquals(a, c));
            Console.WriteLine("d is identical to b: {0}", ReferenceEquals(d, b));
            Console.WriteLine("a is equal to b: {0}", a.GetHashCode() == b.GetHashCode() && a.Equals(b));
            Console.WriteLine("a is equal to c: {0}", a.GetHashCode() == c.GetHashCode() && a.Equals(c));
            Console.WriteLine("d is equal to b: {0}", d == b);

            Frame f = new Frame(12, 15);
            f.PrintVariable("f"); //value-type will be converted to object(reference-type) through boxing
            Frame g = new Frame(15, 12);
            g.PrintVariable("g");
            Frame h = new Frame(12, 15);
            h.PrintVariable("h");

            Console.WriteLine("f is equal to g: {0}", f.GetHashCode() == g.GetHashCode() && f.Equals(g));
            Console.WriteLine("f is equal to h: {0}", f.GetHashCode() == h.GetHashCode() && f.Equals(h));

            var i = new {Name = "Jack", Age = 34};
            i.PrintVariable("i");
        }
    }
}
