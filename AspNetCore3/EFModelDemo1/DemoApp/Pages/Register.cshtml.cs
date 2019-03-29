using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DemoApp.Pages
{
	using Models;
	
	public class RegisterModel : PageModel
	{
		[BindProperty]
		public Visitor Input {get; set;}
		
		public IActionResult OnPost([FromServices] IVisitorModel model)
		{
			if(ModelState.IsValid)
			{
				model.WriteVisitor(Input);
				return RedirectToPage("Index");
			}
			return Page();
		}
	}
}

