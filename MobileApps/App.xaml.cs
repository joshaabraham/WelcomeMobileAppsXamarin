using MobileApps.Views.Navigation;
using Xamarin.Forms;

namespace MobileApps
{
    //[XamlCompilation (XamlCompilationOptions.Skip)]
    public partial class App : Application
    {
        public static MasterDetailPage MasterDetailPage;


        public App()
        {
            InitializeComponent();
            var appInitializer = new AppInitializer();
            appInitializer.Initialize();
        }

        public static NavigationPage GetMainNavigationPage()
        {
            NavigationPage mainNavigationPageInstance = new NavigationPage(new MasterPage());
            mainNavigationPageInstance.SetValue(NavigationPage.BarBackgroundColorProperty, Color.White);
            mainNavigationPageInstance.SetValue(NavigationPage.BarTextColorProperty, Color.DodgerBlue);
            return mainNavigationPageInstance;
        }
        protected override void OnStart()
        {
            MainPage = GetMainNavigationPage();
        }
        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
