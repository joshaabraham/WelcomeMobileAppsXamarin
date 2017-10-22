using System.Collections.Generic;
using Xamarin.Forms;
using MobileApps.Models.Models;
using MobileApps.DependencyInjection;
using System.Linq;
using Microsoft.Practices.Unity;
using System;
using MobileApps.Models.Contracts.Services;

namespace MobileApps.ViewModels
{
    public class ProgramsPromptViewModel : SubViewModel
    {

        #region Properties
        IUnityContainer _container;

        #region Categorization Logic
        private IList<String> _programCategories = new List<String>();
        public IList<String> ProgramCategories { get { return _programCategories; } }

        private bool _showCategorizer = false;
        public bool ShowCategorizer
        {
            get
            {
                return _showCategorizer;
            }
            set
            {
                _showCategorizer = value;
                OnPropertyChanged(nameof(ShowCategorizer));
            }
        }

        private void UpdateCategories()
        {
            List<string> programTypes = new List<string>(){
                "DEC",
                "Diploma",
                "AEC",
                "DEP",
                "ELearning",
                "Certificate",
                "Bachelor",
                "Advanced Diploma" };

            _programCategories.Clear();
            _programCategories.Add("All Programs");
            foreach (string type in programTypes)
            {
                if (_allProgramOptions.Any(p => p.Name.EndsWith("[" + type + "]", StringComparison.OrdinalIgnoreCase)))
                    _programCategories.Add(type);
            }


            CategoryChosen = null;

            if (_programCategories.Count() <= 2)
            {
                ShowCategorizer = false;
                ProgramOptions = _allProgramOptions;
                OnPropertyChanged(nameof(ProgramOptions));
                CategoryChosen = "All Programs";
                return;
            }

            OnPropertyChanged(nameof(ProgramCategories));
            ShowCategorizer = true;
        }

        private IList<Program> getProgramsByCategoriesAsync(string selectedCategoryKey)
        {
            List<Program> theSelectedPrograms = new List<Program>();
            string key = "[" + selectedCategoryKey + "]";
            return _allProgramOptions.Where(p => p.Name.Contains(key)).ToList();
        }

        #endregion
        public IList<Program> ProgramOptions { get; set; }
        private IList<Program> _allProgramOptions = new List<Program>();
        private Program _programChosen;
        public Program ProgramChosen
        {
            get { return _programChosen; }
            set
            {
                if (object.Equals(_programChosen, value)) return;
                if (value == null) return;
                _programChosen = value;
                OnPropertyChanged(nameof(ProgramChosen));
                Validate();
            }
        }
      
        private string _categoryChosen;
        public string CategoryChosen
        {
            get { return _categoryChosen; }
            set
            {
                if (string.Equals(_categoryChosen, value)) return;
                _categoryChosen = value;
                if (string.IsNullOrEmpty(CategoryChosen)) return;
                ProgramOptions = updateOptions();
                AwaitingData = false;
                OnPropertyChanged(nameof(ProgramOptions));
                OnPropertyChanged(nameof(CategoryChosen));
            }
        }
        #endregion

        private IList<Program> updateOptions()
        {
            AwaitingData = true;

            if (CategoryChosen == "All Programs" || string.IsNullOrEmpty(CategoryChosen))
                return _allProgramOptions;
            else
                return _allProgramOptions.Where(p => p.Name.EndsWith("[" + CategoryChosen + "]",StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public ProgramsPromptViewModel()
        {
            IDependencyInjectionRegister DI = new DependencyInjectionRegister();
            _container = DI.GetCurrentContainer();

            UpdateSteps();
            SubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            MessagingCenter.Subscribe<NavigationViewModel>(this, "ProgramsPageLoaded", (sender) =>
            {
                try
                {
                    SetUpPrograms();
                }
                catch
                {
                    
                }
            });
        }

        private void UpdateSteps()
        {
			NavigationStateViewModel.PreviousStep = StepOrder.Campus;
            NavigationStateViewModel.CurrentStep = StepOrder.Programs;
            NavigationStateViewModel.NextStep = StepOrder.Country;
        }


        private async void SetUpPrograms()
        {
            if (ProgramOptions != null)
                ProgramOptions.Clear();
    
            _allProgramOptions.Clear();
            _programCategories.Clear();
            ShowCategorizer = false;
			OnPropertyChanged(nameof(ProgramOptions));
			OnPropertyChanged(nameof(ShowCategorizer));

            AwaitingData = true;
            _allProgramOptions = await _container.Resolve<IProgramsDataService>().GetProgramsFromSQLiteByOrganizationAsync(
                    MainViewModel.Instance.KioskApp.SettingsVm.OrganizationChosen,
                    MainViewModel.Instance.KioskApp.CampusVm.CampusChosen,
                    MainViewModel.Instance.KioskApp.LanguageVm.SelectedLanguage.ToLower());
            AwaitingData = false;

            if (_allProgramOptions.Count == 0)
            {
                IsValid = false;
                return;
            }
      
            ProgramChosen = null;
            CategoryChosen = String.Empty;

            AwaitingData = false;

            UpdateCategories();
        }

        #region Validation Logic
        private void Validate()
        {
            
            IsValid = ValidateForEmpty();
            MainViewModel.Instance.NavVm.NavigateForwardCommand.Execute(this);
        }

        private bool ValidateForEmpty()
        {
            if (ProgramChosen != null)
                return true;
            return false;
        }
        #endregion
    }
}
