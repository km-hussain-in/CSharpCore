using System;

namespace ObjectClassTest
{
    partial class Interval
    {
        private static int count;

        partial void OnCreate()
        {
            Console.WriteLine("Interval instance<{0}> created", ++count);
        }
    }

    static class Program
    {
        private static void PrintAsXml(object obj)
	{
	    Type t = obj.GetType();
            if(t.IsPrimitive || t == typeof(string))
                Console.WriteLine("<{0}>{1}</{0}>", t.Name, obj);
            else
            {
                    Console.WriteLine("<{0}>", t.Name);
                    foreach(var prop in t.GetProperties())
                        Console.WriteLine("  <{0}>{1}</{0}", prop.Name, prop.GetValue(obj));
                    Console.WriteLine("</{0}>", t.Name);
            }
	}

        public static void Main()
        {
            Interval a = new Interval(4, 5);
            Interval b = new Interval(2, 30);
            Interval c = new Interval(3, 65);
            Interval d = b;

            Console.WriteLine("Interval a = {0}", a);
            Console.WriteLine("Interval b = {0}", b);
            Console.WriteLine("Interval c = {0}", c);
            Console.WriteLine("Interval d = {0}", d);

            Console.WriteLine("a is identical to b: {0}", ReferenceEquals(a, b));
            Console.WriteLine("a is identical to c: {0}", ReferenceEquals(a, c));
            Console.WriteLine("d is identical to b: {0}", ReferenceEquals(d, b));

            Console.WriteLine("a is equal to b: {0}", a == b);
            Console.WriteLine("a is equal to c: {0}", a == c);
            Console.WriteLine("d is equal to b: {0}", d == b);

            Console.WriteLine();		
	    PrintAsXml(a);
            PrintAsXml("Monday");
            PrintAsXml(3.14); //auto-boxing: implicit conversion of a value-type into object (reference) type
        }
    }
}
