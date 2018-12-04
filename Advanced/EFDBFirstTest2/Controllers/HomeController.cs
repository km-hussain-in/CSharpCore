using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace EFDBFirstTest2.Controllers
{
	using Models;

	public class HomeController : Controller
	{
		private readonly AppDbContext db;

		public HomeController(AppDbContext injected)
		{
			db = injected;
		}

		public IActionResult Index()
		{
			return View(db.Sites.ToList());
		}

		public IActionResult Details(int id)
		{
			var site = db.Sites.Find(id);
			if(site == null) return NotFound();
			ViewBag.SiteName = site.Name;
			return View(site.Visitors); // automatic lazy loading of child entities (required virtual navigation property along with proxy support)
		}

	}
}
