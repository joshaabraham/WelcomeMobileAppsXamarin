using MobileApps.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApps.Models.Contracts.Repository.Api
{
    public interface IOccupationApiRepository
    {
        string Url { get; set; }
        Task<List<Occupation>> GetOccupationsByOrganizationAsync(Organization organization, string language);
    }
}
