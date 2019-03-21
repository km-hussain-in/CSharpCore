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
        [BindProperty]
        public Visitor Visitor {get; set;}

        public void OnGet()
        {
            Visitor = new Visitor();
        }

        public async Task<IActionResult> OnPostAsync([FromServices] VisitorModel model)
        {
            var user = model.Visitors.Find(Visitor.Id);
            if(user == null)
            {
                model.Visitors.Add(Visitor);
                model.SaveChanges();
                user = Visitor;
            }
            else if(user.Password != Visitor.Password)
            {
                    ModelState.AddModelError("Visitor.Password", "Invalid");
                    return Page();
            }
            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            identity.AddClaim(new Claim(ClaimTypes.Name, Visitor.Id));
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, 
                new ClaimsPrincipal(identity),
                new AuthenticationProperties{IsPersistent = false});
            return RedirectToPage("Visitation");
        }
    }
}
