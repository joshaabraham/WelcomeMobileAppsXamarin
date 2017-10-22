using System.Collections.Generic;
using MobileApps.Models.Models;
using System.Threading.Tasks;

namespace MobileApps.Models.Contracts.Repository.API
{
    public interface ISemesterAPIRepository
    {
		string Url { get; set; }
		Task<List<Semester>> GetSemestersByOrganizationAsync(Organization organization, string language, string CRMConnectionString = "kiosk.collegelasalle.com");
    }
}
