using MobileApps.Models.Contracts.Repository.API;
using System.Collections.Generic;
using System.Threading.Tasks;
using MobileApps.Models.Models;

namespace MobileApps.DAL.Repository.API
{
    public class ObjectiveAPIRepository : BaseAPIRepository, IObjectiveAPIRepository
    {
        public string Url { get; set; }

        public async Task<List<Objective>> GetObjectivesByOrganizationAsync(Organization organization, string language, string CRMConnectionString = "kiosk.collegelasalle.com")
        {
            if(string.IsNullOrEmpty(organization?.Name)) return null;
            Url = "http://" + CRMConnectionString + "" + organization.Name +
                  "" + language;
            return await GetAsync<List<Objective>>(Url);
        }
    }
}
