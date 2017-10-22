using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using MobileApps.DAL;
using MobileApps.Models.Models;
using MobileApps.BL.StaticData;
using MobileApps.DependencyInjection;
using Microsoft.Practices.Unity;
using Xamarin.Forms;
using MobileApps.Models.Contracts.Services;

namespace MobileApps.ViewModels
{
    public class SettingsPageViewModel : SubViewModel
    {
        IUnityContainer _container;

        private void UpdateCommandAction()
        {
            // THESE TABLES ARE CREATED & REPOPULATED AT APPLICATION RUNTIME
            DependencyService.Get<ISqLite>().GetConnection().DropTable<Campus>();
            DependencyService.Get<ISqLite>().GetConnection().DropTable<Program>();
            DependencyService.Get<ISqLite>().GetConnection().DropTable<Country>();
            DependencyService.Get<ISqLite>().GetConnection().DropTable<Objective>();
        }

        #region LanguageProperties
        private string _selectedLanguageOne = "En";
        private string _selectedLanguageTwo = "Fr";
        private string _selectedLanguageThree = "Es";

        private bool _languageOneIsActive = true;
        private bool _languageTwoIsActive = true;
        private bool _languageThreeIsActive = true;
        public bool LanguageOneIsActive { get { return _languageOneIsActive; } set { _languageOneIsActive = value; } }
        public bool LanguageTwoIsActive { get { return _languageTwoIsActive; } set { _languageTwoIsActive = value; } }
        public bool LanguageThreeIsActive { get { return _languageThreeIsActive; } set { _languageThreeIsActive = value; } }

        public string SelectedLanguageOne
        {
            get { return _selectedLanguageOne; }
            set
            {
                if (string.IsNullOrEmpty(value)) return;
                if (string.Equals(_selectedLanguageOne, value)) return;
                if (string.Equals("-", value))
                {
                    LanguageOneIsActive = false;
                    return;
                }
                _selectedLanguageOne = IdentifyLanguageAbbreviation(value);
                LanguageOneIsActive = true;
            }
        }
        public string SelectedLanguageTwo
        {
            get { return _selectedLanguageTwo; }
            set
            {
                if (string.IsNullOrEmpty(value)) return;
                if (string.Equals(_selectedLanguageTwo, value)) return;
                if (string.Equals("-", value))
                {
                    LanguageTwoIsActive = false;
                    return;
                }
                _selectedLanguageTwo = IdentifyLanguageAbbreviation(value);
                LanguageTwoIsActive = true;
            }
        }
        public string SelectedLanguageThree
        {
            get { return _selectedLanguageThree; }
            set
            {
                if (string.IsNullOrEmpty(value)) return;
                if (string.Equals(_selectedLanguageThree, value)) return;
                if (string.Equals("-", value))
                {
                    LanguageThreeIsActive = false;
                    return;
                }
                _selectedLanguageThree = IdentifyLanguageAbbreviation(value);
                LanguageThreeIsActive = true;
            }
        }

        private string IdentifyLanguageAbbreviation(string value)
        {
            string selectedLang;
            switch (value)
            {
                case "English":
                    selectedLang = "En";
                    break;
                case "French":
                    selectedLang = "Fr";
                    break;
                case "Spanish":
                    selectedLang = "Es";
                    break;
                case "Catalan":
                    selectedLang = "Ca";
                    break;
                case "Indonesian":
                    selectedLang = "Id";
                    break;
                default:
                    selectedLang = "";
                    break;
            }
            return selectedLang;
        }
        private void RetriveLanguagePreferences()
        {
			SelectedLanguageOne = DependencyService.Get<IPreferenceRetriever>().GetLanguageOne();
			SelectedLanguageTwo = DependencyService.Get<IPreferenceRetriever>().GetLanguageTwo();
			SelectedLanguageThree = DependencyService.Get<IPreferenceRetriever>().GetLanguageThree();
        }
        #endregion
        #region Organization Properties
         public string CRMURL{ 
            get { return DependencyService.Get<IPreferenceRetriever>().GetCRMURL(); }
        }
        public IList<Organization> OrganizationOptions =  new GlobalCampuses().Organizations;
        public IList<isActiveCampus> CampusOptions { get; set; }
      
