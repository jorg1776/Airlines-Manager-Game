using AirlinesManagerGame.Models;
using AirlinesManagerGame.Services.Mediators;
using GalaSoft.MvvmLight.Messaging;

namespace AirlinesManagerGame.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private static User user = new User();

        private ViewModelBase _currentViewModel;
        private static readonly AirplanesStatusViewModel airplanesStatusViewModel = new AirplanesStatusViewModel(user);
        private static readonly AirplaneStoreViewModel airplaneStoreViewModel = new AirplaneStoreViewModel(user);
        private static readonly AirportStoreViewModel airportStoreViewModel = new AirportStoreViewModel(user);

        public MainWindowViewModel()
        {
            CurrentViewModel = airplanesStatusViewModel;
            Messenger.Default.Register<string>(this, (viewName) => SetCurrentView(viewName));

            AirplanePurchaseMediator.OnAirplanePurchased += (sender, e) => UsersMoney -= e.PurchasedAirplane.Price;
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
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        }

        public string UsersMoneyAsString { get { return string.Format("Money: ${0:n0}", UsersMoney); } }
        public int UsersMoney
        {
            get { return user.Money; }
            set { user.Money = value; OnPropertyChanged(nameof(UsersMoneyAsString)); }
        }

        public string UsersLevelString { get { return string.Format("Level {0}", UsersLevel); } }
        public int UsersLevel
        {
            get { return user.Level; }
            set { user.Level = value; }
        }

        private void SetCurrentView(string viewName)
        {
            switch (viewName)
            {
                case "AirplanesStatusView":
                    CurrentViewModel = airplanesStatusViewModel;
                    break;
                case "AirplaneStoreView":
                    CurrentViewModel = airplaneStoreViewModel;
                    break;
                case "AirportStoreView":
                    CurrentViewModel = airportStoreViewModel;
                    break;
            }
        }
    }
}
