using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoApp.Models
{
	public class Visitor
	{
		public string Id {get; set;}
		
		public string Password {get; set;}

		[NotMapped]
		public string ConfirmPassword {get; set;}
		
		public virtual ICollection<Visit> Visits {get; set;}
	}
}


