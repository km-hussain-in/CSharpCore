using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DemoApp.Models
{
    public class VisitorDbModel : DbContext, IVisitorModel
    {
        public DbSet<Visitor> Visitors {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("FileName=appdb.sqlite");
        }

        public IEnumerable<Visitor> ReadVisitors() => Visitors.ToList();

        public void WriteVisitor(Visitor value)
        {
            Visitor visitor = Visitors.FirstOrDefault(entry => entry.Name == value.Name);
            if(visitor == null)
                Visitors.Add(value);
            else
                visitor.Revisit();
            SaveChanges();
        }

    }
}

