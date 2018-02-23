using AirlinesManagerGame.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AirlinesManagerTests.Tests
{
    [TestClass]
    public class StoreTests
    {
        [TestMethod]
        public void StorePopulateTest()
        {
            Assert.IsTrue(Store.AvailableAirplanes.Count > 0);
        }
    }
}
