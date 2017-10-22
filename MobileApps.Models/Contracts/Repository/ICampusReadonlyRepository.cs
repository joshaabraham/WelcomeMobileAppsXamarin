using System.Collections.Generic;
using System.Threading.Tasks;
using MobileApps.Models.Models;

namespace MobileApps.Models.Contracts.Repository
{
    public interface ICampusReadonlyRepository
    {
        Task<IList<Campus>> GetAllCampusesAsync();
        Task<IList<Campus>> GetCampusesByOrganizationAsync(Organization organisation);
    }
}