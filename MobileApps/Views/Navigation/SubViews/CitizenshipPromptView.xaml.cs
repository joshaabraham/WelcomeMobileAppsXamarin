using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MobileApps.ViewModels.Kiosk;

namespace MobileApps.Views.Navigation.SubViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CitizenshipPromptView : ContentView
    {
        public CitizenshipPromptView()
        {
            InitializeComponent();
        }
    }
}