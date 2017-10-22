using MobileApps.Core.Helpers;
using Xamarin.Forms;
using System;

namespace MobileApps.ViewModels
{
    public class TelephonePromptViewModel : SubViewModel
    {
        #region Properties
        private string _telephoneHome { get; set; }
        private string _telephoneMobile { get; set; }

        public string TelephoneHome
        {
            get { return _telephoneHome; }
            set
            {
                if (string.Equals(_telephoneHome, value)) return;
                _telephoneHome = value;
                OnPropertyChanged(nameof(TelephoneHome));
            }
        }
        public string TelephoneMobile
        {
            get { return _telephoneMobile; }
            set
            {
                if (string.Equals(_telephoneMobile, value)) return;
                _telephoneMobile = value;
                OnPropertyChanged(nameof(TelephoneMobile));
            }
        }
        #endregion

        public TelephonePromptViewModel()
        {
            SubscribeToEvents();
            UpdateSteps();
        }

        private void SubscribeToEvents()
        {
        }

        private void UpdateSteps()
        {
            NavigationStateViewModel.PreviousStep = StepOrder.Name;
            NavigationStateViewModel.CurrentStep = StepOrder.Telephone;
            NavigationStateViewModel.NextStep = StepOrder.Campus;
        }

        #region Validation Logic
        public void TelephoneFilled(object sender, EventArgs e)
        {
            if (ValidateForOneRequired() && ValidateForTelephone())  
            {
                IsValid = true;
                MainViewModel.Instance.NavVm.NavigateForwardCommand.Execute(sender);
            }
            IsValid = false;
        }

        private bool ValidateForTelephone()
        {
            if (!string.IsNullOrEmpty(TelephoneHome))
                if (ValidationLogic.IsPhoneFormat(TelephoneHome))
                    return true;

            if (!string.IsNullOrEmpty(TelephoneMobile))
                if (ValidationLogic.IsPhoneFormat(TelephoneMobile))
                    return true;
            
            return false;
        }   
    
        private bool ValidateForOneRequired()
        {
            if (!string.IsNullOrEmpty(TelephoneHome) || (!string.IsNullOrEmpty(TelephoneMobile)))
                return true;
            return false;
        }
        #endregion
    }
}