        public IList<Campus> ChosenCampuses()
        {
            IList<Campus> chosenCampuses = new List<Campus>();
            foreach (isActiveCampus campus in CampusOptions)
                if (campus.active)
                    chosenCampuses.Add(campus.campus);
            return chosenCampuses;
        }
        private Organization _organizationChosen = new Organization();
        public Organization OrganizationChosen
        {
            get { return _organizationChosen; }
            set
            {
                if (string.Equals(_organizationChosen, value) || (value == null)) 
                {
                    OrganizationIsChosen = false;
                    return; }

                OrganizationIsChosen = true;
                _organizationChosen = value;
                UpdateCampuses();
                OnPropertyChanged(nameof(OrganizationChosen));
            }
        }

        #endregion

        #region Event Properties
        private bool _eventModeActive = false;
        public bool EventModeActive { 
            get { return _eventModeActive; }
                set
                {
                    _eventModeActive = value;
                    OnPropertyChanged(nameof(EventModeActive));
                }
            }

		private User _directorChosen = new User();
		public User DirectorChosen
		{
			get { return _directorChosen; }
			set
			{
                if (string.Equals(_directorChosen, value) || (value == null))	
					return;


                DirectorNotSelectedError = false;
                _directorChosen = value;
                OnPropertyChanged(nameof(DirectorChosen));
			}
		}

		public IList<Event> EventOptions { get; set; }
        private async Task SetUpEventsAsync()
        {
            if (EventOptions != null) return;
            EventOptions = new List<Event>();
            EventOptions = await _container.Resolve<IEventDataService>().GetEventFromSQLiteByOrganizationAsync(OrganizationChosen, "en");
            OnPropertyChanged(nameof(EventOptions));
        }

		private Event _eventChosen = new Event();
		public Event EventChosen
		{
			get { return _eventChosen; }
			set
			{
				if (string.Equals(_eventChosen, value) || (value == null)) return;
                EventNotSelectedError = false;
                _eventChosen = value;
				OnPropertyChanged(nameof(EventChosen));
			}
		}

		public IList<User> DirectorOptions { get; set; }
		private async Task SetUpDirectorsAsync()
		{
			if (DirectorOptions != null) return;
			DirectorOptions = new List<User>();
            DirectorOptions = await _container.Resolve<IUserDataService>().GetUserFromSQLiteByOrganizationAsync(OrganizationChosen, "en");
			OnPropertyChanged(nameof(DirectorOptions));
		}

		#endregion
		#region UI Triggers
		
        private bool _showListView = false;
        public bool OrganizationIsChosen { 
            get { 
            return _showListView; } 
            set
            {
                _showListView = value;
                OnPropertyChanged(nameof(OrganizationIsChosen));
            }}

		private bool _showDirectorError = false;
		public bool DirectorNotSelectedError
		{
			get
			{
				return _showDirectorError;
			}
			set
			{
				_showDirectorError = value;
				OnPropertyChanged(nameof(DirectorNotSelectedError));
			}
		}


		private bool _showEventError = false;
		public bool EventNotSelectedError
		{
			get
			{
				return _showEventError;
			}
			set
			{
				_showEventError = value;
				OnPropertyChanged(nameof(EventNotSelectedError));
			}
		}

		private bool _showCampusError = false;
		public bool CampusNotSelectedError
		{
			get
			{
				return _showCampusError;
			}
			set
			{
				_showCampusError = value;
				OnPropertyChanged(nameof(CampusNotSelectedError));
			}
		}

		private bool _allowLanguageChange = false;
		public bool ModifyLang
		{
			get { return _allowLanguageChange; }
			set
			{
				_allowLanguageChange = value;
				OnPropertyChanged(nameof(ModifyLang));
			}
		}

