using System;

namespace DemoApp
{
    using Models;

    class Program
    {
        static void Main(string[] args)
        {
            IVisitorModel model = new Models.VisitorDocModel();
            if(args.Length > 0 && args[0] == "-register")
            {
                Visitor input = new Visitor();
                new Views.Register().Present(input);
                if(input.Id != null)
                    model.WriteVisitor(input);
            }
            else
                new Views.Index().Present(model.ReadVisitors());
        }
    }
}
