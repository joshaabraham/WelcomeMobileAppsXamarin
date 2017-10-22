using MobileApps.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApps.Models.Contracts.Repository
{
     public interface IOccupationRepository
    {
        Task AddOccupationsAsync(IList<Occupation> campuses);
        Task<IList<Occupation>> GetOccupationsByOrganizationAsync(String Organisation, String Language);
    }
}
