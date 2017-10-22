using MobileApps.Models.Models;
using System;
using SQLite;

namespace MobileApps.Models.Models
{
    public class PotentialStudent
    {
        #region "Private Variable"

        private Guid organizationId;

        /// <summary>
        /// Primary Key
        /// </summary>        
        private Guid _CRMLeadID;

        /// <summary>
        /// Specify the Organisation in which the data will be inserted
        /// </summary>
        private string _Organisation;

        /// <summary>
        /// Specify the language of the potential lead
        /// </summary>
        private string _Language;


        /// <summary>
        /// Email of the potential lead
        /// </summary>
        private string _Email;

        /// <summary>
        /// Check if potential Lead agree to be contact by email or not
        /// </summary>
        private bool _DonotEmail;

        /// <summary>
        /// Check if potential Lead gives his explicit consent
        /// </summary>
        private bool _IsExplicitConsent;


        /// <summary>
        /// FirstName of the potential lead
        /// </summary>
        private string _FirstName;

        /// <summary>
        /// LastName of the Potential Lead
        /// </summary>
        private string _LastName;

        /// <summary>
        /// Home Phone Number of the potential lead
        /// </summary>
        private string _HomePhoneNumber;

        /// <summary>
        /// Cell Phone Number of the potential lead
        /// </summary>
        private string _CellPhoneNumber;

        /// <summary>
        /// Check if potential lead agree to be contact by phone or not
        /// </summary>
        private bool _DoNotPhone;

        /// <summary>
        /// Actual Occupation of the potential lead 
        /// </summary>
        private int _Occupation;

        /// <summary>
        /// Check if the potential lead has studied in quebec or not
        /// </summary>
        private bool _HasStudyInQuebec;

        /// <summary>
        /// ID of the program from the list
        /// </summary>
        private Guid _ProgramID;

        /// <summary>
        /// ID of the Study Institution from the list
        /// </summary>
        private Guid _StudyInstitutionID;

        /// <summary>
        /// Study Institution Name is not in the list
        /// </summary>
        private string _StudyInstitutionOther;

        /// <summary>
        /// ID of the Study Level from the list
        /// </summary>
        private int _StudyLevelID;

        /// <summary>
        /// Study Level Name if not in the list
        /// </summary>
        private string _StudyLevelOther;

        /// <summary>
        /// ID of the Country of Study
        /// </summary>
        private Guid _StudyCountryID;

        /// <summary>
        /// ID of the CitizenShip status from the list
        /// </summary>
        private int _CitizenshipStatusID;

        /// <summary>
        /// ID of the CitizenShip Country from the list
        /// </summary>
        private Guid _CitizenShipCountryID;


        /// <summary>
        /// Check if the potential lead is relocating or not
        /// </summary>
        private bool _IsRelocating;

        /// <summary>
        /// ID of the Relocation option selected from the list
        /// </summary>
        private int _OptionRelocationID;

        /// <summary>
        /// Relocation value that are not in the list
        /// </summary>
        private string _OtherOptionRelocation;

        /// <summary>
        /// ID of the Visit Goal selected from the list
        /// </summary>
        private int _VisitGoalID;

        /// <summary>
        /// Name of the queue that the potential lead will be related to
        /// </summary>
        private string _QueueName;

        /// <summary>
        /// Name of the First Contact that the potential lead will be related to
        /// </summary>
        private string _FirstContact;

        private string _LocationCampus;

        private Guid _CampusID;

        #endregion

        #region "Public Properties"

        [PrimaryKeyAttribute, AutoIncrement]
        public int ID{get; set;}

        /// <summary>
        /// CRMLeadID property
        /// </summary>

        public Guid CRMLeadID
        {
            get { return _CRMLeadID; }
            set { _CRMLeadID = value; }
        }

        public bool EnteredInCRM { get; set; }

        /// <summary>
        /// Organisation Property
        /// </summary>

        public string Organisation
        {

            get { return _Organisation; }
            set { _Organisation = value; }

        }

        /// <summary>
        /// Language Property
        /// </summary>

        public string Language
        {

            get { return _Language; }
            set { _Language = value; }

        }

        /// <summary>
        /// Email Property
        /// </summary>]
        public string Email
        {

            get { return _Email; }
            set { _Email = value; }

        }

        /// <summary>
        /// AgreeContactByEmail property
        /// </summary>

        public bool DonotEmail
        {

            get { return _DonotEmail; }
            set { _DonotEmail = value; }

        }

        /// <summary>
        /// IsExplicitConsent Property
        /// </summary>

        public bool IsExplicitConsent
        {
            get { return _IsExplicitConsent; }
            set { _IsExplicitConsent = value; }
        }

        /// <summary>
        /// FirstName Property
        /// </summary>

        public string FirstName
        {

            get { return _FirstName; }
            set { _FirstName = value; }

        }

