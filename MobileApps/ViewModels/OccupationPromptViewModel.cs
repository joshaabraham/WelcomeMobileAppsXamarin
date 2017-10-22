using System.Collections.Generic;
using Xamarin.Forms;

namespace MobileApps.ViewModels
{
    public class OccupationPromptViewModel : SubViewModel
    {
        private enum Occupation
        {
            Employed,
            Student,
            Other
        }
        public OccupationPromptViewModel()
        {
            UpdateSteps();
            SetUpOccupations();
            SubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            MessagingCenter.Subscribe<NavigationViewModel>(this, "ForwardArrowPressed", (sender) =>
            {
                if (sender.NavigationStateViewModel.CurrentStep == StepOrder.Occupation)
                    Validate();
            });
        }

        private void UpdateSteps()
        {
            NavigationStateViewModel.PreviousStep = StepOrder.Telephone;
            NavigationStateViewModel.CurrentStep = StepOrder.Occupation;
            NavigationStateViewModel.NextStep = StepOrder.Citizenship;
        }

        private void SetUpOccupations()
        {
            OccupationOptions = new List<string>();
            OccupationOptions.Add(Occupation.Employed.ToString());
            OccupationOptions.Add(Occupation.Student.ToString());
            OccupationOptions.Add(Occupation.Other.ToString());
        }

        public List<string> OccupationOptions { get; set; }

        private string _occupationChosen;
        public string OccupationChosen
        {
            get { return _occupationChosen; }
            set
            {
                if (string.Equals(_occupationChosen, value)) return;
                _occupationChosen = value;
                OnPropertyChanged(nameof(OccupationChosen));
                ChangeStep();
            }
        }

        private void ChangeStep()
        {
            if (string.Equals(OccupationChosen, Occupation.Student.ToString()))
            {
                NavigationStateViewModel.NextStep = StepOrder.Programs;
                return;
            }
            NavigationStateViewModel.NextStep = StepOrder.Citizenship;
        }

        private void Validate()
        {
            ValidateForEmpty();
            IsValid = string.IsNullOrWhiteSpace(ValidationMessage);
        }
        private void ValidateForEmpty()
        {
            if (!string.IsNullOrWhiteSpace(OccupationChosen))
            {
                ValidationMessage = string.Empty;
                return;
            }
            ValidationMessage = "* Please Select Your Occupation";
        }
    }
}
