using AirlinesManagerGame.Sevices;
using System;

namespace AirlinesManagerGame.Models
{
    public abstract class ICargoType
    {
        public int Revenue { get; protected set; }
        public string Name { get; protected set; }

        public Airport Location { get; set; }
        public Airport Destination { get; set; }

        public ICargoType(Airport _location)
        {
            Location = _location;
            Destination = SetRandomDestination();
            Revenue = CalculateRevenue();
        }

        protected int CalculateRevenue()
        {
            return FlightManager.CalculateDistance(Location, Destination) + 50;
        }

        protected Airport SetRandomDestination()
        {
            var ownedAirports = Location.GetUser.OwnedAirports;

            Random random = new Random();
            int index = random.Next(ownedAirports.Count);

            return ownedAirports[index];
        }

        protected abstract string GetRandomName();
    }
}
