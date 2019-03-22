using System;

namespace DemoApp.Views
{
    using Models;

    public class Index
    {
        private IVisitorModel _model;

        public Index(IVisitorModel model) => _model = model;

        public void Present()
        {
            Console.WriteLine("Our Visitors");
            Console.WriteLine();
            Console.WriteLine("{0, -14}|{1, 14}| {2}", "Visitor Name", "Visit Count", "Last Visit");
            Console.WriteLine(new String('-', 52));
            var items = _model.ReadVisitors();
            foreach(var item in items)
                Console.WriteLine("{0, -14}|{1, 14}| {2}", item.Id, item.Frequency, item.Recent);
        }
    }
}
