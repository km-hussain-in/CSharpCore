using System;

namespace GenClassTest
{
    static class Program
    {
        public static void Main()
        {
            SimpleStack<double> a = new SimpleStack<double>();
            a.Push(5.34);
            a.Push(2.43);
            a.Push(7.52);
            a.Push(6.21);
            while (!a.Empty())
                Console.WriteLine(a.Pop());
            Console.WriteLine("----------");
            SimpleStack<string> b = new SimpleStack<string>();
            b.Push("Monday");
            b.Push("Tuesday");
            b.Push("Wednesday");
            b.Push("Thursday");
            b.Push("Friday");
            foreach (string s in b)
                Console.WriteLine(s);
        }
    }
}