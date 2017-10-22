using System;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using MobileApps.Views.CustomControls;

namespace MobileApps.Views.Navigation.SubViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsView : ContentView
    {
        public SettingsView()
        {
            InitializeComponent();
        }
        SelectMultipleBasePage<CheckItem> multiPage;
        async void OnClick(object sender, EventArgs ea)
        {
            var items = new List<CheckItem>();
            items.Add(new CheckItem { Name = "Xamarin.com" });
            items.Add(new CheckItem { Name = "Twitter" });
            items.Add(new CheckItem { Name = "Facebook" });
            items.Add(new CheckItem { Name = "Internet ad" });
            items.Add(new CheckItem { Name = "Online article" });
            items.Add(new CheckItem { Name = "Magazine ad" });
            items.Add(new CheckItem { Name = "Friends" });
            items.Add(new CheckItem { Name = "At work" });

            if (multiPage == null)
                multiPage = new SelectMultipleBasePage<CheckItem>(items) { Title = "Check all that apply" };

            await Navigation.PushAsync(multiPage);
        }
    }
}