using System.Collections.Generic;
using System.Device.Location;

namespace AirlinesManagerGame.Models
{
    public class Airport : StoreItem
    {
        public User GetUser { get; private set; }

        protected Regions Region { get; set; }
        public string GetRegion { get { return Region.ToString().Replace("_", " "); } }
        public List<Airplane> DockedAirplanes { get; private set; }
        public List<Passenger> AvailablePassengers { get; }
        public List<Cargo> AvailableCargo { get; }

        public GeoCoordinate Location { get; protected set; }

        protected Airport(User user)
        {
            GetUser = user;
            DockedAirplanes = new List<Airplane>();
        }

        public enum Regions
        {
            North_America,
            South_America,
            Europe,
            Africa,
            Asia
        }
    }
}
