using MobileApps.Models.Contracts.Repository.API;
using MobileApps.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApps.DAL.Repository.API
{
    public class LeadApiRepository : BaseApiRepository, ILeadApiRepository
    {
        public string Url { get; set; }
        public async Task<List<Lead>> GetLeadsByOrganizationAsync(Organization organization, string language)
        {
            if (string.IsNullOrEmpty(organization?.Name)) return null;
            Url = "http://kiosk.collegelasalle.com/CRMData.svc/GetCampuses?Organisation=" + organization.Name +
                  "&Language=" + language;
            return await GetAsync<List<Lead>>(Url);
        }

        public async Task<bool> PostLead(Lead lead,string baseAddress, string actionUrl)
        {
            return await Post(lead, baseAddress, actionUrl);
        }

    }
}
