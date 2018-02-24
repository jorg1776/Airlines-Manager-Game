using AirlinesManagerGame.Models;
using AirlinesManagerGame.Airports.Cities;
using AirlinesManagerGame.Sevices;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace AirlinesManagerTests
{
    [TestClass]
    public class FlightManagerTests
    {
        [TestMethod]
        public void FlyPlaneTest()
        {
            var plane = new Bearclaw();
            plane.Location = SaltLakeCityAirport.Instance;
            var destination = PhoenixAirport.Instance;

            FlightManager.FlyPlane(plane, destination);

            Assert.AreEqual(plane.Location, PhoenixAirport.Instance);
        }

        [TestMethod]
        public void AirportNameToURLFormatTest()
        {
            var airportName = SaltLakeCityAirport.Instance.Name;
            Assert.AreEqual("Salt+Lake+City+Airport", airportName.Replace(' ', '+'));
        }

        [TestMethod]
        public void DistanceCalculator()
        {
            int distance = AirlinesManagerGame.FlightManager.GoogleGeoCodeRequest.GetDistance(SaltLakeCityAirport.Instance, PhoenixAirport.Instance);

            Assert.AreEqual(508, distance);
        }
    }
}
