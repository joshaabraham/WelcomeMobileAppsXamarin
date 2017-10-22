using MobileApps.Views.Navigation;
using System.Linq;
using Xamarin.Forms;

namespace MobileApps.Helpers
{
    class PickerTriggers : TriggerAction<Picker>
    {
        protected override void Invoke(Picker sender)
        {
            UpdateBackgroundImage(sender.SelectedItem.ToString());
        }

        private void UpdateBackgroundImage(string BackgroundImageKey)
        {
            var primaryPage = App.Current.MainPage;
            if (primaryPage.Navigation != null)
            {
                MasterPage Instance = (MasterPage)primaryPage.Navigation.NavigationStack.First();
                switch (BackgroundImageKey)
                {
                    case "Lasalle College Montreal":
                        Instance.UpdateImage("WelcomeBackgroundImageMontreal");
                        break;
                    case "Lasalle College Vancouver":
                        Instance.UpdateImage("WelcomeBackgroundImageVancouver");
                        break;
                    case "Lasalle College International":
                        Instance.UpdateImage("WelcomeBackgroundImageInternational");
                        break;
                    case "Academy of Design":
                        Instance.UpdateImage("WelcomeBackgroundImageDesign");
                        break;
                    default:
                        Instance.UpdateImage("WelcomeBackgroundImageMontreal");
                        break;
                }
            }
        }
    }
}
