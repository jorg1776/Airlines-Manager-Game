using System.Device.Location;

namespace AirlinesManagerGame.Models.Airports
{
    public sealed class SaltLakeCityAirport : Airport
    {
        //40.7899° N, 111.9791° W
        private double latitude = 40.7899;
        private double longitude = 111.9791;

        public SaltLakeCityAirport(User user) : base(user)
        {
            Name = "Salt Lake City Airport";
            Location = new GeoCoordinate(latitude, longitude);
            Region = Regions.North_America;
        }
    }
}
