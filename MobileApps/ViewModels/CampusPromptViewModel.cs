using System;
using System.Collections.Generic;
using MobileApps.Helpers;
using MobileApps.Models.Models;
using Xamarin.Forms;

namespace MobileApps.ViewModels
{
    public class CampusPromptViewModel : SubViewModel
    {
        #region Properties
        public Guid CampusId { get; set; }
        private string _campusFilter;
        public string CampusFilter
        {
            get { return _campusFilter; }
            set
            {
                if (string.Equals(_campusFilter, value)) return;
                if (string.IsNullOrWhiteSpace(value)) value = "";
                _campusFilter = value;
                updateCampuses();
            }
        }
        public string Campus { get; set; }
        private IList<Campus> _AllCampusOptions;
        public IList<Campus> CampusOptions { get; set; }
        private Campus _campusChosen;
        public Campus CampusChosen
        {
            get { return _campusChosen; }
            set
            {
                if (object.Equals(_campusChosen, value)) return;
                _campusChosen = value;
                OnPropertyChanged(nameof(CampusChosen));
                Validate();
            }
        }
        #endregion

        public CampusPromptViewModel()
        {
            UpdateSteps();
            SubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            MessagingCenter.Subscribe<NavigationViewModel>(this, "CampusPageLoaded", (sender) =>
            {
                UpdateSteps();
                SetUpCampuss();
            });
        }

        private void UpdateSteps()
        {
            NavigationStateViewModel.PreviousStep = StepOrder.Telephone;
            NavigationStateViewModel.CurrentStep = StepOrder.Campus;
            NavigationStateViewModel.NextStep = StepOrder.Programs;
        }
        private void SetUpCampuss()
        {
            if (CampusOptions != null) return;

            _AllCampusOptions = new List<Campus>();
            _AllCampusOptions = MainViewModel.Instance.KioskApp.SettingsVm.ChosenCampuses();

            CampusOptions = _AllCampusOptions;
            OnPropertyChanged(nameof(CampusOptions));
        }
        private void updateCampuses()
        {
            AwaitingData = true;
            List<Campus> theFilteredCampuses = new List<Campus>();

            foreach (Campus curCamp in _AllCampusOptions)
            {
                if (curCamp.Name.Contains(CampusFilter))
                    theFilteredCampuses.Add(curCamp);
            }

            CampusOptions = theFilteredCampuses;
            OnPropertyChanged(nameof(CampusOptions));
            AwaitingData = false;
        }

        #region Validation Logic
        private void Validate()
        {
            
            IsValid = ValidateForEmpty();
            MainViewModel.Instance.NavVm.NavigateForwardCommand.Execute(this);
        }

        private bool ValidateForEmpty()
        {
            if (CampusChosen != null)
                return true;
            return false;
        }      
        #endregion
    }
}
