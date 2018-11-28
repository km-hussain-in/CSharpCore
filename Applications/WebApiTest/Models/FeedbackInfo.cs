using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiTest.Models
{
	public class FeedbackInfo
	{
		[Column("Name")]
		public string From {get; set;}

		[Column("Text")]
		public string Comment {get; set;}	
	}
}
 
