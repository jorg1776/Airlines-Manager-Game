using AirlinesManagerGame.Models;
using AirlinesManagerGame.Airports.Cities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AirlinesManagerTests
{
    [TestClass]
    public class FlightManagerTests
    {
        [TestMethod]
        public void FlightLandingTest()
        {
            var plane = new Bearclaw();
            SaltLakeCityAirport.Instance.LandPlane(plane);

            Assert.AreEqual(plane.Location, SaltLakeCityAirport.Instance);
            Assert.AreEqual(1, SaltLakeCityAirport.Instance.DockedAirplanes.Count);
        }

        [TestMethod]
        public void FlightSendingTest()
        {
            var plane = new Bearclaw();
            SaltLakeCityAirport.Instance.LandPlane(plane);
            Assert.AreEqual(1, SaltLakeCityAirport.Instance.DockedAirplanes.Count);

            SaltLakeCityAirport.Instance.SendPlane(plane);
            Assert.AreEqual(0, SaltLakeCityAirport.Instance.DockedAirplanes.Count);
        }

        [TestMethod]
        public void FlyTest()
        {
            var plane = new Bearclaw();
            SaltLakeCityAirport.Instance.LandPlane(plane);
            Assert.AreEqual(1, SaltLakeCityAirport.Instance.DockedAirplanes.Count);
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
