using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MobileApps.Models.Models
{
    public class Semester
    {
        private Guid _SemesterID;
        private string _Name;

        [JsonProperty(PropertyName = "SemesterID")]
        public Guid SemesterID
        {
            get { return _SemesterID; }
            set { _SemesterID = value; }
        }

        [JsonProperty(PropertyName = "Name")]
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

    }

    public class SemesterComparer : IEqualityComparer<Semester>
    {
        public bool Equals(Semester x, Semester y)
        {
            return (x.SemesterID == y.SemesterID);
        }

        public int GetHashCode(Semester obj)
        {
            int hashSemesterName = obj.Name == null ? 0 : obj.Name.GetHashCode();
            int hashSemesterGuid = obj.SemesterID.GetHashCode();
            return hashSemesterName ^ hashSemesterGuid;
        }
    }
}