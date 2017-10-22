using MobileApps.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApps.Models.Contracts.Repository.API
{
    public interface IObjectiveAPIRepository
    {
        string Url { get; set; }
        Task<List<Objective>> GetObjectivesByOrganizationAsync(Organization organization, string language, string CRMConnectionString = "kiosk.collegelasalle.com");
    }
}
