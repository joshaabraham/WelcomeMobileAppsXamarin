using System;
using SQLite;

namespace MobileApps.Models.Models
{
    public class PotentialStudentEvent
    {
		[PrimaryKey, AutoIncrement]
        public int PotentialStudentEventID { get; set; }

        private Boolean _AllowSMS;
        private Boolean _IsExplicitConsent;
        private Guid _CampusID;
        private String _CellPhoneNumber;
        private Int32 _CitizenShipStatusID;
        private String _Email;
        private Guid _EventID;
        private String _FirstContact;
        private String _FirstName;
        private String _HomePhoneNumber;
        private Boolean _IsStudyForeignCountry;
        private Boolean _IsStudyInCanada;
        private String _Language;
        private Int32 _LastDiploma;
        private String _LastName;
        private Int32 _Occupation;
        private String _Organisation;
        private Guid _OriginCountryID;
        private Guid _OwnerID;
        private Guid _ProgramID1;
        private Guid _ProgramID2;
        private String _QuestionCustom1Answer;
        private String _QuestionCustom1CRMField;
        private String _QuestionCustom2Answer;
        private String _QuestionCustom2CRMField;
        private String _QueueName;
        private Guid _SemesterID;
        private Guid _StudyCountryID;
        private Guid _StudyFields;
        private Guid _StudyInstitutionID;
        private String _StudyInstitutionOther;
        private Int32 _StudyLevelID;
        private String _ZipCode;


  
        public Boolean AllowSMS
        {
            get { return _AllowSMS; }
            set { _AllowSMS = value; }
        }

   
        public Boolean IsExplicitConsent
        {
            get { return _IsExplicitConsent; }
            set { _IsExplicitConsent = value; }
        }

        
        public Guid CampusID
        {
            get { return _CampusID; }
            set { _CampusID = value; }
        }

        
        public String CellPhoneNumber
        {
            get { return _CellPhoneNumber; }
            set { _CellPhoneNumber = value; }
        }

       
        public Int32 CitizenShipStatusID
        {
            get { return _CitizenShipStatusID; }
            set { _CitizenShipStatusID = value; }
        }

     
        public String Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

       
        public Guid EventID
        {
            get { return _EventID; }
            set { _EventID = value; }
        }

      
        public String FirstContact
        {
            get { return _FirstContact; }
            set { _FirstContact = value; }
        }

      
        public String FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }

    
        public String HomePhoneNumber
        {
            get { return _HomePhoneNumber; }
            set { _HomePhoneNumber = value; }
        }

      
        public Boolean IsStudyForeignCountry
        {
            get { return _IsStudyForeignCountry; }
            set { _IsStudyForeignCountry = value; }
        }

      
        public Boolean IsStudyInCanada
        {
            get { return _IsStudyInCanada; }
            set { _IsStudyInCanada = value; }
        }

    
        public String Language
        {
            get { return _Language; }
            set { _Language = value; }
        }

      
        public Int32 LastDiploma
        {
            get { return _LastDiploma; }
            set { _LastDiploma = value; }
        }

 
        public String LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }

       
        public Int32 Occupation
        {
            get { return _Occupation; }
            set { _Occupation = value; }
        }

     
        public String Organisation
        {
            get { return _Organisation; }
            set { _Organisation = value; }
        }

       
        public Guid OriginCountryID
        {
            get { return _OriginCountryID; }
            set { _OriginCountryID = value; }
        }

   
        public Guid OwnerID
        {
            get { return _OwnerID; }
            set { _OwnerID = value; }
        }

  
        public Guid ProgramID1
        {
            get { return _ProgramID1; }
            set { _ProgramID1 = value; }
        }

  
        public Guid ProgramID2
        {
            get { return _ProgramID2; }
            set { _ProgramID2 = value; }
        }

       
        public String QuestionCustom1Answer
        {
            get { return _QuestionCustom1Answer; }
            set { _QuestionCustom1Answer = value; }
        }

     
        public String QuestionCustom1CRMField
        {
            get { return _QuestionCustom1CRMField; }
            set { _QuestionCustom1CRMField = value; }
        }

      
        public String QuestionCustom2Answer
        {
            get { return _QuestionCustom2Answer; }
            set { _QuestionCustom2Answer = value; }
        }

     
        public String QuestionCustom2CRMField
        {
            get { return _QuestionCustom2CRMField; }
            set { _QuestionCustom2CRMField = value; }
        }

      
        public String QueueName
        {
            get { return _QueueName; }
            set { _QueueName = value; }
        }

       
        public Guid SemesterID
        {
            get { return _SemesterID; }
            set { _SemesterID = value; }
        }

      
        public Guid StudyCountryID
        {
            get { return _StudyCountryID; }
            set { _StudyCountryID = value; }
        }

        
        public Guid StudyFields
        {
            get { return _StudyFields; }
            set { _StudyFields = value; }
        }

      
        public Guid StudyInstitutionID
        {
            get { return _StudyInstitutionID; }
            set { _StudyInstitutionID = value; }
        }

     
        public String StudyInstitutionOther
        {
            get { return _StudyInstitutionOther; }
            set { _StudyInstitutionOther = value; }
        }

      
        public Int32 StudyLevelID
        {
            get { return _StudyLevelID; }
            set { _StudyLevelID = value; }
        }

        
        public String ZipCode
        {
            get { return _ZipCode; }
            set { _ZipCode = value; }
        }
	
        public bool EnteredInCRM { get; set; }

        public override string ToString()
        {
			return string.Format("[PotentialStudent: Organisation={0}, FirstName={1}, LastName={2}, QueueName={3}]", Organisation, FirstName, LastName, QueueName);
        }
	}
}
