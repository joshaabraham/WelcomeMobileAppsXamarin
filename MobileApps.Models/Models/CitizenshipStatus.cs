using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApps.Models.Models
{
    
    public class CitizenshipStatus
    {
        private int _CitizenshipStatusID;
        private string _Name;

        private Guid _OrganizationId;
       

        public int CitizenshipStatusID
        {
            get { return _CitizenshipStatusID; }
            set { _CitizenshipStatusID = value; }
        }


        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public Guid OrganizationId
        {
            get
            {
                return _OrganizationId;
            }

            set
            {
                _OrganizationId = value;
            }
        }
    }
}
