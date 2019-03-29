using System;
using System.Collections.Concurrent;
using Microsoft.AspNetCore.Mvc;

namespace DemoApp.ViewComponents
{
	public class VisitInfo
	{
		public string Visitor {get; set;}
		
		public int Visits {get; set;}
	}
	
	public class CountVisitsViewComponent : ViewComponent
	{
		private static ConcurrentDictionary<string, int> counters = new ConcurrentDictionary<string, int>();
		
		public IViewComponentResult Invoke(string forName)
		{
			int count;
			counters.TryGetValue(forName, out count);
			counters[forName] = ++count;
			return View(new VisitInfo{Visitor = forName, Visits = count});
		}
	}
}

