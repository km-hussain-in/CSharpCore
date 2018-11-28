using Microsoft.AspNetCore.Mvc;

namespace MvcRouteTest.Controllers
{
	public class GreeterController : Controller
	{
		public IActionResult Greet(string name)
		{
			ViewBag.Visitor = name;

			return View();
		}
	}
}
