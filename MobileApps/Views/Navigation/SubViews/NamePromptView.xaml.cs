using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileApps.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApps.Views.Navigation.SubViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NamePromptView : ContentView
    {
        public NamePromptView()
        {
            InitializeComponent();
        }

		// BAD PRACTICE , WE MUST TRIGGER VM DIRECTLY
		public void NameFilled(object sender, EventArgs e)
		{
			MainViewModel.Instance.KioskApp.NameVm.NameFilled(sender, e);
		}
    }
}