using MobileApps.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApps.Models.Contracts.Repository.SQLite
{
    public interface ILeadRepository 
    {
        Task<IList<Lead>> GetAllLeadsAsync();

        Task<IList<Lead>> GetLeadsByOrganizationAsync(Organization organizationId);

        Task<IList<Lead>> GetLeadsByEmailAsync(string email);

        Task AddLeadsAsync(IList<Lead> leads);

        Task<IList<Lead>> GetLeadsByOrganizationAndEmailAsync(Organization organizationId, string email);


        bool IsImportedAsync(Lead activityId);

        Task AddLeadAsync(Lead aLead);

        Task<IList<Lead>> GetLeadsByCrmAndEmailAsync(Guid crm, string email);

        Task SaveLeadsByCrmAsync(Guid crm, IList<Lead> leads);

    }
}
