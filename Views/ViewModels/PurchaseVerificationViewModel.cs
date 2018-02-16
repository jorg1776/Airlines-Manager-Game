using System;
using AirlinesManagerGame.Airplanes;
using GalaSoft.MvvmLight.Command;

namespace AirlinesManagerGame.Views.ViewModels
{
    public class PurchaseVerificationViewModel : ViewModelBase
    {
        private WindowService.WindowService windowService = new WindowService.WindowService();

        public RelayCommand AcceptPurchaseCommand { get; private set; }
        public RelayCommand DeclinePurchaseCommand { get; private set; }

        public PurchaseVerificationViewModel()
        {
            AcceptPurchaseCommand = new RelayCommand(() => 
            {
                OnDecisionVerified(this, new VerificationEventArgs(true));
                windowService.CloseWindow();
            });

            DeclinePurchaseCommand = new RelayCommand(() => windowService.CloseWindow() );
        }

        private string _verificationQuestion = "Question";
        public string VerificationQuestion
        {
            get { return _verificationQuestion; }
            set
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
            SetVerificationQuestion(selectedAirplane);
            windowService.ShowPurchaseVerificationWindow(this);
        }

        public delegate void VerificationEventHandler(object sender, VerificationEventArgs args);
        public event VerificationEventHandler OnDecisionVerified;
    }

    public class VerificationEventArgs : EventArgs
    {
        public bool _decision;

        public VerificationEventArgs(bool decision)
        {
            _decision = decision;
        }

        public bool Decision { get { return _decision; } }
    }
}
