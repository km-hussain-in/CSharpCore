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
	
	public class DetailsModel : PageModel
	{
		private AppDbContext _model;
		
		public DetailsModel(AppDbContext model) => _model = model;
		
		public Visitor Visitor {get; set;}
		
		public void OnGet()
		{
			Visitor = _model.Visitors.Find(HttpContext.User.Identity.Name);
		}
	
		public void OnPost(string spotName)
		{
			Visitor = _model.Visitors.Find(HttpContext.User.Identity.Name);
			Visit visit = Visitor.Visits.FirstOrDefault(entry => entry.Spot == spotName);
			if(visit == null)
				Visitor.Visits.Add(new Visit(spotName, Visitor));	
			else
			{
				visit.Frequency += 1;
				visit.Recent = DateTime.Now;
			}
			_model.SaveChanges(); 
		}	
		
		public async Task<IActionResult> OnPostLogoutAsync()
		{
			await HttpContext.SignOutAsync();
			return RedirectToPage("Index");
		}
	}
}

