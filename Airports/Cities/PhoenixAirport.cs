using AirlinesManagerGame.Airplanes;

namespace AirlinesManagerGame.Airports.Cities
{
    public sealed class PhoenixAirport : Airport
    {
        private static readonly PhoenixAirport phxAirport = new PhoenixAirport();
        private static string _cityName = "Phoenix";

        private PhoenixAirport()
        {
            City = _cityName;
        }

        public static PhoenixAirport Instance { get { return phxAirport; } }

        public override void LandPlane(Airplane airplane)
        {
            DockedAirplanes.Add(airplane);
            airplane.Location = phxAirport;
        }
    }
}
