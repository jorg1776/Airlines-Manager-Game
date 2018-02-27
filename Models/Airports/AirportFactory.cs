namespace AirlinesManagerGame.Models.Airports
{
    public class AirportFactory
    {
        private static SaltLakeCityAirport slc = new SaltLakeCityAirport();
        private static PhoenixAirport phx = new PhoenixAirport();

        public static Airport GetAirport(string airportName)
        {
            switch(airportName)
            {
                case "Salt Lake City":
                    return slc;
                case "Phoenix":
                    return phx;
                default:
                    return null;
            }
        }
    }
}
