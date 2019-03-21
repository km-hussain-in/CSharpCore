using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace DemoApp.Models
{
    public interface ISiteModel
    {
        Task<IEnumerable<Site>> GetAllSitesAsync();

        Task<Site> GetSiteByIdAsync(int siteId);
    }
}
