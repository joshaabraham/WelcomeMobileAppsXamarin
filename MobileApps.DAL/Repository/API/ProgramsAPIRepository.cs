using MobileApps.Models.Contracts.Repository.API;
using MobileApps.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApps.DAL.Repository.API
{
    public class ProgramsAPIRepository : BaseAPIRepository, IProgramsAPIRepository
    {
        public string Url { get; set; }

        public async Task<List<Program>> GetAllPrograms(Organization organization, string language, string CRMConnectionString = "kiosk.collegelasalle.com")
        {
            if (string.IsNullOrEmpty(organization?.Name)) return null;
            Url = "http://" + CRMConnectionString + "" + organization.Name +
                "" + language +
                "";
            return await GetAsync<List<Program>>(Url);
        }

        public async Task<List<Program>> GetProgramsByOrganizationAsync(Organization organization, string campus, string language, string CRMConnectionString = "kiosk.collegelasalle.com")
        {
            if (string.IsNullOrEmpty(organization?.Name)) return null;
            Url = "http://" + CRMConnectionString+"" + organization.Name +
                "" + language +
                "" + campus;
            return await GetAsync<List<Program>>(Url);
        }


    }
}
