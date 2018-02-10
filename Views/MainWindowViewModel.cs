using System;
using GalaSoft.MvvmLight.Messaging;

namespace AirlinesManagerGame.Views
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ViewModelBase _currentViewModel;
        private static readonly AirplanesStatusViewModel airplanesStatusViewModel = new AirplanesStatusViewModel();
        private static readonly StoreViewModel storeViewModel = new StoreViewModel();

        public MainWindowViewModel()
        {
            CurrentViewModel = airplanesStatusViewModel;
            Messenger.Default.Register<string>(this, (viewName) => SetCurrentView(viewName));
        }

        public ViewModelBase CurrentViewModel
        {
            get
            {
                return _currentViewModel;
            }
            set
            {
                _currentViewModel = value;
                RaisePropertyChanged("CurrentViewModel");
            }
        }

        private void SetCurrentView(string viewName)
        {
            switch(viewName)
            {
                case "AirplanesStatusView":
                    Console.WriteLine("Status View");
                    CurrentViewModel = airplanesStatusViewModel;
                    break;
                case "StoreView":
                    CurrentViewModel = storeViewModel;
                    break;
            }
        }
    }
}
