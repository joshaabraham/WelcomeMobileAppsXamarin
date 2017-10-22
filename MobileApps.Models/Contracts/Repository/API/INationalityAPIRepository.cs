using MobileApps.Models.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MobileApps.Models.Contracts.Repository.API
{
    public interface INationalityAPIRepository
    {
        string Url { get; set; }
        Task<List<Country>> GetCountriesByOrganizationAsync(Organization organization, string language, string CRMConnectionString = "kiosk.collegelasalle.com");
    }
}
