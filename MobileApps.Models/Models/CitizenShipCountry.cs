using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApps.Models.Models
{
    public class CitizenShipCountry
    {
        public Guid CitizenShipCountryId { get; set; }

        public string CountryName { get; set; }

        public Guid OrganizationId { get; set; }
    }
}
