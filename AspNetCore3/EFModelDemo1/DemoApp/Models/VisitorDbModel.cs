using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DemoApp.Models
{
    public class VisitorDbModel : DbContext, IVisitorModel
    {
 		public DbSet<Visitor> Visitors {get; set;}
 		
 		public VisitorDbModel() => Database.EnsureCreated();
 		
 		protected override void OnConfiguring(DbContextOptionsBuilder options)
 		{
 			options.UseSqlite("FileName=appdb.sqlite");
 		}
 		
        public IEnumerable<Visitor> ReadVisitors() => Visitors.ToList();

        public void WriteVisitor(Visitor value)
        {
            Visitor visitor = Visitors.FirstOrDefault(entry => entry.Id == value.Id);
            if(visitor == null)
                Visitors.Add(value);
            else
                visitor.Revisit();
            SaveChanges();
        }
    }
}

