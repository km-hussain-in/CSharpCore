using System;
using System.Dynamic;
using System.Linq.Expressions;

namespace DemoApp
{
    class Greeter : DynamicObject
    {
        public string Meet(string person)
        {
            return $"Welcome {person}";
        }

        public override bool TryInvokeMember(InvokeMemberBinder method, object[] arguments, out object result)
        {
            if(arguments.Length == 1)
            {
                result = $"Please {method.Name} {arguments[0]}";
                return true;
            }
            result = null;
            return false;
        }
    }

    class Program
    {
        static T Sum<T>(T first, params T[] values)
        {
            dynamic total = first;
            foreach(dynamic next in values)
                total += next;
            return total;
        }

        static void Main(string[] args)
        {
            if(args.Length == 0)
            {
                double sd = Sum(1.2, 2.3, 3.4, 4.5);
                Console.WriteLine("Sum of double values = {0}", sd);
                Interval si = Sum(new Interval(2, 15), new Interval(4, 30), new Interval(6, 45));
                Console.WriteLine("Sum of Interval objects = {0}", si);
            }
            else
            {
                dynamic g = new Greeter();
                Console.WriteLine(g.Meet("Jack"));
                Console.WriteLine(g.Leave("Jack"));
            }
        }
    }
}
