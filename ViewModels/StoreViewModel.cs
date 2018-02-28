using AirlinesManagerGame.Models;
using AirlinesManagerGame.Services.Mediators;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.ObjectModel;

namespace AirlinesManagerGame.ViewModels
{
    public class StoreViewModel : ViewModelBase
    {
        private User user;
        private static Store store = new Store();

        public ObservableCollection<Airplane> AvailableAirplanesList { get { return store.AvailableAirplanes; } }

        public RelayCommand GoBackViewCommand { get; private set; }
        public RelayCommand PurchaseAirplaneCommand { get; private set; }
        private PurchaseVerificationViewModel purchaseVerificationViewModel = new PurchaseVerificationViewModel();

        public StoreViewModel(User user)
        {
            this.user = user;

            GoBackViewCommand = new RelayCommand(() => SendSwitchViewMessage("AirplanesStatusView"));
            PurchaseAirplaneCommand = new RelayCommand(() => VerifyPurchase(SelectedAirplane));
            purchaseVerificationViewModel.OnDecisionVerified += PurchaseAirplane;
        }

        public Airplane SelectedAirplane { get; set; }

        private string _errorText;
        public string ErrorText
        {
            get { return _errorText; }
            private set { _errorText = value; OnPropertyChanged(nameof(ErrorText)); }
        }

        private void VerifyPurchase(Airplane airplaneForPurchase)
        {
            if(airplaneForPurchase == null)
            {
                ErrorText = "Please select an airplane";
            }
            else if (airplaneForPurchase != null && CanUserPurchaseAirplane(airplaneForPurchase))
            {
                purchaseVerificationViewModel.ValidatePurchase(airplaneForPurchase);
            }
            else
            {
                ErrorText = DetermineError(airplaneForPurchase);
            }
        }

        public bool CanUserPurchaseAirplane(Airplane airplane)
        {
            return IsUserHighEnoughLevel(airplane)
                    && DoesUserHaveEnoughMoney(airplane)
                    && DoesUserHaveTheCapacity();
        }

        private bool IsUserHighEnoughLevel(Airplane airplane) { return user.Level >= airplane.LevelToUnlock; }

        private bool DoesUserHaveEnoughMoney(Airplane airplane) { return user.Money >= airplane.Price; }

        private bool DoesUserHaveTheCapacity() { return user.AvailableAirplaneSlots > 0; }

        private string DetermineError(Airplane airplaneForPurchase)
        {
            if(!IsUserHighEnoughLevel(airplaneForPurchase)) { return "Not high enough level"; }
            else if (!DoesUserHaveEnoughMoney(airplaneForPurchase)) { return "Not enough money"; }
            else if (!DoesUserHaveTheCapacity()) { return "Insufficient capacity"; }
            else { return "Error"; }
        }

        private void PurchaseAirplane(object sender, VerificationEventArgs e)
        {
            if (e.Decision == true)
            {
                var purchasedAirplane = CreateNewAirplane(e.PurchasedAirplane.GetType().Name);
                AirplanePurchaseMediator.AddAirplane(this, purchasedAirplane);
            }
        }

        private Airplane CreateNewAirplane(string name)
        {
            switch (name)
            {
                case "Bearclaw":
                    return new Bearclaw();
                case "Griffon":
                    return new Griffon();
                case "Wallaby":
                    return new Wallaby();
                default:
                    throw new Exception();
            }
        }
    }
}
