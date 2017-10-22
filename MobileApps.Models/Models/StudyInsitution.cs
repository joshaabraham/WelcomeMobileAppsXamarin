using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApps.Models.Models
{
    public class StudyInstitution
    {
        public Guid StudyInstitutionId { get; set; }
        public string Name { get; set; }

        public Guid OrganizationId { get; set; }

        public StudyInstitution()
        {

        }

        public StudyInstitution(Guid Id, string name, Guid organizationId)
        {
            this.StudyInstitutionId = Id;
            this.Name = name;
            this.OrganizationId = organizationId;
        }
    }
}
