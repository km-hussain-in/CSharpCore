using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace DemoApp
{
    class Contact
    {
        public string Name {get; set;}

        public string City {get; set;}

        public string State {get; set;}
    }

    class Program
    {
        static T Sum<T>(T first, params T[] values)
        {
            T total = first;
            var lhs = Expression.Parameter(typeof(T), "x");
            var rhs = Expression.Parameter(typeof(T), "y");
            var plus = Expression.Add(lhs, rhs);
            var expr = Expression.Lambda<Func<T, T, T>>(plus, lhs, rhs);
            var add = expr.Compile();
            foreach(T next in values)
                total = add(total, next);
            return total;
        }

        static void Main(string[] args)
        {
            if(args.Length < 2)
            {
                double sd = Sum(1.2, 2.3, 3.4, 4.5);
                Console.WriteLine("Sum of double values = {0}", sd);
                Interval si = Sum(new Interval(2, 15), new Interval(4, 30), new Interval(6, 45));
                Console.WriteLine("Sum of Interval objects = {0}", si);
            }
            else
            {
                var contacts = new List<Contact>
                {
                    new Contact{Name = "Jack", City = "Newark", State = "NJ"},
                    new Contact{Name = "Jill", City = "Richmond", State = "TX"},
                    new Contact{Name = "John", City = "Nashville", State = "TN"},
                    new Contact{Name = "Jeff", City = "Paterson", State = "NJ"},
                    new Contact{Name = "Jane", City = "Malibu", State = "CA"},
                    new Contact{Name = "James", City = "Nashville", State = "KY"},
                    new Contact{Name = "Jill", City = "Denver", State = "CO"},
                    new Contact{Name = "Joana", City = "Edison", State = "NJ"}
                };
                var xp = Expression.Parameter(typeof(Contact), "x");
                var eq = Expression.Equal
                (
                    Expression.Property(xp, args[0]), 
                    Expression.Constant(args[1], typeof(string))
                );
                var filter = Expression.Lambda<Func<Contact, bool>>(eq, false, xp);
                var selection = contacts.AsQueryable().Where(filter);
                foreach(var entry in selection)
                    Console.WriteLine("{0, -6}{1, -12}{2, -4}", entry.Name, entry.City, entry.State);
            }
        }
    }
}
