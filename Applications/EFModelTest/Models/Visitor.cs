using System;
using System.ComponentModel.DataAnnotations;

namespace EFModelTest.Models
{
	public class Visitor
	{
		public int Id {get; set;}

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
 


