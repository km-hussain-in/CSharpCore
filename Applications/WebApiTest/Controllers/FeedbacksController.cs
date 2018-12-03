using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace WebApiTest.Controllers
{
	using Models;

	[Route("api/feedbacks")]
	[ApiController]
	public class FeedbacksController : ControllerBase
	{
		private AppDbContext store;

		public FeedbacksController(AppDbContext injected)
		{
			store = injected;
		}

		[HttpGet]
		public IEnumerable<FeedbackInfo> ReadFeedbacks()
		{
			return store.Feedbacks.ToList();
		}

		[HttpGet("{id}")]
		public ActionResult<FeedbackInfo> ReadFeedback(string id)
		{
			FeedbackInfo feedback = store.Feedbacks.FirstOrDefault(entry => entry.Id == id);

			if(feedback == null)
				return NotFound();

			return feedback;
		}
		

		[HttpPost]
		public string WriteFeedback(FeedbackInfo info)
		{
			FeedbackInfo feedback = store.Feedbacks.FirstOrDefault(entry => entry.Id == info.Id);
			string result;

			if(feedback == null)
			{
				store.Add(info);
				result = "Accepted";
			}
			else
			{
				feedback.Text = info.Text;
				result = "Updated";
			}		

			store.SaveChanges();

			return result;
		}
	}
}


