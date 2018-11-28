using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PageModelTest.Pages
{
	public class IndexModel : PageModel
	{
		public IEnumerable<FeedbackInfo> Feedbacks {get; private set;}

		public async Task OnGet([FromServices] FeedbackClient client)
		{
			Feedbacks = await client.ReadAllAsync();
		}
	}
}
