using System;
using System.Collections.Generic;

namespace DemoApp.Views
{
    public class Index
    {
        public bool Present(IEnumerable<Models.Visitor> model)
        {
            Console.WriteLine("Our Visitors");
            Console.WriteLine();
            Console.WriteLine("{0, -14}|{1, 14}| {2}", "Visitor Name", "Visit Count", "Last Visit");
            Console.WriteLine(new String('-', 52));
            foreach(var item in model)
                Console.WriteLine("{0, -14}|{1, 14}| {2}", item.Id, item.Frequency, item.Recent);
            return true;
        }
    }
}
