using System;

namespace DemoApp
{

    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length > 0)
            {
                var controller = new Controllers.VisitorsController();
                if(!controller.InvokeAction(args[0]))
                    Console.WriteLine("Cannot {0}.", args[0]);
            }
        }
    }
}
