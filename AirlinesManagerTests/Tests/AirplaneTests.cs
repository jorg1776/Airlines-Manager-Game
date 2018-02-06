using System;
using AirlinesManagerGame.Airplanes;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace AirlinesManagerTests.Tests
{
    [TestClass]
    public class AirplaneTests
    {
        [TestMethod]
        public void AirplaneDeclerationTest()
        {
            var plane1 = new Bearclaw();
            Assert.AreEqual("Bearclaw", plane1.Name);
            Assert.AreEqual(5000, plane1.Price);

            var plane2 = new Wallaby();
            Assert.AreEqual("Wallaby", plane2.Name);
        }
    }
}
