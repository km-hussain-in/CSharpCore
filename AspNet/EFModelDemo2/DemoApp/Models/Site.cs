using System.Collections.Generic;

namespace DemoApp.Models
{
    public class Site
    {
        public int Id {get; set;}

        public string Name {get; set;}

        public string Country {get; set;}

        public ICollection<Visitor> Visitors {get; set;}
    }
}