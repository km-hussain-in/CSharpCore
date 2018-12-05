using System;
using System.Collections.Generic;

namespace EFDBFirstTest.Models
{
	public class SiteViewModel
	{
		public string SiteName {get; set;}

		public IEnumerable<IVisitor> SiteVisitors {get; set;}
	}
}