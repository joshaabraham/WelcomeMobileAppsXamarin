using System.Threading.Tasks;
using System.Collections.Generic;
using MobileApps.Models.Models;

namespace MobileApps.Models.Contracts.Services
{
    public interface IInfoLeadDataService
    {
        Task<List<InfoLead>> GetInfoLeadFromCRMByOrganizationAsync(Organization organization, string email, string CRMConnectionString = "kiosk.collegelasalle.com");
	}
}
