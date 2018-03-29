using System.Device.Location;

namespace AirlinesManagerGame.Models.Airports
{
    public sealed class PhoenixAirport : Airport
    {
        //33.4373° N, 112.0078° W
        private double latitude = 33.4373;
        private double longitude = 112.0078;

        public PhoenixAirport()
        {
            Name = "Phoenix Airport";
            Location = new GeoCoordinate(latitude, longitude);
        }
    }
}
