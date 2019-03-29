using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DemoApp.Pages
{
	using Models;
	
	public class DetailsModel : PageModel
	{
		public Site Site {get; set;}
		
		public async Task<IActionResult> OnGetAsync(int id, [FromServices] SiteDbModel model)
		{
			Site = await model.GetSiteByIdAsync(id);
			if(Site == null)
				return NotFound();
			return Page();
		}
	}
}

