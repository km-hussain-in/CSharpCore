using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace DemoApp.Controllers
{
	using Models;
	
	[ApiController]
	[Route("rest/feedbacks")]
	public class FeedbacksController : ControllerBase
	{
		private AppDbContext _model;
		
		public FeedbacksController(AppDbContext model) => _model = model;
		
		[HttpGet]
		public IEnumerable<Feedback> ReadFeedbacks()
		{
			return _model.Feedbacks.ToList();
		}
		
		[HttpGet("{id}")]
		public ActionResult<Feedback> ReadFeedback(string id)
		{
			Feedback feedback = _model.Feedbacks.Find(id);
			if(feedback == null)
				return NotFound();
			return feedback;
		}
		
		[HttpPost]
		public string WriteFeedback(Feedback input)
		{
			string action;
			Feedback feedback = _model.Feedbacks.Find(input.Name);
			if(feedback == null)
			{
				_model.Feedbacks.Add(input);
				action = "Accepted";	
			}
			else
			{
				feedback.Comment = input.Comment;
				feedback.Rating = input.Rating;
				action = "Revised";	
			}
			_model.SaveChanges();
			return action;
		}
	}
	
}

