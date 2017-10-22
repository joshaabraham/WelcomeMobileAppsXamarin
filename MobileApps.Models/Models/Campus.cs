using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MobileApps.Models.Models
{
    [DataContract]
    public class Campus : BaseModel
    {
        //[DataMember(Name = "CampusID")]
        [JsonProperty(PropertyName = "CampusID")]
        public Guid CampusId { get; set; }

        public Campus(Guid campusId, string name, Guid organizationId)
        {
            CampusId = campusId;
            Name = name;
            OrganizationId = organizationId;
        }
        public Campus(Guid campusId, string name)
        {
            CampusId = campusId;
            Name = name;
        }
        public Campus() { }

        public override string ToString()
        {
            return Name;
        }
    }


    public class CampusComparer : IEqualityComparer<Campus>
    {
        public bool Equals(Campus x, Campus y)
        {
            return (x.CampusId == y.CampusId);
        }

        public int GetHashCode(Campus obj)
        {
            int hashCampusName = obj.Name == null ? 0 : obj.Name.GetHashCode();
            int hashCampusGuid = obj.CampusId.GetHashCode();
            return hashCampusName ^ hashCampusGuid;
        }
    }
}
