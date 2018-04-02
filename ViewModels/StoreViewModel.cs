using AirlinesManagerGame.Models;
using AirlinesManagerGame.Services.Mediators;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.ObjectModel;
using System.Windows.Threading;

namespace AirlinesManagerGame.ViewModels
{
    public class StoreViewModel : ViewModelBase
    {
        private static User user;
        private static Store store = new Store(user);

        public ObservableCollection<Airplane> AvailableAirplanesList { get { return store.AvailableAirplanes; } }
        public ObservableCollection<Airport> AirportsList { get { return store.Airports; } }

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
            foreach (Airplane airplane in AvailableAirplanesList)
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
                    return IsUserHighEnoughLevel(itemAsAirplane) && DoesUserHaveTheCapacity();
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

        private bool IsUserHighEnoughLevel(Airplane airplane) { return user.Level >= airplane.LevelToUnlock; }

        private bool DoesUserHaveTheCapacity() { return user.AvailableAirplaneSlots > 0; }

        private string DetermineError(StoreItem itemForPurchase)
        {
            if (!DoesUserHaveEnoughMoney(itemForPurchase)) { return "Not enough money"; }
            else
            {
                try
                {
                    var itemAsAirplane = (Airplane)itemForPurchase;
                    if (!IsUserHighEnoughLevel(itemAsAirplane)) { return "Not high enough level"; }
                    else if (!DoesUserHaveTheCapacity()) { return "Insufficient capacity"; }
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
                    var purchasedAirplane = CreateNewAirplane((Airplane)purchasedItem);
                    AirplanePurchaseMediator.AddAirplane(this, purchasedAirplane);
                }
                catch
                {
                    try
                    {
                        var purchasedAirport = (Airport)purchasedItem;
                        Console.WriteLine(purchasedAirport.Name);
                    }
                    catch
                    {
                        Console.WriteLine("Casting Item went wrong");
                    }
                }
            }
        }

        private Airplane CreateNewAirplane(Airplane airplaneType)
        {
            Airplane newAirplane;

            switch (airplaneType.GetType().Name)
            {
                case "Bearclaw":
                    newAirplane = new Bearclaw();
                    break;
                case "Griffon":
                    newAirplane = new Griffon();
                    break;
                case "Wallaby":
                    newAirplane = new Wallaby();
                    break;
                default:
                    throw new Exception();
            }

            newAirplane.LoadType = airplaneType.LoadType;
            return newAirplane;
        }
    }
}
