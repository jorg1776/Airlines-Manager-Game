using AirlinesManagerGame.Models;

namespace AirlinesManagerGame.Airports.Cities
{
    public sealed class SaltLakeCityAirport : Airport
    {
        private static readonly SaltLakeCityAirport slcAirport = new SaltLakeCityAirport();

        private SaltLakeCityAirport()
        {
            Name = "Salt Lake City Airport";
        }

        public static SaltLakeCityAirport Instance{ get { return slcAirport; } }

        public override void LandPlane(Airplane airplane)
        {
            DockedAirplanes.Add(airplane);
            airplane.Location = Instance;
        }
    }
}
