using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DemoApp.Pages
{
    using Models;

    public class IndexModel : PageModel
    {
        public IEnumerable<Visitor> Visitors {get; set;}

        public void OnGet([FromServices] IVisitorModel model)
        {
            Visitors = model.ReadVisitors();
        }
    }
}