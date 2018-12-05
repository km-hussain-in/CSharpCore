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
			{
				ViewBag.SiteName = site.Name;
				return View(model.GetSiteVisitors(id));
			}
			return NotFound();
		}

	}
}
