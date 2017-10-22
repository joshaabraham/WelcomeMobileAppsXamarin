using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApps.Views.Navigation.SubViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CampusPromptView : ContentView
    {
        public CampusPromptView()
        {
            InitializeComponent();
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}