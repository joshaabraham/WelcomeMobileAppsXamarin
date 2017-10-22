using MobileApps.Context;

namespace MobileApps.ViewModels
{
    internal class MainViewModel
    {
        public static MainViewModel Instance;

        private readonly NavigationViewModel _navVm;
        private KioskApplicationContext _kioskApp;
        public NavigationViewModel NavVm => _navVm;

        public KioskApplicationContext KioskApp
        {
            get
            {
                return _kioskApp;
            }
            set
            {
                _kioskApp = value;
            }
        }

        public MainViewModel()
        {
            Instance = this;
            _navVm = new NavigationViewModel();
            KioskApp = new KioskApplicationContext();
        }

    }
}
