using System;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace DemoApp.Pages
{
	using Models;
	
	public class IndexModel : PageModel
	{
		private AppDbContext _db;

		[BindProperty]
		public Visitor Input {get; set;}

		public IndexModel(AppDbContext db) => _db = db;
		
		public void OnGet() => Input = new Visitor();
	
		public async Task<IActionResult> OnPostAsync(string signCommand)
		{
			bool succeeded;
			if(signCommand == "Sign-Up")
				succeeded = await DoSignUp();
			else
				succeeded = await DoSignIn();
			if(!succeeded)
				return Page();
			var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
			identity.AddClaim(new Claim(ClaimTypes.Name, Input.Id));
			await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
				new ClaimsPrincipal(identity),
				new AuthenticationProperties{IsPersistent = false});
			return RedirectToPage("Details");			
		}

		private async Task<bool> DoSignUp()
		{
			var user = await _db.Visitors.FindAsync(Input.Id);
			if(user == null)
			{
				if(Input.Password == Input.ConfirmPassword)
				{
					_db.Visitors.Add(Input);
					await _db.SaveChangesAsync();
					return true;
				}
				ModelState.AddModelError("Input.Password", "Passwords don't match");
				return false;
			}
			ModelState.AddModelError("Input.Id", "Id not available");
			return false;
		}

		private async Task<bool> DoSignIn()
		{
			var user = await _db.Visitors.FindAsync(Input.Id);
			if(user == null || user.Password != Input.Password)
			{
				ModelState.AddModelError("Input.Password", "Incorrect Id or Password");
				return false;
			}
			return true;
		}
	
	}
}

