using System;
using System.Collections.Generic;
using System.Device.Location;

namespace AirlinesManagerGame.Models
{
    public class Airport
    {
        public User GetUser { get; private set; }

        public string Name { get; protected set; }
        public int Price { get; protected set; }
        public string PriceAsString { get { return String.Format("${0:n0}", Price); } }
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
