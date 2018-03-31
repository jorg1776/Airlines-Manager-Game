using AirlinesManagerGame.Sevices;

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
            //TODO: Get User's owned airports and select a random airport from that list
            return null;
        }

        protected abstract string GetRandomName();
    }
}
