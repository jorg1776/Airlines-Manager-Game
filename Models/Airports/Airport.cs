using System.Collections.Generic;
using System.Device.Location;

namespace AirlinesManagerGame.Models
{
    public class Airport
    {
        public string Name { get; protected set; }
        public int Price { get; protected set; }
        public List<Airplane> DockedAirplanes { get; private set; }
        public List<Passenger> AvailablePassengers { get; }
        public List<Cargo> AvailableCargo { get; }

        public GeoCoordinate Location { get; protected set; }

        protected Airport()
        {
            DockedAirplanes = new List<Airplane>();
        }
    }
}
