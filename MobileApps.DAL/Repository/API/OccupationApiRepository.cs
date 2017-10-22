using MobileApps.Models.Contracts.Repository.Api;
using MobileApps.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApps.DAL.Repository.API
{
   public class OccupationApiRepository : BaseApiRepository, IOccupationApiRepository
    {
        public string Url { get; set; }
        public async Task<List<Occupation>> GetOccupationsByOrganizationAsync(Organization organization, string language)
        {
            if (string.IsNullOrEmpty(organization?.Name)) return null;
            Url = "http://kiosk.collegelasalle.com/CRMData.svc/GetOccupations?Organisation=" + organization.Name +
                  "&Language=" + language;
            return await GetAsync<List<Occupation>>(Url);
        }
    }
}
