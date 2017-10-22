using System;
using System.Linq;
using System.Diagnostics;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;
using Plugin.Connectivity;
using Microsoft.Practices.Unity;
using MobileApps.Core.Helpers;
using MobileApps.Models.Models;
using MobileApps.DependencyInjection;
using MobileApps.Models.Contracts.Services;
using Xamarin.Forms;


namespace MobileApps.ViewModels
{
    public class EmailPromptViewModel : SubViewModel
    {
        #region Properties
        IUnityContainer _container;
		public ICommand AuthorizeCommand
		{
			get { return new Command((clickedEvent) => OAuthActionAsync(clickedEvent.ToString())); }
		}

        private bool _allowAlerts = true;
        public bool AllowAlerts
        {
            get { return _allowAlerts; }
            set
            {
                if (object.Equals(_allowAlerts, value)) return;
                _allowAlerts = value;
            }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }
        public Guid CRMID;
        public bool LeadMatch = false;
        private bool _pageLoaded = false;
        public bool PageLoaded { get { return _pageLoaded; } }
        private bool validationPassed = false;

		private bool _emptyOrNullValidation = true;
		public bool EmptyOrNullValidation
		{
			get { return _emptyOrNullValidation; }
			set
			{
				_emptyOrNullValidation = value;
				OnPropertyChanged(nameof(EmptyOrNullValidation));
			}
		}
        private bool _formatValidation = true;
        public bool FormatValidation
        {
            get { return _formatValidation; }
            set { _formatValidation = value; 
                OnPropertyChanged(nameof(FormatValidation));}
        }
		private bool _semesterValidation = true;
		public bool SemesterValidation
		{
			get { return _semesterValidation; }
			set
			{
				_formatValidation = value;
				OnPropertyChanged(nameof(SemesterValidation));
			}
		}

        public async Task EmailFilledAsync(object sender, EventArgs e)
        {
            IsValid = ValidateFormat();
            if (IsValid)
            {
                await CheckLeadExists();
				MainViewModel.Instance.NavVm.NavigateForwardCommand.Execute(sender);
            }
        }

        #endregion     
        public EmailPromptViewModel()
        {
            IDependencyInjectionRegister DI = new DependencyInjectionRegister();
            _container = DI.GetCurrentContainer();

            UpdateSteps(StepOrder.Name);
        }

        private void UpdateSteps(StepOrder NextStep)
        {
            NavigationStateViewModel.PreviousStep = StepOrder.Language;
            NavigationStateViewModel.CurrentStep = StepOrder.Email;
            NavigationStateViewModel.NextStep = NextStep;
        }

        private async Task CheckLeadExists()
        {
            AwaitingData = true;
            var isConnected = CrossConnectivity.Current.IsConnected;
			if (!isConnected)
			{
				LeadMatch = false; return;
			}

                List<InfoLead> leadMatchs = new List<InfoLead>();
            leadMatchs = await _container.Resolve<IInfoLeadDataService>().GetInfoLeadFromCRMByOrganizationAsync(
                MainViewModel.Instance.KioskApp.SettingsVm.OrganizationChosen, Email);
            // VALIDATION FOR NULL RESPONSES
            if (leadMatchs.Count == 0) { LeadMatch = false; return; }
            if (leadMatchs.FirstOrDefault() == null) return;
            if (leadMatchs.FirstOrDefault().CRMLeadID == new Guid("00000000-0000-0000-0000-000000000000")) return;

            try
            {
				NavigationStateViewModel.NextStep = StepOrder.Objective;
				MainViewModel.Instance.KioskApp.NameVm.FirstName = leadMatchs.FirstOrDefault().FirstName;
                MainViewModel.Instance.KioskApp.NameVm.LastName = leadMatchs.FirstOrDefault().LastName;
                LeadMatch = true;
                CRMID = leadMatchs.FirstOrDefault().CRMLeadID;

                IsValid = true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
				NavigationStateViewModel.NextStep = StepOrder.Name;
                try
                {
					LeadMatch = false;
                    Debug.WriteLine("Lead Not found In CRM");
                }
                catch(NullReferenceException ex)
                {
					Debug.WriteLine(ex.Message);
                    Debug.WriteLine("The Lead may have been erased from SQLite DB for " + Email);
                }        
            }
            AwaitingData = false;
        }

        private async Task OAuthActionAsync(string OAuthTypeChosen)
        {
            throw new Exception();
  //          await INavigation.Navigation.PushAsync(new GoogleProfileCsPage());
        }

        private bool ValidateFormat()
        {
            if (string.IsNullOrWhiteSpace(Email))
            {

                FormatValidation = true;
                EmptyOrNullValidation = false;
                return false; 
            }

                EmptyOrNullValidation = true;
                FormatValidation = true;

            if (ValidationLogic.IsEmailFormat(Email))
            {
                return true;           
            }

			FormatValidation = false;
            return false;
        } 
    }
}
