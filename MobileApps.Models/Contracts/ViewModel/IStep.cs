namespace MobileApps.Models.Contracts.ViewModel
{
    public interface IStep
    {
        string NextStep { get; set; }
        string CurrentStep { get; set; }
        string PreviousStep { get; set; }

        void EvaluateNextStep();

    }
}
