using AirlinesManagerGame.Models;
using System.Collections.ObjectModel;

namespace AirlinesManagerGame.ViewModels
{
    public class AirportStoreViewModel : StoreViewModel
    {
        public ObservableCollection<Airport> AirportsList { get { return store.Airports; } }

        public AirportStoreViewModel(User _user) : base(_user)
        {
        }
    }
}
