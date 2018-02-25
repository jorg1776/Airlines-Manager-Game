using AirlinesManagerGame.Models;
using AirlinesManagerGame.Sevices.Mediators;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.ObjectModel;

namespace AirlinesManagerGame.ViewModels
{
    public class StoreViewModel : ViewModelBase
    {
        public ObservableCollection<Airplane> AvailableAirplanesList { get { return Store.AvailableAirplanes; } }

        public RelayCommand GoBackViewCommand { get; private set; }
        public RelayCommand PurchaseAirplaneCommand { get; private set; }
        private PurchaseVerificationViewModel purchaseVerificationViewModel = new PurchaseVerificationViewModel();

        public StoreViewModel()
        {
            GoBackViewCommand = new RelayCommand(() => SendSwitchViewMessage("AirplanesStatusView"));
            PurchaseAirplaneCommand = new RelayCommand(() => VerifyPurchase(SelectedAirplane));
            purchaseVerificationViewModel.OnDecisionVerified += PurchaseAirplane;
        }

        public Airplane SelectedAirplane { get; set; }

        private void VerifyPurchase(Airplane airplaneForPurchase)
        {
            if(airplaneForPurchase == null)
            {
                Console.WriteLine("null");
            }
            else if (airplaneForPurchase != null && CanUserPurchaseAirplane(airplaneForPurchase))
            {
                purchaseVerificationViewModel.ValidatePurchase(airplaneForPurchase);
            }
            else
            {
                Console.WriteLine("Can't purchase");
            }
        }

        private void PurchaseAirplane(object sender, VerificationEventArgs e)
        {
            if (e.Decision == true)
            {
                var purchasedAirplane = CreateNewAirplane(SelectedAirplane.GetType().Name);
                AirplanePurchaseMediator.AddAirplane(this, purchasedAirplane);
            }
        }

        private Airplane CreateNewAirplane(string name)
        {
            switch (name)
            {
                case "Bearclaw":
                    return new Bearclaw();
                case "Wallaby":
                    return new Wallaby();
                default:
                    throw new Exception();
            }
        }

        public bool CanUserPurchaseAirplane(Airplane airplane)
        {
            return IsUserHighEnoughLevel(airplane)
                    && DoesUserHaveEnoughMoney(airplane)
                    && DoesUserHaveTheCapacity();
        }

        private bool IsUserHighEnoughLevel(Airplane airplane) { return User.Level >= airplane.LevelToUnlockAirplane; }

        private bool DoesUserHaveEnoughMoney(Airplane airplane) { return User.Money >= airplane.Price; }

        private bool DoesUserHaveTheCapacity() { return User.AvailableAirplaneSlots > 0; }
    }
}
