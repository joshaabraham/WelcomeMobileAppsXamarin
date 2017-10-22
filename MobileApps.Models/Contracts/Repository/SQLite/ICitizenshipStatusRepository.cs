using MobileApps.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApps.Models.Contracts.Repository.SQLite
{
   public  interface ICitizenshipStatusRepository
    {
          Task AddCitizenshipStatusAsync(IList<CitizenshipStatus> citizenshipstatues);
          Task<IList<CitizenshipStatus>> GetCitizenshipStatusByOrganizationAsync(String Organisation, String Language);
    
    }
}
