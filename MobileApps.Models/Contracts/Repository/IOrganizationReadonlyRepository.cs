using MobileApps.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApps.Models.Contracts.Repository
{
    public interface IOrganizationReadonlyRepository
    {
        Task<IList<string>> GetAllOrganizationesAsync();
        Task<IList<string>> GetOrganizationesByNameAsync(string organisation);
    }
}
