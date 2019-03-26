using System;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace DemoApp.Controllers
{
    public class Controller
    {
        public bool View(object model, [CallerMemberName] string action = null)
        {
            Type viewClass = Type.GetType("DemoApp.Views." + action);
            object view = Activator.CreateInstance(viewClass);
            return (bool)viewClass.InvokeMember("Present", BindingFlags.InvokeMethod, null, view, new object[]{model});
        }

        public bool InvokeAction(string name)
        {
            try
            {
                return (bool)GetType().InvokeMember(name, BindingFlags.InvokeMethod, null, this, null);
            }
            catch(MissingMethodException)
            {
                return false;
            }
        }        
    }

    public class VisitorsController : Controller
    {
        private Models.IVisitorModel model = new Models.VisitorDocModel();

        public bool Index()
        {
            return View(model.ReadVisitors());
        }

        public bool Register()
        {
            var input = new Models.Visitor();
            bool modelStateIsValid = View(input);
            if(modelStateIsValid)
                model.WriteVisitor(input);
            return modelStateIsValid;
        }

    }
}
