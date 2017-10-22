using System.Threading.Tasks;
using System.Collections.Generic;
using MobileApps.Models.Models;

namespace MobileApps.Models.Contracts.Services
{
    public interface IProgramsDataService
    {
        Task AddProgramsToSQLiteAsync(IList<Program> programs);
        Task<IList<Program>> GetProgramsFromSQLiteByOrganizationAsync(Organization organizationId, Campus campus, string languages);
        Task<IList<Program>> GetProgramsFromCRMByOrganizationAsync(Organization organizations, string campus, string languages, string CRMConnectionString = "kiosk.collegelasalle.com");
		Task<IList<Program>> GetProgramsFromCRMByOrganizationAsync(Organization organizations, IList<string> campus, IList<string> languages, string CRMConnectionString = "kiosk.collegelasalle.com");
    }
}
