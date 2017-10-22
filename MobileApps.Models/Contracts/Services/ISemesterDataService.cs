using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using MobileApps.Models.Models;

namespace MobileApps.Models.Contracts.Services
{
    public interface ISemesterDataService
    {
        Task AddSemestersToSQLiteAsync(IList<Semester> semester);
		Task<IList<Semester>> GetSemesterFromSQLiteByOrganizationAsync(String Organisation, String Language);
        Task<IList<Semester>> GetSemestersFromCRMByOrganizationAsync(IList<Organization> organizations, IList<string> languages);
	}
}
