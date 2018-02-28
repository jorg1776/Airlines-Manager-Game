using System;
using AirlinesManagerGame.Models;
using AirlinesManagerGame.Services;
using GalaSoft.MvvmLight.Command;

namespace AirlinesManagerGame.ViewModels
{
    public class PurchaseVerificationViewModel : ViewModelBase
    {
        private WindowService windowService = new WindowService();

        public RelayCommand AcceptPurchaseCommand { get; private set; }
        public RelayCommand DeclinePurchaseCommand { get; private set; }

        private Airplane airplaneForPurchase;

        public PurchaseVerificationViewModel()
        {
            AcceptPurchaseCommand = new RelayCommand(() => 
            {
                OnDecisionVerified(this, new VerificationEventArgs(airplaneForPurchase, true));
                windowService.CloseWindow();
            });

            DeclinePurchaseCommand = new RelayCommand(() => windowService.CloseWindow() );
        }

        private string _verificationQuestion = "Question";
        public string VerificationQuestion
        {
            get { return _verificationQuestion; }
            private set
            {
                if (_verificationQuestion != value)
                {
                    _verificationQuestion = value;
                    OnPropertyChanged(nameof(VerificationQuestion));
                }
            }
        }

        private void SetVerificationQuestion(Airplane airplane)
        {
            VerificationQuestion = String.Format("Would you like to purchase {0} for {1}?", airplane.Name, airplane.PriceAsString);
        }

        public void ValidatePurchase(Airplane selectedAirplane)
        {
            if (windowService.CanDisplayWindow)
            {
                SetVerificationQuestion(selectedAirplane);
                airplaneForPurchase = selectedAirplane;
                windowService.ShowPurchaseVerificationWindow(this);
            }
        }

        public delegate void VerificationEventHandler(object sender, VerificationEventArgs args);
        public event VerificationEventHandler OnDecisionVerified;
    }

    public class VerificationEventArgs : EventArgs
    {

        public VerificationEventArgs(Airplane airplane, bool decision)
        {
            PurchasedAirplane = airplane;
            Decision = decision;
        }

        public bool Decision { get; private set; }
        public Airplane PurchasedAirplane { get; private set; }
    }
}
