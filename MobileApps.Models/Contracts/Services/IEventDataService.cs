using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using MobileApps.Models.Models;

namespace MobileApps.Models.Contracts.Services
{
    public interface IEventDataService
    {
		Task AddEventToSQLiteAsync(IList<Event> eventObj);
        Task<IList<Event>> GetEventFromSQLiteByOrganizationAsync(Organization Organisation, String Language);
        Task<IList<Event>> GetEventsFromCRMByOrganizationAsync(IList<Organization> organizations, IList<string> languages);
	}
}
