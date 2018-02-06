using AirlinesManagerGame.Airplanes;

namespace AirlinesManagerGame.Airports.Cities
{
    public sealed class SaltLakeCityAirport : Airport
    {
        private static readonly SaltLakeCityAirport slcAirport = new SaltLakeCityAirport();
        private static string _cityName = "Salt Lake City";

        private SaltLakeCityAirport()
        {
            City = _cityName;
        }

        public static SaltLakeCityAirport Instance{ get { return slcAirport; } }

        public override void LandPlane(Airplane airplane)
        {
            DockedAirplanes.Add(airplane);
            airplane.Location = Instance;
        }
    }
}
