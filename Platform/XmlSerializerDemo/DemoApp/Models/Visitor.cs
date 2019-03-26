using System;
using System.Collections.Generic;

namespace DemoApp.Models
{
    public class Visitor
    {
        public string Id {get; set;}

        public int Frequency {get; set;} = 1;

        public DateTime Recent {get; set;} = DateTime.Now;

        public void Revisit()
        {
            Frequency += 1;
            Recent = DateTime.Now;
        }

    }

    public interface IVisitorModel
    {
        IEnumerable<Visitor> ReadVisitors();

        void WriteVisitor(Visitor value);
    }
}
