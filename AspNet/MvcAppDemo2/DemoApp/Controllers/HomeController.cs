using Microsoft.AspNetCore.Mvc;

namespace DemoApp.Controllers
{
    using Models;

    public class HomeController : Controller
    {
        private IVisitorModel _model;

        public HomeController(IVisitorModel model) => _model = model;

        public IActionResult Index()
        {
            return View(_model.ReadVisitors());
        }

        public IActionResult Register()
        {
            return View(new Visitor());
        }

        [HttpPost]
        public IActionResult Register(Visitor input)
        {
            if(ModelState.IsValid)
            {
                _model.WriteVisitor(input);
                return RedirectToAction("Index");
            }
            return View(input);
        }
    }
}
