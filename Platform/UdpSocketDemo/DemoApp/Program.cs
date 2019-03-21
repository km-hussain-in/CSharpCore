using System;

namespace DemoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length == 0)
                Server.Run();
            else
                Client.Run(args[0], args.Length > 1 ? args[1] : "localhost");
        }
    }
}
