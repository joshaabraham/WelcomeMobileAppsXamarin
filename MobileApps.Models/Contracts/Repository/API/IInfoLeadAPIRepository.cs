using System.Threading.Tasks;
using System.Collections.Generic;
using MobileApps.Models.Models;

namespace MobileApps.Models.Contracts.Repository.API
{
    public interface IInfoLeadAPIRepository
    {
        string Url { get; set; }
        Task<List<InfoLead>> GetInfoLeadByOrganizationAsync(Organization organization, string email, string CRMConnectionString = "kiosk.collegelasalle.com");
    }
}
