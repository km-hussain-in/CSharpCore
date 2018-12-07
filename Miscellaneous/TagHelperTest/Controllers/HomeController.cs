using Microsoft.AspNetCore.Mvc;

namespace TagHelperTest.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index(string id)
		{
			ViewBag.Visitor = id;

			return View();
		}
	}
}
