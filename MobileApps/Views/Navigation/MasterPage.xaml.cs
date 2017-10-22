using MobileApps.Views.Navigation.SubViews;
using System.Linq;
using System;
using MobileApps.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MobileApps.DAL;

namespace MobileApps.Views.Navigation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterPage : ContentPage
    {
        public static MasterPage Instance;
        MainViewModel vm = new MainViewModel();

        public MasterPage()
        {
            InitializeComponent();
            Instance = this;         
            BindingContext = vm;
            BackgroundImage.SetDynamicResource(StyleProperty, DependencyService.Get<IPreferenceRetriever>().GetLogoChosen());
            HomeIcon.Text = GrialShapesFont.Close;

			Display("SettingsView", false);
		 }

        public void Display(string className, bool arrowsVisible)
        {
            Type type = Type.GetType("MobileApps.Views.Navigation.SubViews." + className);
            if (type == null) return;
            View newContent = (View)Activator.CreateInstance(type);

            DynamicView.Children.Clear();
            DynamicView.Children.Add(newContent);
        }

        public void UpdateView(View newView)
		{
			DynamicView.Children.Clear();
			DynamicView.Children.Add(newView);
		}

        public void WelcomeBackExistingStudent(View newView)
        {
            DynamicView.Children.Clear();
            DynamicView.Children.Add(newView);
            WelcomeStudentBack();
        }

        private void WelcomeStudentBack()
        {
            string firstName = vm.KioskApp.NameVm.FirstName;

			switch(vm.KioskApp.LanguageVm.SelectedLanguage)
            {								
                case "En":
					DisplayAlert("Welcome Back " + firstName, "Tell us why you are here", "Continue");
                    break;
				case "Fr":
					DisplayAlert("Quel plaisir de vous revoir " + firstName, "Dites-nous la raison de votre présence", "Continuer");
                    break;
				case "Es":
					DisplayAlert("Bienvenido/a " + firstName, "Motivo de tu visita", "Continue");
					break;
				case "Id":
					DisplayAlert("Selamat datang kembali " + firstName, "apa maksud kedatangan anda disini", "Lanjutkan");
					break;
				case "Ca":
					DisplayAlert("Benvingut/da " + firstName, "Motiu de la teva visita", "Continue");
					break;
            }
        }

        public void UpdateImage(string ImageKeyPath)
        {
            BackgroundImage.SetDynamicResource(StyleProperty, ImageKeyPath);
        }
    }
}