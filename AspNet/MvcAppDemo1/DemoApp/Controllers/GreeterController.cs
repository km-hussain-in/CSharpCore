using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace DemoApp.Controllers
{
    public class GreeterController : Controller
    {
        public IActionResult Time()
        {
            return Content(System.DateTime.Now.ToString());
        }

        public IActionResult Greet(string name, [FromServices] ISet<string> names)
        {
            ViewBag.Visitor = name;
            IEnumerable<string> others;
            lock(names)
            {
                names.Add(name);
                others = from n in names where n != name select n;
            }
            return View(others);
        }
    }
}
