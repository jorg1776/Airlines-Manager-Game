using AirlinesManagerGame.Models;
using AirlinesManagerGame.Sevices.Mediators;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace AirlinesManagerGame.ViewModels
{
    public class AirplanesStatusViewModel : ViewModelBase
    {
        public RelayCommand LoadPlaneCommand { get; private set; }
        public RelayCommand GoToStoreViewCommand { get; private set; }
        public RelayCommand GoToMapViewCommand { get; private set; }

        public AirplanesStatusViewModel()
        {
            //LoadPlaneCommand = new RelayCommand();
            GoToStoreViewCommand = new RelayCommand(() => SendSwitchViewMessage("StoreView"));
            GoToMapViewCommand = new RelayCommand(() => SendSwitchViewMessage("MapView"));
            
            AirplanePurchaseMediator.OnAirplanePurchased += AddPurchasedAirplane;
        }

        public ObservableCollection<Airplane> AirplanesList { get { return User.OwnedAirplanes; } }

        public Airplane SelectedAirplane { get; set; }

        public int UsersAvailableAirplaneSlots
        {
            get { return User.AvailableAirplaneSlots; }
            set { User.AvailableAirplaneSlots = value; }
        }

        public void AddPurchasedAirplane(object sender, AirplanePurchaseMediator.AirplanePurchasedEventArgs e)
        {
            var purchasedAirplane = e.PurchasedAirplane;
            AirplanesList.Add(purchasedAirplane);
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, purchasedAirplane));

            UsersAvailableAirplaneSlots--;
        }
    }
}
