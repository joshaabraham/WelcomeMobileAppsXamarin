using MobileApps.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApps.Models.Contracts.Repository.API
{
    public interface ILeadApiRepository
    {
        string Url { get; set; }
        Task<List<Lead>> GetLeadsByOrganizationAsync(Organization organization, string language);
    }
}
