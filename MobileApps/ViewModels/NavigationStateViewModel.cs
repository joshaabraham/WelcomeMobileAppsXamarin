using MobileApps.ViewModels;

namespace MobileApps.ViewModels
{
    public class NavigationStateViewModel : ViewModelBase
    {
        public NavigationStateViewModel()
        {
            PreviousStep = StepOrder.Settings;
            CurrentStep = StepOrder.Settings;
            NextStep = StepOrder.Completed;
        }

        public StepOrder PreviousStep { get; set; }
        public StepOrder CurrentStep { get; set; }
        public StepOrder NextStep { get; set; }        
        public SubViewModel SubViewModel { get; set; }
    }
}
