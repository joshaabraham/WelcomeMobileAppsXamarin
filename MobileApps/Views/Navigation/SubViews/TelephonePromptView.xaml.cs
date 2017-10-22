using System;
using MobileApps.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApps.Views.Navigation.SubViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TelephonePromptView : ContentView
    {
        public TelephonePromptView()
        {
            InitializeComponent();
        }
		// BAD PRACTICE , WE MUST TRIGGER VM DIRECTLY
		public void TelephoneFilled(object sender, EventArgs e)
		{
            MainViewModel.Instance.KioskApp.TelephoneVm.TelephoneFilled(sender, e);
		}

	}
}