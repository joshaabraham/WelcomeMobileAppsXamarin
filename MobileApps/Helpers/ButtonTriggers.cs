using MobileApps.ViewModels;
using Xamarin.Forms;

namespace MobileApps.Helpers
{
    class ButtonTriggers : TriggerAction<Button>
    {
        protected override void Invoke(Button sender)
        {
            MainViewModel.Instance.KioskApp.LanguageVm._selectedLanguage = IdentifyButton(sender.ClassId);
        }
        private string IdentifyButton(string buttonPressed)
        {
            string languageSelected;
            switch (buttonPressed)
            {
                case "ButtonOne":
                    languageSelected = MainViewModel.Instance.KioskApp.SettingsVm.SelectedLanguageOne;
                    break;
                case "ButtonTwo":
                    languageSelected = MainViewModel.Instance.KioskApp.SettingsVm.SelectedLanguageTwo;
                    break;
                case "ButtonThree":
                    languageSelected = MainViewModel.Instance.KioskApp.SettingsVm.SelectedLanguageThree;
                    break;
                default:
                    languageSelected = "";
                    break;
            }
            return languageSelected;
        }
    }
}