		private bool _allowConfigChange = false;
		public bool ModifyConfig
		{
			get { return _allowConfigChange; }
			set
			{
				_allowConfigChange = value;
				OnPropertyChanged(nameof(ModifyConfig));
			}
		}



        private bool _awaitingData = false;
        public bool AwaitingData
        {
            get { return _awaitingData; }
            set { _awaitingData = value; OnPropertyChanged(nameof(AwaitingData)); }
        }

        #endregion

        public SettingsPageViewModel()
        {
            IDependencyInjectionRegister DI = new DependencyInjectionRegister();
            _container = DI.GetCurrentContainer();

            string organizationName = DependencyService.Get<IPreferenceRetriever>().GetOrganizationChosen();
            OrganizationChosen = OrganizationOptions.FirstOrDefault(o => o.Name.Contains(organizationName));

            IdentidyIfEventModeEnabled();

            if(EventModeActive)
            {
                SetUpEventsAsync();
                SetUpDirectorsAsync();
            }

            UpdateSteps();
            RetriveLanguagePreferences();
            SubscribeToEvents();
        }

        private void IdentidyIfEventModeEnabled()
        {
			EventModeActive =  DependencyService.Get<IPreferenceRetriever>().GetEventModeStatus();
            OnPropertyChanged(nameof(EventModeActive));
        }

        private async System.Threading.Tasks.Task UpdateCampuses()
        {
            CampusOptions = new List<isActiveCampus>();
            IList<Campus> CampusOptionsFromSQLite = new List<Campus>();

            if (CampusOptionsFromSQLite.Count() > 0) CampusOptionsFromSQLite.Clear();

            AwaitingData = true;
            CampusOptionsFromSQLite = await _container.Resolve<ICampusDataService>().GetCampusesFromSQLiteDBByOrganizationAsync(OrganizationChosen, "en");
            foreach (Campus campus in CampusOptionsFromSQLite)
                CampusOptions.Add(new isActiveCampus(campus, true));
            AwaitingData = false;
            OnPropertyChanged(nameof(CampusOptions));
        }

        private void UpdateSteps()
        {
            NavigationStateViewModel.PreviousStep = StepOrder.Settings;
            NavigationStateViewModel.CurrentStep = StepOrder.Settings;
            NavigationStateViewModel.NextStep = StepOrder.Language;
        }

        private void SubscribeToEvents()
        {
            MessagingCenter.Subscribe<NavigationViewModel>(this, "ForwardArrowPressed", (sender) =>
            {
                if (sender.NavigationStateViewModel.CurrentStep == StepOrder.Settings)
                    Validate();
            });
        }

        #region Validatation Logic       
        private void Validate()
        {
            if(!EventNotSelectedError && !DirectorNotSelectedError)
                ValidateForAtLeastOneCampusSelected();

            if (EventModeActive)
            {
                ValidateForEventAndDirector();
                IsValid = !EventNotSelectedError && !DirectorNotSelectedError && !CampusNotSelectedError;
            }

            else
                IsValid = !CampusNotSelectedError;
        }

        private void ValidateForEventAndDirector()
        {
            if (EventNotSelectedError || DirectorNotSelectedError || CampusNotSelectedError) return;

            if (DirectorChosen != null)
                if (string.IsNullOrEmpty(DirectorChosen.Name))
                    DirectorNotSelectedError = true;
            if (EventChosen != null)
                if (string.IsNullOrEmpty(EventChosen.Name))
                    EventNotSelectedError = true;
            }

        private void ValidateForAtLeastOneCampusSelected()
        {
            bool oneCampusSelected = false;
            foreach (isActiveCampus campus in CampusOptions)
                if (campus.active)
                    oneCampusSelected = true;

            CampusNotSelectedError = !oneCampusSelected;
        }
        #endregion
    }
}

public class isActiveCampus
{
    public bool active { get; set; }
    public Campus campus { get; set; }

    public isActiveCampus(Campus campus, bool active)
    {
        this.campus = campus;
        this.active = active;
    }
}