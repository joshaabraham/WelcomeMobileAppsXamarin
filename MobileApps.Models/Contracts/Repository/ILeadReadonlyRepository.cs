using MobileApps.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApps.Models.Contracts.Repository
{
    public interface ILeadReadonlyRepository
    {
        Task<IList<Lead>> GetAllLeadsAsync();


        Task<IList<Lead>> GetLeadsByOrganizationAsync(string organizationId);

        Task<IList<Lead>> GetLeadsByEmailAsync(string email);

        Task<IList<Lead>> GetLeadsByOrganizationAndEmailAsync(string organizationId, string email);
    }
}
