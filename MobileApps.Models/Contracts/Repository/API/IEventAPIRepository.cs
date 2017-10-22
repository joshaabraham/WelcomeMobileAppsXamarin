using System.Collections.Generic;
using MobileApps.Models.Models;
using System.Threading.Tasks;

namespace MobileApps.Models.Contracts.Repository.API
{
    public interface IEventAPIRepository
    {
		string Url { get; set; }
		Task<List<Event>> GetEventsByOrganizationAsync(Organization organization, string language, string CRMConnectionString = "kiosk.collegelasalle.com");
    }
}
