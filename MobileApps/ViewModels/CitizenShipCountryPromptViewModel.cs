using System;
using System.Linq;
using System.Collections.Generic;
using Xamarin.Forms;
using Microsoft.Practices.Unity;
using MobileApps.Core.Helpers;
using MobileApps.Models.Models;
using MobileApps.DependencyInjection;
using MobileApps.Models.Contracts.Services;

namespace MobileApps.ViewModels
{
    public class CitizenShipCountryPromptViewModel : SubViewModel
    {
        #region Properties
        IUnityContainer _container;
        public IList<Country> CountryOptions { get; set; }
        private IList<Country> _allCountryOptions;
        private Country _countryChosen;
        public Country CountryChosen
        {
            get { return _countryChosen; }
            set
            {
                if (string.Equals(_countryChosen, value)) return;
                _countryChosen = value;
                OnPropertyChanged(nameof(CountryChosen));
                Validate();
            }
        }

        private string _countryFilter;
        public string CountryFilter
        {
            get { return _countryFilter; }
            set
            {
                if (string.Equals(_countryFilter, value)) return;
                if (string.IsNullOrWhiteSpace(value)) value = "";
                _countryFilter = value;
                UpdateOptions();
            }
        }

        #endregion
        public CitizenShipCountryPromptViewModel()
        {
            UpdateSteps();
            SubscribeToEvents();

            IDependencyInjectionRegister DI = new DependencyInjectionRegister();
            _container = DI.GetCurrentContainer();
        }

        private void UpdateSteps()
        {
            NavigationStateViewModel.PreviousStep = StepOrder.Programs;
            NavigationStateViewModel.CurrentStep = StepOrder.Country;
            NavigationStateViewModel.NextStep = StepOrder.Objective;
        }

        private void SubscribeToEvents()
        {
            MessagingCenter.Subscribe<NavigationViewModel>(this, "CountriesPageLoaded", (sender) =>
            {
				if (MainViewModel.Instance.KioskApp.SettingsVm.EventModeActive)
					NavigationStateViewModel.NextStep = StepOrder.Acknowledgement;
                SetUpCountry();
            });
        }

        private async void SetUpCountry()
        {
            _countryChosen = null;
            OnPropertyChanged(nameof(CountryChosen));

            if (_allCountryOptions != null) return;

            AwaitingData = true;
            _allCountryOptions = new List<Country>();
            _allCountryOptions = await _container.Resolve<INationalityDataService>().GetCountriesFromSQLiteAsync();

            if (_allCountryOptions.Count == 0)
            {
                IsValid = false;
                 return;
            }

            CountryOptions = _allCountryOptions;
            OnPropertyChanged(nameof(CountryOptions));
            AwaitingData = false;
        }

        private void UpdateOptions()
        {
            List<Country> theFilteredCountries = new List<Country>();

            foreach (Country curCountry in _allCountryOptions)
            {
                if (curCountry.Name.Contains(CountryFilter, StringComparison.OrdinalIgnoreCase))
                    theFilteredCountries.Add(curCountry);
            }

            CountryOptions = theFilteredCountries;
            OnPropertyChanged(nameof(CountryOptions));
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
            if (CountryChosen != null)
                return true;
            return false;
        }
        #endregion
    }
}
