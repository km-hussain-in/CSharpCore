using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DemoApp.Pages
{
    using Models;

    public class DetailsModel : PageModel
    {
        public Site Site {get; set;}

        public async void OnGetAsync(int id, [FromServices] ISiteModel model)
        {
            Site = await model.GetSiteByIdAsync(id);
        }
    }
}