using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using MobileApps.Models.Models;

namespace MobileApps.Models.Contracts.Services
{
    public interface INationalityDataService
    {
        Task AddCountryInSQLiteAsync(IList<Country> citizenShipCountry);
        Task<IList<Country>> GetCountriesFromSQLiteAsync();
        Task<List<Country>> GetCountriesByOrganizationFromCRMAsync(Organization organization, string language);
	}
}
