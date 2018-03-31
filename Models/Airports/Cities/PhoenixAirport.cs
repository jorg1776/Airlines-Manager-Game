using System.Device.Location;

namespace AirlinesManagerGame.Models.Airports
{
    public sealed class PhoenixAirport : Airport
    {
        //33.4373° N, 112.0078° W
        private double latitude = 33.4373;
        private double longitude = 112.0078;

        public PhoenixAirport(User user) : base(user)
        {
            Name = "Phoenix Airport";
            Location = new GeoCoordinate(latitude, longitude);
            Region = Regions.North_America;
        }
    }
}
