using MobileApps.Models.Contracts.Repository.API;
using MobileApps.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApps.DAL.Repository.API
{
    public class PotentialStudentAPIRepository : BaseAPIRepository, IPotentialStudentAPIRepository
    {
        public string Url { get; set; }
        public async Task<List<PotentialStudent>> GetPotentialStudentByOrganizationAsync(Organization organization, string language, string CRMConnectionString = "kiosk.collegelasalle.com")
        {
            if (string.IsNullOrEmpty(organization?.Name)) return null;
            Url = "http://" + CRMConnectionString + "" + organization.Name +
                  "" + language;
            return await GetAsync<List<PotentialStudent>>(Url);
        }

        public async Task<bool> PostLead(PotentialStudent lead, string baseAddress, string actionUrl)
        {
            return await Post(lead, baseAddress, actionUrl);
        }




    }
}
