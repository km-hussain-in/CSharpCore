using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoApp.Models
{
    [Table("Visitors")]
    public class Visitor
    {
        public string Name {get; set;}

        [Column("Spot")]
        public int SiteId {get; set;}

        public int Frequency {get; set;}

        public DateTime Recent {get; set;}
    }    
}
