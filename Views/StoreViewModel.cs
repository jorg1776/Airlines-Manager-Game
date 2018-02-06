using System.Collections.ObjectModel;

namespace AirlinesManagerGame.Views
{
    public class StoreViewModel
    {
        public ObservableCollection<Airplanes.Airplane> AvailableAirplanesList => Store.Store.AvailableAirplanes;
    }
}
