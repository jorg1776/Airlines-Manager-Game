using AirlinesManagerGame.Models;
using AirlinesManagerGame.Services.Mediators;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace AirlinesManagerGame.ViewModels
{
    public class AirplanesStatusViewModel : ViewModelBase
    {
        private User user;

        public RelayCommand LoadPlaneCommand { get; private set; }
        public RelayCommand GoToAirplaneStoreViewCommand { get; private set; }
        public RelayCommand GoToAirportStoreViewCommand { get; private set; }

        public AirplanesStatusViewModel(User user)
        {
            this.user = user;

            //LoadPlaneCommand = new RelayCommand();
            GoToAirplaneStoreViewCommand = new RelayCommand(() => SendSwitchViewMessage("AirplaneStoreView"));
            GoToAirportStoreViewCommand = new RelayCommand(() => SendSwitchViewMessage("AirportStoreView"));

            AirplanePurchaseMediator.OnAirplanePurchased += AddPurchasedAirplane;
        }

        public ObservableCollection<Airplane> AirplanesList { get { return user.OwnedAirplanes; } }

        public Airplane SelectedAirplane { get; set; }

        public int UsersAvailableAirplaneSlots
        {
            get { return user.AvailableAirplaneSlots; }
            set { user.AvailableAirplaneSlots = value; }
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
