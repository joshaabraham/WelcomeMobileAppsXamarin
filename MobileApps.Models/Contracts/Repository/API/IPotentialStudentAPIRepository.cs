using MobileApps.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApps.Models.Contracts.Repository.API
{
    public interface IPotentialStudentAPIRepository
    {
        string Url { get; set; }
        Task<List<PotentialStudent>> GetPotentialStudentByOrganizationAsync(Organization organization, string language, string CRMConnectionString = "kiosk.collegelasalle.com");
        Task<bool> PostLead(PotentialStudent lead, string baseAddress, string actionUrl);

    }
}
