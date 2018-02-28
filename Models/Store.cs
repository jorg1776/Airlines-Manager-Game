using System.Collections.ObjectModel;

namespace AirlinesManagerGame.Models
{
    public sealed class Store
    {
        public ObservableCollection<Airplane> AvailableAirplanes { get; private set; }

        public Store()
        {
            AvailableAirplanes = new ObservableCollection<Airplane>();
            PopulateListOfAirplanes();
        }

        private void PopulateListOfAirplanes()
        {
            AvailableAirplanes.Add(new Bearclaw());
            AvailableAirplanes.Add(new Wallaby());
            AvailableAirplanes.Add(new Griffon());
        }
    }
}
