using MobileApps.Models.Contracts.Repository.API;
using MobileApps.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApps.DAL.Repository.API
{
    public class InfoLeadAPIRepository : BaseAPIRepository, IInfoLeadAPIRepository
    {
        public string Url { get; set; }
        public async Task<List<InfoLead>> GetInfoLeadByOrganizationAsync(Organization organization, string email, string CRMConnectionString= "kiosk.collegelasalle.com")
        {
            if (string.IsNullOrEmpty(organization?.Name)) return null;
            Url = "http://"+CRMConnectionString + "" + organization.Name +
                  "" + email;
            List<InfoLead> LeadMatch = new List<InfoLead>();
            try
            {
                LeadMatch.Add(await GetAsync<InfoLead>(Url));
            }
            catch { return new List<InfoLead>(); }
            return LeadMatch;
        }
    }
}
