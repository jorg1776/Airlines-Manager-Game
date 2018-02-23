using AirlinesManagerGame.Models;
using GalaSoft.MvvmLight.Messaging;
using AirlinesManagerGame.Sevices.Mediators;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace AirlinesManagerGame.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ViewModelBase _currentViewModel;
        private static readonly AirplanesStatusViewModel airplanesStatusViewModel = new AirplanesStatusViewModel();
        private static readonly StoreViewModel storeViewModel = new StoreViewModel();
        private static readonly MapViewModel mapViewModel = new MapViewModel();

        public ObservableCollection<Airplane> OwnedAirplanes { get { return User.OwnedAirplanes; } }

        public MainWindowViewModel()
        {
            CurrentViewModel = airplanesStatusViewModel;
            Messenger.Default.Register<string>(this, (viewName) => SetCurrentView(viewName));
            StoreMainMediator.OnAirplanePurchased += new StoreMainMediator.AirplanePurchasedEventHandler(AddPurchasedAirplane);
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
            get { return User.Money; }
            set { User.Money = value; OnPropertyChanged(nameof(UsersMoneyAsString)); }
        }

        public string UsersLevelString {  get { return string.Format("Level {0}", UsersLevel); } }
        public int UsersLevel
        {
            get { return User.Level; }
            set { User.Level = value; }
        }

        public static int UsersAvailableAirplaneSlots
        {
            get { return User.AvailableAirplaneSlots; }
            set { User.AvailableAirplaneSlots = value; }
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
                case "MapView":
                    CurrentViewModel = mapViewModel;
                    break;
            }
        }

        public void AddPurchasedAirplane(object sender, StoreMainMediator.AirplanePurchasedEventArgs e)
        {
            var purchasedAirplane = e.PurchasedAirplane;
            OwnedAirplanes.Add(purchasedAirplane);
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, purchasedAirplane));

            UsersAvailableAirplaneSlots--;
            UsersMoney -= purchasedAirplane.Price;
        }
    }
}
