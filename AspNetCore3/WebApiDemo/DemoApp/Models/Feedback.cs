using System.ComponentModel.DataAnnotations;

namespace DemoApp.Models
{
	public class Feedback
	{
		[Key]
		public string Name {get; set;}
		
		[StringLength(128)]
		public string Comment {get; set;}
		
		[Range(1, 5)]
		public int Rating {get; set;}
	}
	
}

