using MobileApps.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApps.Models.Contracts.Repository.SQLite
{
    public interface IOrganizationRepository
    {
        Task<IList<Organization>> GetAllOrganizationesAsync();

        Task<IList<Organization>> GetOrganizationesByNameAsync(string organization);

        Task AddOrganizationesAsync(IList<Organization> Organizationes);
    }
}
