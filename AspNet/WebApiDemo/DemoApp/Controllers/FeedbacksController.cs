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
        private FeedbackModel _model;

        public FeedbacksController(FeedbackModel model) => _model = model;

        [HttpGet]
        public IEnumerable<Feedback> ReadFeedbacks()
        {
            return _model.Feedbacks.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Feedback> ReadFeedback(string id)
        {
            Feedback info = _model.Feedbacks.Find(id);
            if(info != null)
                return info;
            return NotFound();
        }

        [HttpPost]
        public string WriteFeedback(Feedback input)
        {
            Feedback info = _model.Feedbacks.Find(input.Name);
            string result;
            if(info == null)
            {
                _model.Feedbacks.Add(input);
                result = "Accepted";
            }
            else
            {
                info.Comment = input.Comment;
                info.Rating = input.Rating;
                result = "Revised";
            }
            _model.SaveChanges();
            return result;
        }
    }
}
/*
PS C:\Testing> $feedback = '{"name":"Jones", "comment":"Take some rest", "rating":"3"}'
PS C:\Testing> Invoke-RestMethod -Uri http://localhost:5000/rest/feedbacks -Method POST -Body $feedback -ContentType "application/json"
PS C:\Testing> Invoke-RestMethod -Uri http://localhost:5000/rest/feedbacks

user@host:~ $ curl -X POST -H "Content-Type:application/json" http://localhost:5000/rest/feedbacks -d '{"name":"Jones", "comment":"Take some rest", "rating": "3"}'
user@host:~ $ curl http://localhost:5000/rest/feedbacks
*/
