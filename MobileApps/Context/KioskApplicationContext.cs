using Microsoft.Practices.Unity;
using MobileApps.DAL;
using MobileApps.DependencyInjection;
using MobileApps.Models.Contracts.Services;
using MobileApps.Models.Models;
using MobileApps.ViewModels;
using SQLite.Net;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace MobileApps.Context
{
    public class KioskApplicationContext
    {
        private PotentialStudent _leadKiosk;
        private PotentialStudentEvent _leadEvent;
        private IUnityContainer _container;
        #region Sub View-Models
        public EmailPromptViewModel EmailVm { get; set; }
        public SettingsPageViewModel SettingsVm { get; set; }
        public CampusPromptViewModel CampusVm { get; set; }
        public NamePromptViewModel NameVm { get; set; }
        public TelephonePromptViewModel TelephoneVm { get; set; }
        public CitizenShipCountryPromptViewModel CitizenshipCountryVm { get; set; }
        public ObjectivePromptViewModel ObjectiveVm { get; set; }
        public ProgramsPromptViewModel ProgramsVm { get; set; }
        public LanguagePromptViewModel LanguageVm { get; set; }
        public AcknowledgementViewModel AcknowledgementVm { get; set; }
        public IList<SubViewModel> SubViewModels { get; set; }
        #endregion
        public KioskApplicationContext()
        {
            SettingsVm = new SettingsPageViewModel();
            ClearVMData();
        }

        public void ClearVMData()
        {
			_leadKiosk = new PotentialStudent();
			_leadEvent = new PotentialStudentEvent();
            EmailVm = new EmailPromptViewModel();
            NameVm = new NamePromptViewModel();
            TelephoneVm = new TelephonePromptViewModel();
            ObjectiveVm = new ObjectivePromptViewModel();
            CampusVm = new CampusPromptViewModel();
            CitizenshipCountryVm = new CitizenShipCountryPromptViewModel();
            ProgramsVm = new ProgramsPromptViewModel();
            AcknowledgementVm = new AcknowledgementViewModel();
            LanguageVm = new LanguagePromptViewModel();
            SubViewModels = new List<SubViewModel>
            {
                SettingsVm,
                LanguageVm, 
                EmailVm,
                NameVm,
                TelephoneVm,
                ObjectiveVm,
                CampusVm,
                CitizenshipCountryVm,
                ProgramsVm, 
                AcknowledgementVm
            };

        }
        public async void SubmitLead()
        {
            _container = new DependencyInjectionRegister().GetCurrentContainer();
			SQLiteConnection db = DependencyService.Get<ISqLite>().GetConnection();

            if (MainViewModel.Instance.KioskApp.SettingsVm.EventModeActive)
                AssignLeadAttributesEvent();
            else 
                AssignLeadAttributesKiosk();
            
            await SaveInSQLiteDB(_container, db);
			ClearVMData();
        }

        private async Task SaveInSQLiteDB(IUnityContainer _currentContainer, SQLiteConnection connectionDB)
        {
            if (MainViewModel.Instance.KioskApp.SettingsVm.EventModeActive)
            {
                await _currentContainer.Resolve<IPotentialStudentEventDataService>().AddPotentialStudentEventToSQLiteAsync(_leadEvent);
                Sync.DataSynchronizer.SyncronizePotentialStudentsForEvent();
            }

            else
            {
                await _currentContainer.Resolve<IPotentialStudentDataService>().AddPotentialStudentToSQLiteAsync(_leadKiosk);
                Sync.DataSynchronizer.SyncronizePotentialStudents();
            }
        }


		private void AssignLeadAttributesEvent()
		{
			_leadEvent = new PotentialStudentEvent();

            // EVENT SPECIFIC PROPERTIES
            _leadEvent.EventID = MainViewModel.Instance.KioskApp.SettingsVm.EventChosen.EventID;
            _leadEvent.OwnerID = MainViewModel.Instance.KioskApp.SettingsVm.DirectorChosen.UserID;

			_leadEvent.QueueName = DependencyService.Get<IPreferenceRetriever>().GetQueueName();
            _leadEvent.CampusID = CampusVm.CampusChosen.CampusId;
			_leadEvent.Organisation = DependencyService.Get<IPreferenceRetriever>().GetOrganizationChosen();
			_leadEvent.FirstName = NameVm.FirstName;
			_leadEvent.LastName = NameVm.LastName;
			_leadEvent.Email = EmailVm.Email;
			_leadEvent.IsExplicitConsent = EmailVm.AllowAlerts;
			_leadEvent.Language = MainViewModel.Instance.KioskApp.LanguageVm.SelectedLanguage;

			_leadEvent.HomePhoneNumber = TelephoneVm.TelephoneHome;
			_leadEvent.CellPhoneNumber = TelephoneVm.TelephoneMobile;
            _leadEvent.ProgramID1 = ProgramsVm.ProgramChosen.ProgramId;
            _leadEvent.OriginCountryID = CitizenshipCountryVm.CountryChosen.CountryID;
		}

		private void AssignLeadAttributesKiosk()
		{
			_leadKiosk = new PotentialStudent();

			_leadKiosk.QueueName = DependencyService.Get<IPreferenceRetriever>().GetQueueName();
			_leadKiosk.FirstContact = "Kiosk";
			_leadKiosk.Organisation = DependencyService.Get<IPreferenceRetriever>().GetOrganizationChosen();
			_leadKiosk.VisitGoalID = ObjectiveVm.ObjectiveChosen.VisitGoalID;
			_leadKiosk.FirstName = NameVm.FirstName;
			_leadKiosk.LastName = NameVm.LastName;
			_leadKiosk.Email = EmailVm.Email;
			_leadKiosk.IsExplicitConsent = EmailVm.AllowAlerts;
			_leadKiosk.Language = LanguageVm.SelectedLanguage;

			if (EmailVm.LeadMatch)
			{
				_leadKiosk.CRMLeadID = EmailVm.CRMID;
				return;
			}

			_leadKiosk.CampusID = CampusVm.CampusChosen.CampusId;
			_leadKiosk.HomePhoneNumber = TelephoneVm.TelephoneHome;
			_leadKiosk.CellPhoneNumber = TelephoneVm.TelephoneMobile;
			_leadKiosk.ProgramID = ProgramsVm.ProgramChosen.ProgramId;
			_leadKiosk.CitizenShipCountryID = CitizenshipCountryVm.CountryChosen.CountryID;

		}

	}
}
