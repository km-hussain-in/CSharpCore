using System;
using System.ComponentModel.DataAnnotations;

namespace EFModelTest.Models
{
	public class Visitor
	{
		public int Id {get; set;} //by convention Id property will be mapped to Id column with primary-key constraint,
					  //and marked as db-auto-generated since it is of integer type.

		public string Name {get; set;}

		[Display(Name = "Visit Count")]
		public int Frequency {get; set;}

		[Display(Name = "Last Visit")]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
		public DateTime Recent {get; set;}		

		public Visitor()
		{
			this.Frequency = 1;
			this.Recent = DateTime.Now;
		}

		internal void NewVisit()
		{
			this.Frequency += 1;
			this.Recent = DateTime.Now;
		}
	}
}
 


