using System;
using AirlinesManagerGame.Models;
using AirlinesManagerGame.ViewModels;
using AirlinesManagerGame.Services.Mediators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AirlinesManagerTests.Tests
{
    [TestClass]
    public class StoreTests
    {
        [TestMethod]
        public void StorePopulating_StoreNotEmpty()
        {
            //Arrange
            var storeVM = new StoreViewModel();

            //Act
            var availableAirplanes = storeVM.AvailableAirplanesList;

            //Assert
            Assert.IsTrue(availableAirplanes.Count > 0);
        }

        [TestMethod]
        public void PurchaseVerification_CorrectAirplaneVerified()
        {
            //Arrange
            var purchaseVerificationVM = new PurchaseVerificationViewModel();
            var airplane = new Bearclaw();

            //Act
            purchaseVerificationVM.ValidatePurchase(airplane);

            //Assert
            Assert.AreEqual((String.Format("Would you like to purchase {0} for {1}?", airplane.Name, airplane.PriceAsString)), purchaseVerificationVM.VerificationQuestion);
        }

        [TestMethod]
        public void AddPurchasedAirplane_CorrectAirplaneAdded()
        {
            //Arrange
            var mediator = new AirplanePurchaseMediator();
            var airplanesStatusVM = new AirplanesStatusViewModel();
            var airplane = new Bearclaw();

            //Act
            AirplanePurchaseMediator.AddAirplane(this,airplane);

            //Assert
            Assert.IsTrue(airplanesStatusVM.AirplanesList.Count > 0);
            Assert.IsTrue(airplanesStatusVM.AirplanesList.Contains(airplane));
        }
    }
}
