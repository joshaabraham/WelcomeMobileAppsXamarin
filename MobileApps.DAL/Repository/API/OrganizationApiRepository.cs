using MobileApps.DAL.Repository.API;
using MobileApps.Models.Contracts.Repository.API;
using MobileApps.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApps.DAL.Repository.API
{
    public class OrganizationApiRepository : BaseApiRepository, IOrganizationApiRepository
    {
        public string Url { get; set; }
     
        public async  Task<List<Organization>> GetOrganizationsAsync(string language)
        {

            //if (string.IsNullOrEmpty(organization?.Name)) return null;
            //Url = "http://kiosk.collegelasalle.com/CRMData.svc/GetCampuses?Organisation=" + organization.Name +
            //      "&Language=" + language;
            return await GetAsync<List<Organization>>(Url);
        }
    }
}
