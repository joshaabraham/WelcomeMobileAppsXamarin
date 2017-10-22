namespace MobileApps.ViewModels
{
    public class AcknowledgementViewModel : SubViewModel
    {
        public AcknowledgementViewModel()
        {
            UpdateSteps();
        }

        private void UpdateSteps()
        {
            NavigationStateViewModel.CurrentStep = StepOrder.Acknowledgement;
            NavigationStateViewModel.NextStep = StepOrder.Language;
        }
    }
}
