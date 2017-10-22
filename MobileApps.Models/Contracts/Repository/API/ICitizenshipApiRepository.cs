using MobileApps.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApps.Models.Contracts.Repository.API
{
    public interface ICitizenshipApiRepository
    {
        string Url { get; set; }
        Task<List<CitizenshipStatus>> GetCitizenshipStatusByOrganizationAsync(Organization organization, string language);
    }
}
