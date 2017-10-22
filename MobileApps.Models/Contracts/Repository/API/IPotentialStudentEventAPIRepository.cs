using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MobileApps.Models.Models;

namespace MobileApps.Models.Contracts.Repository.API
{
    public interface IPotentialStudentEventAPIRepository
    {
        string Url { get; set; }
		Task<List<PotentialStudentEvent>> GetPotentialStudentEventByOrganizationAsync(Organization organization, string language, string CRMConnectionString = "kiosk.collegelasalle.com");
		Task<bool> PostLead(PotentialStudentEvent lead, string baseAddress, string actionUrl);
    }
}
