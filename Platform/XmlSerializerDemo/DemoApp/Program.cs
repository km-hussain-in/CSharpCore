using System;

namespace DemoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var model = new Models.VisitorDocModel();
            if(args.Length > 0 && args[0] == "-index")
                new Views.Index(model).Present();
            else if(args.Length > 0 && args[0] == "-register")
                new Views.Register(model).Present();
            else
                Console.WriteLine("Invalid command");
        }
    }
}
