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
            var user = new User();
            var storeVM = new AirplaneStoreViewModel(user);

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
            var user = new User();
            var mediator = new ItemPurchaseMediator();
            var airplanesStatusVM = new AirplanesStatusViewModel(user);
            var airplane = new Bearclaw();

            //Act
            ItemPurchaseMediator.AddAirplane(this,airplane);

            //Assert
            Assert.IsTrue(airplanesStatusVM.AirplanesList.Contains(airplane));
        }

        [TestMethod]
        public void AddAirplane_UsersPlaneSlotsDecreased_ByOne()
        {
            //Arrange
            var user = new User();
            var mediator = new ItemPurchaseMediator();
            var airplanesStatusVM = new AirplanesStatusViewModel(user);
            var airplane = new Bearclaw();
            var usersAvailablePlainSlotsBefore = airplanesStatusVM.UsersAvailableAirplaneSlots;

            //Act
            ItemPurchaseMediator.AddAirplane(this, airplane);
            var usersAvailablePlainSlotsAfter = airplanesStatusVM.UsersAvailableAirplaneSlots;

            //Assert
            Assert.AreEqual(usersAvailablePlainSlotsBefore - 1, usersAvailablePlainSlotsAfter);
        }
    }
}
