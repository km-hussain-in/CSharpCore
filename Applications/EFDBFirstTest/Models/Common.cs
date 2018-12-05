using System;
using System.Collections.Generic;

namespace EFDBFirstTest.Models
{
	public interface ISite
	{
		int Id {get; set;}

		string Name {get; set;}

		string Location {get; set;}

		decimal? Ticket {get; set;}
	}

	public interface IVisitor
	{
		string Id {get; set;}

		int SiteId {get; set;}

		int Frequency {get; set;}

		DateTime Recent {get; set;}
	}
		
	public interface IAppDbModel
	{
		IEnumerable<ISite> GetAllSites();

		ISite GetSiteById(int siteId);

		IEnumerable<IVisitor> GetSiteVisitors(int siteId);
	}
}
