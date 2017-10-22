using MobileApps.Models.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MobileApps.Models.Contracts.Repository.API
{
    public interface IProgramsAPIRepository
    {
        string Url { get; set; }
        Task<List<Program>> GetProgramsByOrganizationAsync(Organization organization, string campus, string language,string CRMConnectionString = "kiosk.collegelasalle.com");      
        Task<List<Program>> GetAllPrograms(Organization organization, string language,string CRMConnectionString = "kiosk.collegelasalle.com");

    }
}
