using MobileApps.Core.Helpers;
using Xamarin.Forms;
using System;

namespace MobileApps.ViewModels
{
    public class NamePromptViewModel : SubViewModel
    {
        #region Properties
        private string _firstName = "";
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (MainViewModel.Instance.KioskApp.EmailVm.LeadMatch) return;
                if (string.Equals(_firstName, value)) return;
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }
        private string _lastName = "";
        public string LastName
        {
            get { return _lastName; }
            set
            {
				if (MainViewModel.Instance.KioskApp.EmailVm.LeadMatch) return;
                if (string.Equals(_lastName, value)) return;
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }
        #endregion
        public NamePromptViewModel()
        {
            SubscribeToEvents();
            UpdateSteps();
        }

        private void SubscribeToEvents()
        {
        }

        private void UpdateSteps()
        {
            NavigationStateViewModel.PreviousStep = StepOrder.Email;
            NavigationStateViewModel.CurrentStep = StepOrder.Name;
            NavigationStateViewModel.NextStep = StepOrder.Telephone;
        }

		public void NameFilled(object sender, EventArgs e)
		{
            
            IsValid = ValidateForAlphaCharacters();
            MainViewModel.Instance.NavVm.NavigateForwardCommand.Execute(sender);
		}

		private bool _nameEmpty = false;
		private bool _nameBadFormat = false;

        public bool NameEmpty { 
            get 
            {
                return _nameEmpty;
            }
            set { 
                _nameEmpty = value; 
                OnPropertyChanged(nameof(NameEmpty));
            }
        }
		public bool NameBadFormat
		{
			get {
                return _nameBadFormat;
            }
			set
			{
				_nameBadFormat = value;
				OnPropertyChanged(nameof(NameBadFormat));
			}
		}

         private bool ValidateForAlphaCharacters()
        {
            _nameEmpty = false;
            _nameBadFormat = false;

            if (string.IsNullOrEmpty(FirstName)
                || (string.IsNullOrEmpty(LastName)))
            {
                NameEmpty = true;
                return false;
            }

            if (ValidationLogic.IsAlphabeticalOnly(FirstName)
                 && (ValidationLogic.IsAlphabeticalOnly(LastName))) 
                return true;

            NameBadFormat = true; 
            return false;
        }
    }
}
