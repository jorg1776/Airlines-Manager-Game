using AirlinesManagerGame.Airplanes;
using System.Collections.ObjectModel;

namespace AirlinesManagerGame.Store
{
    public sealed class Store
    {
        private static readonly Store store = new Store();
        public static ObservableCollection<Airplane> AvailableAirplanes { get; private set; }

        private Store()
        {
            AvailableAirplanes = new ObservableCollection<Airplane>();
            PopulateListOfAirplanes();
        }

        public static Store Instance { get { return store; } }

        private static void PopulateListOfAirplanes()
        {
            AvailableAirplanes.Add(new Bearclaw());
            AvailableAirplanes.Add(new Wallaby());
        }
    }
}
