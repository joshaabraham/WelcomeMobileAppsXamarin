using System;

namespace MobileApps.Models.Models
{
    public class Lead : BaseModel
    {
        public Guid LeadId { get; set; }
  
        public Guid ActivityId { get; set; }

        public Guid OrganizationId { get; set; }

        public Guid CampusId { get; set; }

        public Guid StudyInstitutionId { get; set; }

        public Guid CitizenShipCountryId { get; set; }

        public string Language { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
 
        public string HomePhoneNumber { get; set; }

        public string CellPhoneNumber { get; set; }

        public string Occupation { get; set; }

        public bool HasStudyInQuebec { get; set; }

        public bool IsExplicitConsent { get; set; }

        public string StudyInstitutionOther { get; set; }


        public Lead() { }

        public Lead(
            Guid organizationId, string language, string email, string firstName,
            string lastName, string homePhoneNumber, string cellPhoneNumber, string occupation,
            bool hasStudyInQuebec, Guid campusId, bool isExplicitConsent, Guid studyInstitutionId,
            string studyInstitutionOther, Guid citizenShipCountryId, Guid activityId)
        {
            OrganizationId = organizationId;
            Language = language;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            HomePhoneNumber = homePhoneNumber;
            CellPhoneNumber = cellPhoneNumber;
            Occupation = occupation;
            HasStudyInQuebec = hasStudyInQuebec;
            CampusId = campusId;
            IsExplicitConsent = isExplicitConsent;
            StudyInstitutionId = studyInstitutionId;
            StudyInstitutionOther = studyInstitutionOther;
            CitizenShipCountryId = citizenShipCountryId;
            ActivityId = activityId;
        }
    }
}
