using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using MobileApps.Models.Models;

namespace MobileApps.Models.Contracts.Services
{
    public interface IObjectiveDataService
    {
        Task AddObjectivesToSQLiteAsync(IList<Objective> occupation);
        Task<IList<Objective>> GetObjectivesFromSQLiteByOrganizationAsync(Guid OrganisationID, String Language);
        Task<IList<Objective>> GetObjectivesFromCRMByOrganizationAsync(IList<Organization> organizations, IList<string> languages);
    }
}