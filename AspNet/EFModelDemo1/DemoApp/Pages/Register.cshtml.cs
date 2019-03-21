using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DemoApp.Pages
{
    using Models;

    public class RegisterModel : PageModel
    {
        [BindProperty]
        public Visitor Visitor {get; set;}

        public IActionResult OnPost([FromServices] IVisitorModel model)
        {
            if(ModelState.IsValid)
            {
                model.WriteVisitor(Visitor);
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}