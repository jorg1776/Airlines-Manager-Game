using AirlinesManagerGame.Models;

namespace AirlinesManagerGame.Airports.Cities
{
    public sealed class PhoenixAirport : Airport
    {
        private static readonly PhoenixAirport phxAirport = new PhoenixAirport();

        private PhoenixAirport()
        {
            Name = "Phoenix Airport";
        }

        public static PhoenixAirport Instance { get { return phxAirport; } }
    }
}
