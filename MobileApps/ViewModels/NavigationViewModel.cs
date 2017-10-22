using System;
using System.Linq;
using System.Windows.Input;
using System.Threading.Tasks;
using MobileApps.DAL;
using MobileApps.Helpers;
using MobileApps.Views.Navigation;
using Xamarin.Forms;
using System.ComponentModel;
using System.Diagnostics;

namespace MobileApps.ViewModels
{
    internal class NavigationViewModel : INotifyPropertyChanged
    {
		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
		}
        
        #region Properties
        bool _showReturnIcon = false;
        public bool ShowReturnIcon { 
            get { return _showReturnIcon; } 
            set { _showReturnIcon = value; OnPropertyChanged(nameof(ShowReturnIcon));}
        }
   
        private NavigationStateViewModel _navigationStateViewModel;
        public NavigationStateViewModel NavigationStateViewModel
        {
            get { return _navigationStateViewModel; }
            set
            {
                if (_navigationStateViewModel == value) return;
                _navigationStateViewModel = value;
            }
        }

        public ICommand SessionTimeoutCommand
        {
            get { return new Command(() => SessionTimeoutAction()); }
        }

        public ICommand NavigateForwardCommand
        {
            get { return new Command(() => NavigateForwardAction()); }
        }
	
        #endregion

        public NavigationViewModel()
        {
           // SubscribeToEvents();
        }

        /*
        private void SubscribeToEvents()
        {
            MessagingCenter.Subscribe<EmailPromptViewModel>(this, "LeadMatchedPositiveID", (sender) =>
			{
                Device.BeginInvokeOnMainThread(() => LeadMatchedPositiveIDAction());
            });
        }
        */

        private void LeadMatchedPositiveIDAction()
        {
            Debug.WriteLine("Lead has been found in CRM. Redirecting to Objectives Page");
			try
			{
          		_navigationStateViewModel = MainViewModel.Instance.KioskApp.SubViewModels.FirstOrDefault(
                    vm => vm.NavigationStateViewModel.NextStep == StepOrder.Objective).NavigationStateViewModel;
				NavigateForwardAction();
			}
			catch
			{
				Debug.WriteLine("The lead may have been removed from database");
			}
        }

        private void InitState()
        {
            // THIS SHOULD METHOD SHOULD BE REMOVED AS IT IS ONLY A TEMPORARY FIX
            if (NavigationStateViewModel != null) return;
            NavigationStateViewModel = MainViewModel.Instance.KioskApp.SubViewModels.FirstOrDefault(
                vm => vm.NavigationStateViewModel.CurrentStep == StepOrder.Settings).NavigationStateViewModel;
        }

        private async void NavigateForwardAction()
        {
            InitState();  // THIS WILL BE CHANGED LATER - BAD PRACTICE 

            MessagingCenter.Send(this, "ForwardArrowPressed");
            if (!_navigationStateViewModel.SubViewModel.IsValid) return;

			var nextSubViewModel = MainViewModel.Instance.KioskApp.SubViewModels.FirstOrDefault(
                vm => vm.NavigationStateViewModel.CurrentStep == _navigationStateViewModel.NextStep);
			if ((nextSubViewModel == null)) return;
			_navigationStateViewModel = nextSubViewModel.NavigationStateViewModel;

            // SKIP CAMPUS PROMPT PAGE IF ONLY ONE CAMPUS OPTION
            if (NavigationStateViewModel.CurrentStep == StepOrder.Campus && 
                MainViewModel.Instance.KioskApp.SettingsVm.ChosenCampuses().Count == 1)
            {
                MainViewModel.Instance.KioskApp.CampusVm.CampusChosen =
                       MainViewModel.Instance.KioskApp.SettingsVm.ChosenCampuses().FirstOrDefault();
                return;
            }
            
            await Task.Run(() => UpdateNecessaryDataInViews());
            Navigation.NavigateToNextPage(_navigationStateViewModel);
			ShowReturnIcon = EvaluateReturnIconVisible();

            if (NavigationStateViewModel.CurrentStep != StepOrder.Acknowledgement) return;
            NavigationProcessTerminated();
        }

        private void SessionTimeoutAction()
        {
            MainViewModel.Instance.KioskApp.ClearVMData();
            _navigationStateViewModel = MainViewModel.Instance.KioskApp.SubViewModels.FirstOrDefault(
                vm => vm.NavigationStateViewModel.NextStep == StepOrder.Language).NavigationStateViewModel;
            NavigateForwardAction();	
        }

        private bool EvaluateReturnIconVisible()
        {
            if (NavigationStateViewModel.CurrentStep == StepOrder.Settings ||
                NavigationStateViewModel.CurrentStep == StepOrder.Language ||
                NavigationStateViewModel.CurrentStep == StepOrder.Acknowledgement) 
                return false;

            return true;
        }

        private void UpdateNecessaryDataInViews()
        {
			if (NavigationStateViewModel.CurrentStep == StepOrder.Email) 
                MessagingCenter.Send(this, "EmailPageLoaded");
			if (NavigationStateViewModel.CurrentStep == StepOrder.Name) 
                MessagingCenter.Send(this, "NamePageLoaded");
			if (NavigationStateViewModel.CurrentStep == StepOrder.Telephone) 
                MessagingCenter.Send(this, "TelephonePageLoaded");
            if (NavigationStateViewModel.CurrentStep == StepOrder.Campus) 
                MessagingCenter.Send(this, "CampusPageLoaded");
            if (NavigationStateViewModel.CurrentStep == StepOrder.Programs) 
                MessagingCenter.Send(this, "ProgramsPageLoaded");
            if (NavigationStateViewModel.CurrentStep == StepOrder.Country) 
                MessagingCenter.Send(this, "CountriesPageLoaded");
            if (NavigationStateViewModel.CurrentStep == StepOrder.Objective) 
                MessagingCenter.Send(this, "ObjectivesPageLoaded");
        }

        private void NavigationProcessTerminated()
        {
            MainViewModel.Instance.KioskApp.SubmitLead();
            NavigationStateViewModel = MainViewModel.Instance.KioskApp.SubViewModels.FirstOrDefault(
                vm => vm.NavigationStateViewModel.NextStep == StepOrder.Language).NavigationStateViewModel;
            Device.StartTimer(TimeSpan.FromSeconds(3), () =>
            {
                Navigation.NavigateToPageByViewNameExplicitly("LanguagePromptView");
                MainViewModel.Instance.KioskApp.EmailVm.Email = "";
                return false;
            });
        }

        private void UpdateBackgroundImage()
        {
            var primaryPage = App.Current.MainPage;
            if (primaryPage.Navigation != null)
            {
                MasterPage Instance = (MasterPage)primaryPage.Navigation.NavigationStack.First();
                switch (DependencyService.Get<IPreferenceRetriever>().GetLogoChosen())
                {
                    case "Montreal Logo":
                        Instance.UpdateImage("WelcomeBackgroundImageMontreal");
                        break;
                    case "Vancouver Logo":
                        Instance.UpdateImage("WelcomeBackgroundImageVancouver");
                        break;
                    case "International Logo":
                        Instance.UpdateImage("WelcomeBackgroundImageInternational");
                        break;
                    case "Academy of Design Logo":
                        Instance.UpdateImage("WelcomeBackgroundImageDesign");
                        break;
                    default:
                        Instance.UpdateImage("WelcomeBackgroundImageMontreal");
                        break;
                }
            }
        }
    }
}