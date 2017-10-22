using System.Collections.Generic;
using Microsoft.Practices.Unity;
using MobileApps.Models.Models;
using MobileApps.DependencyInjection;
using MobileApps.Models.Contracts.Services;
using Xamarin.Forms;

namespace MobileApps.ViewModels
{
    public class ObjectivePromptViewModel : SubViewModel
    {
        #region Properties
        IUnityContainer _container;
        private bool _awaitingData = false;
        public bool AwaitingData
        {
            get { return _awaitingData; }
            set { _awaitingData = value; OnPropertyChanged(nameof(AwaitingData)); }
        }

        public IList<Objective> ObjectiveOptions { get; set; }
        private Objective _objectiveChosen;
        public Objective ObjectiveChosen
        {
            get { return _objectiveChosen; }
            set
            {
                if (string.Equals(_objectiveChosen, value)) return;
                _objectiveChosen = value;
                OnPropertyChanged(nameof(ObjectiveChosen));
                Validate();
            }
        }
        #endregion

        public ObjectivePromptViewModel()
        {
            IDependencyInjectionRegister DI = new DependencyInjectionRegister();
            _container = DI.GetCurrentContainer();

            UpdateSteps();
            SubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            MessagingCenter.Subscribe<NavigationViewModel>(this, "ObjectivesPageLoaded", async (sender) =>
            {
                ObjectiveOptions = new List<Objective>();
                OnPropertyChanged(nameof(ObjectiveOptions));
                AwaitingData = true;
                ObjectiveOptions = await _container.Resolve<IObjectiveDataService>().GetObjectivesFromSQLiteByOrganizationAsync(
                    MainViewModel.Instance.KioskApp.SettingsVm.OrganizationChosen.Id,
                    MainViewModel.Instance.KioskApp.LanguageVm.SelectedLanguage.ToLower());
                AwaitingData = false;
                OnPropertyChanged(nameof(ObjectiveOptions));
            });
        }

        private void UpdateSteps()
        {
            NavigationStateViewModel.PreviousStep = StepOrder.Country;
            NavigationStateViewModel.CurrentStep = StepOrder.Objective;
            NavigationStateViewModel.NextStep = StepOrder.Acknowledgement;
        }

        #region Validation Logic
        private void Validate()
        {
            if (ValidateForEmpty())
            {
                
                IsValid = true;
                MainViewModel.Instance.NavVm.NavigateForwardCommand.Execute(this);
            }
        }
        private bool ValidateForEmpty()
        {
            if (ObjectiveChosen != null)
                return true;
            return false;
        }
        #endregion
    }
}
