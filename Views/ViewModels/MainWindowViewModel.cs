using GalaSoft.MvvmLight.Messaging;
using System;
using System.ComponentModel;

namespace AirlinesManagerGame.Views.ViewModels
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
            User.Instance.PropertyChanged += userPropertyChanged;
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
                OnPropertyChanged("CurrentViewModel");
            }
        }

        public string UsersMoney
        {
            get { return string.Format("${0:n0}", User.Money); }
        }

        private void SetCurrentView(string viewName)
        {
            switch(viewName)
            {
                case "AirplanesStatusView":
                    CurrentViewModel = airplanesStatusViewModel;
                    break;
                case "StoreView":
                    CurrentViewModel = storeViewModel;
                    break;
            }
        }

        private void userPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged("Users" + e.PropertyName);
        }
    }
}
