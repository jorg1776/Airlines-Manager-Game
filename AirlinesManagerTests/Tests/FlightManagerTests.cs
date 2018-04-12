using AirlinesManagerGame.Models;
using AirlinesManagerGame.Models.Airports;
using AirlinesManagerGame.Sevices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Device.Location;

namespace AirlinesManagerTests
{
    [TestClass]
    public class FlightManagerTests
    {
        [TestMethod]
        public void FlyPlaneTest()
        {
            var plane = new Bearclaw();
            plane.Location = new SaltLakeCityAirport();
            var destination = new PhoenixAirport();

            FlightManager.FlyPlane(plane, destination);

            Assert.AreEqual(plane.Location, destination);
        }

        [TestMethod]
        public void AirportNameToURLFormatTest()
        {
            var airportName = new SaltLakeCityAirport().Name;
            Assert.AreEqual("Salt+Lake+City+Airport", airportName.Replace(' ', '+'));
        }
    }
}
