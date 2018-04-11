using AirlinesManagerGame.Models;
using AirlinesManagerGame.Services.Mediators;
using GalaSoft.MvvmLight.Command;
using System;
using System.Windows.Threading;

namespace AirlinesManagerGame.ViewModels
{
    public class StoreViewModel : ViewModelBase
    {
        protected static User user;
        protected static Store store;

        public RelayCommand GoBackViewCommand { get; private set; }
        public RelayCommand PurchaseItemCommand { get; private set; }
        private PurchaseVerificationViewModel purchaseVerificationViewModel = new PurchaseVerificationViewModel();

        public StoreItem SelectedItem { get; set; }

        private string _timerDisplay = "Refresh Types in: ";
        public string TimerDisplay
        {
            get { return _timerDisplay; }
            set { _timerDisplay = value; OnPropertyChanged(nameof(TimerDisplay)); }
        }

        public StoreViewModel(User _user)
        {
            user = _user;
            store = new Store(user);

            GoBackViewCommand = new RelayCommand(() => SendSwitchViewMessage("AirplanesStatusView"));
            PurchaseItemCommand = new RelayCommand(() => VerifyPurchase(SelectedItem));
            purchaseVerificationViewModel.OnDecisionVerified += PurchaseItem;
            StartTimer();
        }

        private DispatcherTimer timer1;
        private TimeSpan time = TimeSpan.FromMinutes(5);
        private void StartTimer()
        {
            timer1 = new DispatcherTimer();
            timer1.Tick += timer_Tick;
            timer1.Interval = new TimeSpan(0, 0, 1); // 60 seconds
            timer1.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            time -= TimeSpan.FromSeconds(1);
            TimerDisplay = "Refresh Types in: " + time.ToString(@"m\:ss");
            if (time == TimeSpan.Zero)
            {
                timer1.Stop();
                RefreshLoadTypes();
                time = TimeSpan.FromMinutes(5);
                timer1.Start();
            }
        }

        private void RefreshLoadTypes()
        {
            foreach (Airplane airplane in AirplaneStoreViewModel.AvailableAirplanesList)
            {
                airplane.RefreshLoadType();
            }
        }

        private string _errorText;
        public string ErrorText
        {
            get { return _errorText; }
            private set { _errorText = value; OnPropertyChanged(nameof(ErrorText)); }
        }

        private void VerifyPurchase(StoreItem itemForPurchase)
        {
            ErrorText = "";
            if (itemForPurchase == null)
            {
                ErrorText = "Please select an item";
            }
            else if (itemForPurchase != null && CanUserPurchaseItem(itemForPurchase))
            {
                purchaseVerificationViewModel.ValidatePurchase(itemForPurchase);
            }
            else
            {
                ErrorText = DetermineError(itemForPurchase);
            }
        }

        public bool CanUserPurchaseItem(StoreItem item)
        {
            if (DoesUserHaveEnoughMoney(item))
            {
                try
                {
                    var itemAsAirplane = (Airplane)item;
                    return AirplaneStoreViewModel.IsUserHighEnoughLevel(itemAsAirplane) && AirplaneStoreViewModel.DoesUserHaveTheCapacity();
                }
                catch
                {
                    Console.WriteLine("Item is an airport");
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        private bool DoesUserHaveEnoughMoney(StoreItem item) { return user.Money >= item.Price; }

        private string DetermineError(StoreItem itemForPurchase)
        {
            if (!DoesUserHaveEnoughMoney(itemForPurchase)) { return "Not enough money"; }
            else
            {
                try
                {
                    var itemAsAirplane = (Airplane)itemForPurchase;
                    if (!AirplaneStoreViewModel.IsUserHighEnoughLevel(itemAsAirplane)) { return "Not high enough level"; }
                    else if (!AirplaneStoreViewModel.DoesUserHaveTheCapacity()) { return "Insufficient capacity"; }
                }
                catch
                {
                    return "Error";
                }
            }

            return "Error";
        }

        private void PurchaseItem(object sender, VerificationEventArgs e)
        {
            if (e.Decision == true)
            {
                var purchasedItem = e.PurchasedItem;

                try
                {
                    var purchasedAirplane = AirplaneStoreViewModel.CreateNewAirplane((Airplane)purchasedItem);
                    ItemPurchaseMediator.AddAirplane(this, purchasedAirplane);
                }
                catch
                {
                    try
                    {
                        var purchasedAirport = (Airport)purchasedItem;
                        //TODO: Add purchased airport to user's list of owned airports
                        ItemPurchaseMediator.AddAirport(this, purchasedAirport);
                        Console.WriteLine(purchasedAirport.Name);
                    }
                    catch
                    {
                        Console.WriteLine("Casting Item went wrong");
                    }
                }
            }
        }
    }
}
