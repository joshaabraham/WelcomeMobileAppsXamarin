using MobileApps.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApps.Models.Contracts.Repository
{
    public interface ICitizenShipCountryReadonlyRepository
    {
        Task<IList<CitizenShipCountry>> GetAllCitizenShipCountryAsync();
        Task<IList<CitizenShipCountry>> GetCitizenShipCountryByOrganizationAsync(string organizationId);
    }
}
