using System;

namespace DemoApp.Views
{
    using Models;

    public class Register
    {
        public void Present(Models.Visitor model)
        {
            Console.WriteLine("Register Your Visit");
            Console.WriteLine();
            Console.Write("Your Name: ");
            string name = Console.ReadLine();
            model.Id = name.Length > 0 ? name : null;
        }
    }
}
