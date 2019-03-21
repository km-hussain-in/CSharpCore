using System;

namespace DemoApp
{
    struct NamedValue<V> 
    {
        public string Name;
        public V Value;
    }

    class Program
    {
        static void Print<V>(NamedValue<V> nv)
        {
            Console.WriteLine("[{0}] = {1}", nv.Name, nv.Value);           
        }

        static decimal? /*Nullable<decimal>*/ GetSales(string day)
        {
            NamedValue<decimal>[] sales = 
            {
                new NamedValue<decimal> {Name = "monday", Value = 5000},
                new NamedValue<decimal> {Name = "tuesday", Value = 7000},
                new NamedValue<decimal> {Name = "wednesday", Value = 8000},
                new NamedValue<decimal> {Name = "thursday", Value = 6000},
                new NamedValue<decimal> {Name = "friday", Value = 9000}
            };
            
            foreach(var entry in sales)
            {
                if(entry.Name == day)
                    return entry.Value;
            }
            return null;
        }

        static void Main(string[] args)
        {
            NamedValue<double> a;
            a.Name = "Jack";
            a.Value = 23.45;
            Print(a);
            var b = new NamedValue<DateTime>{Name = "Today", Value = DateTime.Now};
            Print(b);
            if(args.Length > 0)
            {
                decimal? sales = GetSales(args[0]);
                decimal commission = 1.05M * (sales ?? 0);
                Console.WriteLine($"Commission: {commission}");
            }          
        }
    }
}