        /// <summary>
        /// LastName Property
        /// </summary>

        public string LastName
        {

            get { return _LastName; }
            set { _LastName = value; }

        }

        /// <summary>
        /// HomePhoneNumber property
        /// </summary>
 
        public string HomePhoneNumber
        {

            get { return _HomePhoneNumber; }
            set { _HomePhoneNumber = value; }


        }


  
        public string CellPhoneNumber
        {

            get { return _CellPhoneNumber; }
            set { _CellPhoneNumber = value; }


        }

        /// <summary>
        /// IsAgreeContactByPhone Property
        /// </summary>
      
        public bool DoNotPhone
        {

            get { return _DoNotPhone; }
            set { _DoNotPhone = value; }

        }

        /// <summary>
        /// Occupation Property
        /// </summary>
     
        public int Occupation
        {

            get { return _Occupation; }
            set { _Occupation = value; }

        }

        /// <summary>
        /// HaStudyInQuebec Property
        /// </summary>
    
        public bool HasStudyInQuebec
        {

            get { return _HasStudyInQuebec; }
            set { _HasStudyInQuebec = value; }

        }

   
        public Guid ProgramID
        {

            get { return _ProgramID; }
            set { _ProgramID = value; }

        }

        /// <summary>
        /// StudyInstitutionID Property
        /// </summary>
   
        public Guid StudyInstitutionID
        {

            get { return _StudyInstitutionID; }
            set { _StudyInstitutionID = value; }

        }

        /// <summary>
        /// StudyInstitutionOther Property
        /// </summary>

        public string StudyInstitutionOther
        {

            get { return _StudyInstitutionOther; }
            set { _StudyInstitutionOther = value; }

        }

        /// <summary>
        /// StudyLevelID Property
        /// </summary>
  
        public int StudyLevelID
        {

            get { return _StudyLevelID; }
            set { _StudyLevelID = value; }

        }


        /// <summary>
        /// StudyLevelOther Property
        /// </summary>
  
        public string StudyLevelOther
        {

            get { return _StudyLevelOther; }
            set { _StudyLevelOther = value; }

        }

        /// <summary>
        /// StudyCountryID Property
        /// </summary>
     
        public Guid StudyCountryID
        {

            get { return _StudyCountryID; }
            set { _StudyCountryID = value; }

        }

        /// <summary>
        /// CitizenShipStatudID Property
        /// </summary>
     
        public int CitizenShipStatusID
        {

            get { return _CitizenshipStatusID; }
            set { _CitizenshipStatusID = value; }

        }

        /// <summary>
        /// CitizenShipCountryID Property
        /// </summary>
     
        public Guid CitizenShipCountryID
        {

            get { return _CitizenShipCountryID; }
            set { _CitizenShipCountryID = value; }

        }


        /// <summary>
        /// IsRelocating Property
        /// </summary>
 
        public bool IsRelocating
        {

            get { return _IsRelocating; }
            set { _IsRelocating = value; }

        }

        /// <summary>
        /// OptinRelocationID Property
        /// </summary>
     
        public int OptionRelocationID
        {

            get { return _OptionRelocationID; }
            set { _OptionRelocationID = value; }

        }

        /// <summary>
        /// OtherOptionRelocation Property
        /// </summary>

        public string OtherOptionRelocation
        {

            get { return _OtherOptionRelocation; }
            set { _OtherOptionRelocation = value; }

        }

        /// <summary>
        /// VisitGoalID Property
        /// </summary>
     
        public int VisitGoalID
        {

            get { return _VisitGoalID; }
            set { _VisitGoalID = value; }

        }

        /// <summary>
        /// QueueName Property
        /// </summary>

        public string QueueName
        {

            get { return _QueueName; }
            set { _QueueName = value; }
        }

        /// <summary>
        /// FirstContact Property
        /// </summary>

        public string FirstContact
        {

            get { return _FirstContact; }
            set { _FirstContact = value; }

        }

      
        public string LocationCampus { get { return _LocationCampus; } set { _LocationCampus = value; } }
     
        public Guid CampusID { get { return _CampusID; } set { _CampusID = value; } }

        public Guid OrganizationId
        {
            get
            {
                return organizationId;
            }

            set
            {
                organizationId = value;
            }
        }
        #endregion
    
        public override string ToString()
        {
            return string.Format("[PotentialStudent: Organisation={0}, FirstName={1}, LastName={2}, QueueName={3}]", Organisation, FirstName, LastName, QueueName);
        }
    }
}

public class PotentialStudentEntered
{
    bool isEnteredInCRM;
    PotentialStudent student;

    public PotentialStudentEntered(PotentialStudent student, bool enteredInCRM)
    {
        this.student = student;
        this.isEnteredInCRM = enteredInCRM;
    }
}