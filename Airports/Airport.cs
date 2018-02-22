using AirlinesManagerGame.Airplanes;
using AirlinesManagerGame.CargoType;
using System.Collections.Generic;

namespace AirlinesManagerGame.Airports
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

        public void SendPlane(Airplane airplane)
        {
            DockedAirplanes.Remove(airplane);
        }

        public abstract void LandPlane(Airplane airplane);
    }
}
