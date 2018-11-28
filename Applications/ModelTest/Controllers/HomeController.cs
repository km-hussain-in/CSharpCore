using Microsoft.AspNetCore.Mvc;

namespace ModelTest.Controllers
{
	using Models;

	public class HomeController : Controller
	{
		private TransientVisitorRegistry registry = new TransientVisitorRegistry();

		public IActionResult Index()
		{
			return View(registry.GetVisitors());
		}


		[HttpPost]
		public IActionResult Index(string nameToRegister)
		{
			if(nameToRegister.Length > 0)
				registry.RegisterVisit(nameToRegister);

			return Index();
		}
	}
}
