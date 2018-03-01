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
        private User user;
        private static Store store = new Store();

        public ObservableCollection<Airplane> AvailableAirplanesList { get { return store.AvailableAirplanes; } }

        public RelayCommand GoBackViewCommand { get; private set; }
        public RelayCommand PurchaseAirplaneCommand { get; private set; }
        private PurchaseVerificationViewModel purchaseVerificationViewModel = new PurchaseVerificationViewModel();

        public Airplane SelectedAirplane { get; set; }

        private string _timerDisplay = "Refresh Types in: ";
        public string TimerDisplay
        {
            get { return _timerDisplay; }
            set { _timerDisplay = value; OnPropertyChanged(nameof(TimerDisplay)); }
        }

        public StoreViewModel(User user)
        {
            this.user = user;

            GoBackViewCommand = new RelayCommand(() => SendSwitchViewMessage("AirplanesStatusView"));
            PurchaseAirplaneCommand = new RelayCommand(() => VerifyPurchase(SelectedAirplane));
            purchaseVerificationViewModel.OnDecisionVerified += PurchaseAirplane;
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
            foreach(Airplane airplane in AvailableAirplanesList)
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
                var purchasedAirplane = CreateNewAirplane(e.PurchasedAirplane);
                AirplanePurchaseMediator.AddAirplane(this, purchasedAirplane);
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
