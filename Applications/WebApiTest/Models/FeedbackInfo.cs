using System.Runtime.Serialization;

namespace WebApiTest.Models
{
	[DataContract]
	public class FeedbackInfo
	{
		[DataMember(Name = "from")]
		public string Id {get; set;}

		[DataMember(Name = "comment")]
		public string Text {get; set;}	
	}
}
 
