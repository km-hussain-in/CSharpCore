using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DemoApp.Models
{
    public class Visit
    {
        public int Id {get; set;}

        public string Spot {get; set;}

        public int Frequency {get; set;}

        public DateTime Recent {get; set;}

        public virtual Visitor Visitor {get; set;}

        public Visit(){}

        public Visit(string spot, Visitor visitor)
        {
            Spot = spot;
            Frequency = 1;
            Recent = DateTime.Now;
            Visitor = visitor;
        }
    }

    public class Visitor
    {
        public string Id {get; set;}

        public string Password {get; set;}

        public virtual ICollection<Visit> Visits {get; set;}

    }

    public class VisitorModel : DbContext
    {
        public DbSet<Visitor> Visitors {get; set;}

        public DbSet<Visit> Visits {get; set;}

        public VisitorModel(DbContextOptions<VisitorModel> options) : base(options) {}
    }
}
