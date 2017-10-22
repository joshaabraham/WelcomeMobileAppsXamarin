using System;

namespace MobileApps.ViewModels
{
    public abstract class SubViewModel : ViewModelBase
    {
		private bool _awaitingData = false;
		public bool AwaitingData
		{
			get { return _awaitingData; }
			set { _awaitingData = value; OnPropertyChanged(nameof(AwaitingData)); }
		}

        private bool _isValid = true ;
        public bool IsValid
        {
            get { return _isValid; }
            set
            {
                if (_isValid == value) return;
                _isValid = value;
                OnPropertyChanged(nameof(IsValid));
            }
        }
        private NavigationStateViewModel _navigationStateViewModel;
        public NavigationStateViewModel NavigationStateViewModel { get { return _navigationStateViewModel; } }
        protected SubViewModel()
        {
            _navigationStateViewModel = new NavigationStateViewModel();
            NavigationStateViewModel.SubViewModel = this;
        }
    }
}
