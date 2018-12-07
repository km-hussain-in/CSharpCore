using Microsoft.AspNetCore.Mvc;

namespace EFDBFirstTest.Controllers
{
	using Models;

	public class HomeController : Controller
	{
		private readonly IAppDbModel model;

		public HomeController(IAppDbModel injected)
		{
			model = injected;
		}

		public IActionResult Index()
		{
			return View(model.GetAllSites());
		}

		public IActionResult Details(int id)
		{
			ISite site = model.GetSiteById(id);
			if(site != null)
				return View(site);
			return NotFound();
		}

	}
}
