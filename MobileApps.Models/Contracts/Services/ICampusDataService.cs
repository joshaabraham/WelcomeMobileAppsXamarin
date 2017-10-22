using System.Threading.Tasks;
using System.Collections.Generic;
using MobileApps.Models.Models;

namespace MobileApps.Models.Contracts.Services
{
    public interface ICampusDataService
    {
        Task AddCampusesToSQLiteDBAsync(IList<Campus> campuses);
        Task<IList<Campus>> GetCampusesFromSQLiteDBByOrganizationAsync(Organization organisation, string language);
        Task<IList<Campus>> GetCampusesFromCRMByOrganizationAsync(IList<Organization> organizations, IList<string> languages);
	}
}