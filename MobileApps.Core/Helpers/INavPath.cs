namespace MobileApps.Core.Helpers
{
    public interface INavPath 
    {
        string currentStep { get; }
        string nextStep { get; set; }
        string previousStep { get; }

        string EvaluateNextStep();

        bool currentStepValidated { get; set; }
        void EvaluateValidity();
    }
}
