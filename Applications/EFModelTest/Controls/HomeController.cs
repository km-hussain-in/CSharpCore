using Microsoft.AspNetCore.Mvc;

namespace EFModelTest.Controllers
{
	using Models;

	public class HomeController : Controller
	{
		private readonly IVisitorRegistry registry;

		public HomeController(IVisitorRegistry injected)
		{
			registry = injected;
		}

		public IActionResult Index()
		{
			return View(registry.GetVisitors());
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(string nameToRegister)
		{
			if(nameToRegister.Length > 0)
				registry.RegisterVisit(nameToRegister);

			return RedirectToAction("Index");
		}
	}
}
