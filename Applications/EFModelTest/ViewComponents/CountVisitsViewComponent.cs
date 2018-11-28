using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace EFModelTest.ViewComponents
{
        using Models;

        public class CountVisitsViewComponent : ViewComponent
        {
                private IVisitorRegistry registry;

                public CountVisitsViewComponent(IVisitorRegistry injected)
                {
                        registry = injected;
                }

                public async Task<IViewComponentResult> InvokeAsync(DateTime after, DateTime before)
                {
                        var visitors = await GetVisitorsAsync();

                        var selection = from v in visitors
                                        where v.Recent > after && v.Recent < before
                                        select v.Frequency;

                        return View(selection.Sum());
                }

                private Task<IEnumerable<Visitor>> GetVisitorsAsync()
                {
                        return Task.FromResult(registry.GetVisitors());
                }
        }
}
