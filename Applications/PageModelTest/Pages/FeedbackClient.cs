using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Runtime.Serialization;

namespace PageModelTest.Pages
{
	[DataContract]
	public class FeedbackInfo
	{
		[DataMember(Name = "from")]
		public string From {get; set;}

		[DataMember(Name = "comment")]
		public string Comment {get; set;}	
	}

	public class FeedbackClient
	{
		private HttpClient server;

		public FeedbackClient(HttpClient client)
		{
			server = client;
			server.DefaultRequestHeaders.Add("Accept", "application/json");
		}

		public async Task<IEnumerable<FeedbackInfo>> ReadAllAsync()
		{
			/*
			var serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(FeedbackInfo[]));
			var contentStream = await server.GetStreamAsync("api/feedbacks");
			return (IEnumerable<FeedbackInfo>)serializer.ReadObject(contentStream);
			*/			
			var response = await server.GetAsync("api/feedbacks");
			var result = await response.Content.ReadAsAsync<IEnumerable<FeedbackInfo>>();
			return result;
		}

		public async Task<string> WriteAsync(FeedbackInfo feedback)
		{
			/*
			var serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(FeedbackInfo));
			var contentStream = new System.IO.MemoryStream();
			serializer.WriteObject(contentStream, feedback);
			contentStream.Seek(0, SeekOrigin.Begin);
			var content = new StreamContent(contentStream);
			content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
			var response = await server.PostAsync("api/feedbacks", content);
			*/
			var response = await server.PostAsJsonAsync("api/feedbacks", feedback);
			return await response.Content.ReadAsStringAsync();			
		}
	
	}
}
