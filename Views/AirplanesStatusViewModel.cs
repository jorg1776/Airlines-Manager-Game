using System.Collections.ObjectModel;

namespace AirlinesManagerGame.Views
{
    public class AirplanesStatusViewModel
    {
        public ObservableCollection<Airplanes.Airplane> AirplanesList => User.OwnedAirplanes;
    }
}
