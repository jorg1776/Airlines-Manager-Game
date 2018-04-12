using AirlinesManagerGame.Models.Airports;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace AirlinesManagerGame.Models
{
    public sealed class Store
    {
        private User user;

        private List<Airplane> _listOfAirplanes;
        private List<Airport> _listOfAirports;
        public ObservableCollection<Airplane> AvailableAirplanes { get; private set; }
        public ObservableCollection<Airport> Airports { get; private set; }

        public Store(User user)
        {
            this.user = user;

            _listOfAirplanes = new List<Airplane>();
            PopulateListOfAirplanes();
            AvailableAirplanes = SortCollection(_listOfAirplanes);

            _listOfAirports = new List<Airport>();
            PopulateListOfAirports();
            Airports = SortCollection(_listOfAirports);
        }

        private void PopulateListOfAirplanes()
        {
            _listOfAirplanes.Add(new Bearclaw());
            _listOfAirplanes.Add(new Griffon());
            _listOfAirplanes.Add(new Wallaby());
        }

        private void PopulateListOfAirports()
        {
            _listOfAirports.Add(new SaltLakeCityAirport(user));
            _listOfAirports.Add(new PhoenixAirport(user));
        }

        private ObservableCollection<Airplane> SortCollection(List<Airplane> listOfAirplanes)
        {
            listOfAirplanes = listOfAirplanes.OrderBy(airplane => airplane.LevelToUnlock).ToList();
            return new ObservableCollection<Airplane>(listOfAirplanes);
        }

        private ObservableCollection<Airport> SortCollection(List<Airport> listOfAirports)
        {
            listOfAirports = listOfAirports.OrderBy(airplane => airplane.GetRegion).ToList();
            return new ObservableCollection<Airport>(listOfAirports);
        }
    }
}
