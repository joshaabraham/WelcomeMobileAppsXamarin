using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using MobileApps.Models.Models;

namespace MobileApps.Models.Contracts.Services
{
    public interface IUserDataService
    {
		Task AddUserToSQLiteAsync(IList<User> eventObj);
        Task<IList<User>> GetUserFromSQLiteByOrganizationAsync(Organization Organisation, String Language);
        Task<IList<User>> GetUsersFromCRMByOrganizationAsync(IList<Organization> organizations, IList<string> languages);
	}
}
