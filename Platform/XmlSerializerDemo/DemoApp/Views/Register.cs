using System;

namespace DemoApp.Views
{
    public class Register
    {
        public bool Present(Models.Visitor model)
        {
            Console.WriteLine("Register Your Visit");
            Console.WriteLine();
            Console.Write("Your Name: ");
            model.Id = Console.ReadLine();
            if(model.Id.Length == 0)
            {
                Console.WriteLine("Name is required!");
                return false;
            }
            return true;
        }

    }
}
