using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace AirlinesManagerGame.Models
{
    public sealed class Store
    {
        private List<Airplane> _listOfAirplanes;
        public ObservableCollection<Airplane> AvailableAirplanes { get; private set; }

        public Store()
        {
            _listOfAirplanes = new List<Airplane>();
            PopulateListOfAirplanes();
            AvailableAirplanes = SortCollection(_listOfAirplanes);
        }

        private void PopulateListOfAirplanes()
        {
            _listOfAirplanes.Add(new Bearclaw());
            _listOfAirplanes.Add(new Griffon());
            _listOfAirplanes.Add(new Wallaby());
        }

        private ObservableCollection<Airplane> SortCollection(List<Airplane> listOfAirplanes)
        {
            listOfAirplanes = listOfAirplanes.OrderBy(airplane => airplane.LevelToUnlock).ToList();
            return new ObservableCollection<Airplane>(listOfAirplanes);
        }
    }
}
