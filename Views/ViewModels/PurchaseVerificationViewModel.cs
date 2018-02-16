using System;
using AirlinesManagerGame.Airplanes;

namespace AirlinesManagerGame.Views.ViewModels
{
    public class PurchaseVerificationViewModel : ViewModelBase
    {
        private WindowService.WindowService windowService = new WindowService.WindowService();

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

        public bool IsPurchaseVerified(Airplane selectedAirplane)
        {
            SetVerificationQuestion(selectedAirplane);
            windowService.ShowPurchaseVerificationWindow(this);
            return false;
        }
    }
}
