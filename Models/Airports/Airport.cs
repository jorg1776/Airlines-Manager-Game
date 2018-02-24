using System.Collections.Generic;

namespace AirlinesManagerGame.Models
{
    public abstract class Airport
    {
        public string Name { get; protected set; }
        public int Price { get; protected set; }
        public List<Airplane> DockedAirplanes { get; protected set; }
        public List<Passenger> AvailablePassengers { get; }
        public List<Cargo> AvailableCargo { get; }

        protected Airport()
        {
            DockedAirplanes = new List<Airplane>();
        }
    }
}
