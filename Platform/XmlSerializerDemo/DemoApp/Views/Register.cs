using System;

namespace DemoApp.Views
{
    using Models;

    public class Register
    {
        private IVisitorModel _model;

        public Register(IVisitorModel model) => _model = model;

        public void Present()
        {
            Console.WriteLine("Register Your Visit");
            Console.WriteLine();
            Console.Write("Your Name: ");
            string name = Console.ReadLine();
            if(name.Length > 3)
                _model.WriteVisitor(new Visitor{Id = name});
            else
                Console.WriteLine("Invalid name!");
        }
    }
}
