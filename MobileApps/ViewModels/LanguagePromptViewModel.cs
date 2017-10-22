using System.Windows.Input;
using Xamarin.Forms;

namespace MobileApps.ViewModels
{
    public class LanguagePromptViewModel : SubViewModel
    {
        internal string _selectedLanguage;
        public string SelectedLanguage { get { return _selectedLanguage; } }
        public ICommand SelectLanguageCommand
        {
            get { return new Command((clickedEvent) => SelectLanguageAction(clickedEvent.ToString())); }
        }

        private void SelectLanguageAction(string Language)
        {
            _selectedLanguage = Language;
            MainViewModel.Instance.NavVm.NavigateForwardCommand.Execute(this);
        }

        public LanguagePromptViewModel()
        {
            UpdateSteps();
            SubscribeToEvents();
        }
        private void SubscribeToEvents()
        {
            MessagingCenter.Subscribe<NavigationViewModel>(this, "ForwardArrowPressed", (sender) =>
            {
                if (sender.NavigationStateViewModel.CurrentStep == StepOrder.Language)
                {
                    IsValid = true;
                        
                }
            });
        }
        private void UpdateSteps()
        {
            NavigationStateViewModel.PreviousStep = StepOrder.Settings;
            NavigationStateViewModel.CurrentStep = StepOrder.Language;
            NavigationStateViewModel.NextStep = StepOrder.Email;
        }
    }
}
