using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DemoApp.Pages
{
    using Models;

    public class IndexModel : PageModel
    {
        public IEnumerable<Site> Sites {get; set;}

        public async void OnGetAsync([FromServices] ISiteModel model)
        {
            Sites = await model.GetAllSitesAsync();
        }
    }
}