using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace EFDBFirstTest1.Controllers
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
			db.Entry(site).Collection(e => e.Visitors).Load(); //explicit loading of child entities
			return View(site.Visitors);
		}

	}
}
