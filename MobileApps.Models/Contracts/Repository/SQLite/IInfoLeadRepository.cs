using MobileApps.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApps.Models.Contracts.Repository.SQLite
{
     public interface IInfoLeadRepository
    {
        Task AddInfoLeadAsync(IList<InfoLead> infoLead);
    //    Task<IList<InfoLead>> GetInfoLeadByOrganizationAsync(Organization organizationId);

    }
}
