using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApps.Models.Models
{
    public class InfoLead
    {
        private Guid _CRMLeadID;
        private string _FirstName;
        private string _LastName;
        private bool _HasPhoneNumber;
        private bool _HasOccupation;
        private bool _HasCitizenShip;
        private bool _HasRelocation;
        private DateTime? _CreatedOn;
        private DateTime? _ModifierOn;
        private string _Rating;
        private Guid OrganisationId;

        public Guid CRMLeadID
        {
            get { return _CRMLeadID; }
            set { _CRMLeadID = value; }
        }

        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }

        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }

        public bool HasPhoneNumber
        {
            get { return _HasPhoneNumber; }
            set { _HasPhoneNumber = value; }
        }

        public bool HasOccupation
        {
            get { return _HasOccupation; }
            set { _HasOccupation = value; }
        }

        public bool HasCitizenShip
        {
            get { return _HasCitizenShip; }
            set { _HasCitizenShip = value; }
        }

        public bool HasRelocation
        {
            get { return _HasRelocation; }
            set { _HasRelocation = value; }
        }

        public DateTime? CreatedOn
        {
            get { return _CreatedOn; }
            set { _CreatedOn = value; }
        }

        public DateTime? ModifierOn
        {
            get { return _ModifierOn; }
            set { _ModifierOn = value; }
        }

        public string Rating
        {
            get { return _Rating; }
            set { _Rating = value; }
        }
    }
}
