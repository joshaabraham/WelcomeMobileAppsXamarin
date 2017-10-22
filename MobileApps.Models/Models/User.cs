using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MobileApps.Models.Models
{
    public class User : BaseModel
    {
        private Guid _UserID;
        private string _Name;

        [JsonProperty(PropertyName = "ID")]
        public Guid UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }

        [JsonProperty(PropertyName = "Value")]
        public string DirectorName
        {
            get { return Name; }
            set { Name = value; }
        }
    }

    public class UserComparer : IEqualityComparer<User>
    {
        public bool Equals(User x, User y)
        {
            return (x.UserID == y.UserID);
        }

        public int GetHashCode(User obj)
        {
            int hashUserName = obj.Name == null ? 0 : obj.Name.GetHashCode();
            int hashUserGuid = obj.UserID.GetHashCode();
            return hashUserName ^ hashUserGuid;
        }
    }
}
