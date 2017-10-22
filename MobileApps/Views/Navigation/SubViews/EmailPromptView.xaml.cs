using MobileApps.ViewModels;
using System;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using GoogleLogin.Views;

namespace MobileApps.Views.Navigation.SubViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmailPromptView : ContentView
    {
        public EmailPromptView()
        {
            InitializeComponent();          
        }

        // BAD PRACTICE , WE MUST TRIGGER VM DIRECTLY
		public void EmailFilled(object sender, EventArgs e)
		{
            MainViewModel.Instance.KioskApp.EmailVm.EmailFilledAsync(sender,e);	
        }
    }
}