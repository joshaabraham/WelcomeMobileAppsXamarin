using MobileApps.DAL.Repository.API;
using MobileApps.Models.Contracts.Repository.Api;
using MobileApps.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApps.DAL.Repository
{
    public class StudyInstitutionsApiRepository: BaseApiRepository, IStudyInstitutionApiRepository
    {
        public string Url { get; set; }
        public async Task<List<StudyInstitution>> GetInstitutionsByOrganizationAsync(Organization organization, string language)
        {
            if (string.IsNullOrEmpty(organization?.Name)) return null;
            Url = "http://kiosk.collegelasalle.com/CRMData.svc/GetStudyInstitutions?Organisation=" + organization.Name +
                  "&Language=" + language;
            return await GetAsync<List<StudyInstitution>>(Url);
        }
    }
}
