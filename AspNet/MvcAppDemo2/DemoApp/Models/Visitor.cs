using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DemoApp.Models
{
    public class Visitor
    {
        [Required]
        [StringLength(32, MinimumLength = 4)]
        public string Name {get; set;}

        public int Frequency {get; set;} = 1;

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
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

