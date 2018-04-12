using AirlinesManagerGame.Models;
using AirlinesManagerGame.Services.Mediators;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace AirlinesManagerGame.ViewModels
{
    public class AirportStoreViewModel : StoreViewModel
    {
        public ObservableCollection<Airport> AirportsList { get { return store.Airports; } }

        public ObservableCollection<Airport> OwnedAirports { get { return user.OwnedAirports; } }

        public AirportStoreViewModel(User _user) : base(_user)
        {
            ItemPurchaseMediator.OnAirportPurchased += AddAirport;
        }

        private void AddAirport(object sender, ItemPurchaseMediator.AirportPurchasedEventArgs e)
        {
            var purchasedAirport = e.PurchasedAirport;
            OwnedAirports.Add(purchasedAirport);
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, purchasedAirport));

            AirportsList.Remove(purchasedAirport);
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, purchasedAirport));
        }
    }
}
