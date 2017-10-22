using System.Threading.Tasks;
using System.Collections.Generic;
using MobileApps.Models.Models;

namespace MobileApps.Models.Contracts.Repository.SQLite
{
    public interface IProgramsRepository
    {
        Task AddProgramsAsync(IList<Program> programs);
        Task<IList<Program>> GetProgramsByOrganizationAsync(Organization organizationId);
        Task<IList<Program>> GetProgramsByCampusAndOrganization(Organization organization, Campus campus, string language);
    }
}
