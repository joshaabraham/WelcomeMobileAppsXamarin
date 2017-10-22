using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApps.Models.Models
{
    public class Program
    {
        private Guid _ProgramID;
        private string _Name;
        private string _Campus;
        private string _CampusCode;
        private Guid _organisationId;
        private string _campusKey;
        private string _langKey;
        [JsonProperty(PropertyName = "ProgramID")]
        public Guid ProgramId
        {
            get { return _ProgramID; }
            set { _ProgramID = value; }
        }

        [JsonProperty(PropertyName = "Name")]
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        [JsonProperty(PropertyName = "Campus")]
        public string Campus
        {
            get { return _Campus; }
            set { _Campus = value; }
        }
        [JsonProperty(PropertyName = "CampusCode")]
        public string CampusCode
        {
            get { return _CampusCode; }
            set { _CampusCode = value; }
        }
        public Guid OrganisationId
        {
            get
            {
                return _organisationId;
            }

            set
            {
                _organisationId = value;
            }
        }
        public string Language
        {
            get { return _langKey; }
            set { _langKey = value; }
        }
        public string CampusKey
        {
            get
            {
                return _campusKey;
            }

            set
            {
                _campusKey = value;
            }
        }

        public Program()
        {

        }
        public Program(string name)
        {
            this._organisationId = new Guid();
            this.Name = name;
        }
    }
    public class ProgramComparer : IEqualityComparer<Program>
    {
        public bool Equals(Program x, Program y)
        {
            return (x.ProgramId == y.ProgramId && x.Language == y.Language);
        }

        public int GetHashCode(Program obj)
        {
            int hashProgramName = obj.Name == null ? 0 : obj.Name.GetHashCode();
            int hashProgramGuid = obj.ProgramId.GetHashCode();
            return hashProgramName ^ hashProgramGuid;
        }
    }
}
