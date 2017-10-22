using System.Collections.Generic;
using MobileApps.Models.Models;
using System.Threading.Tasks;

namespace MobileApps.Models.Contracts.Repository.API
{
    public interface IUserAPIRepository
    {
		string Url { get; set; }
		Task<List<User>> GetUsersByOrganizationAsync(Organization organization, string language, string CRMConnectionString = "kiosk.collegelasalle.com");
    }
}
