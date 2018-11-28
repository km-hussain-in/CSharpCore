using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PageModelTest.Pages
{
	public class ChangeModel : PageModel
	{
		[BindProperty]
		public FeedbackInfo Feedback {get; set;}

		public async Task<ActionResult> OnPost([FromServices] FeedbackClient client, string from)
		{
			Feedback.From = from;
			await client.WriteAsync(Feedback);
			return new RedirectToPageResult("Index");
		}
	}
}
