using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileApps.Models.Contracts.Repository.API;
using MobileApps.Models.Models;

namespace MobileApps.DAL.Repository.API
{
    public class CitizenshipStatusRepository: BaseApiRepository, ICitizenshipApiRepository
    {
        public string Url { get; set; }

        public async Task<List<CitizenshipStatus>> GetCitizenshipStatusByOrganizationAsync(Organization organization, string language)
        {
            if (string.IsNullOrEmpty(organization?.Name)) return null;
            Url = "http://kiosk.collegelasalle.com/CRMData.svc/GetCitizenshipStatuses?Organisation=" + organization.Name +
                  "&Language=" + language;
            return await GetAsync<List<CitizenshipStatus>>(Url);
        }
    }
}
