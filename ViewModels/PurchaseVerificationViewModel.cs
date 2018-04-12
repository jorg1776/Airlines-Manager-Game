using AirlinesManagerGame.Models;
using AirlinesManagerGame.Services;
using GalaSoft.MvvmLight.Command;
using System;

namespace AirlinesManagerGame.ViewModels
{
    public class PurchaseVerificationViewModel : ViewModelBase
    {
        private WindowService windowService = new WindowService();

        public RelayCommand AcceptPurchaseCommand { get; private set; }
        public RelayCommand DeclinePurchaseCommand { get; private set; }

        private StoreItem itemForPurchase;

        public PurchaseVerificationViewModel()
        {
            AcceptPurchaseCommand = new RelayCommand(() =>
            {
                OnDecisionVerified(this, new VerificationEventArgs(itemForPurchase, true));
                windowService.CloseWindow();
            });

            DeclinePurchaseCommand = new RelayCommand(() => windowService.CloseWindow());
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

        private void SetVerificationQuestion(StoreItem item)
        {
            VerificationQuestion = String.Format("Would you like to purchase {0} for {1}?", item.Name, item.PriceAsString);
        }

        public void ValidatePurchase(StoreItem selectedItem)
        {
            if (windowService.CanDisplayWindow)
            {
                SetVerificationQuestion(selectedItem);
                itemForPurchase = selectedItem;
                windowService.ShowPurchaseVerificationWindow(this);
            }
        }

        public delegate void VerificationEventHandler(object sender, VerificationEventArgs args);
        public event VerificationEventHandler OnDecisionVerified;
    }

    public class VerificationEventArgs : EventArgs
    {

        public VerificationEventArgs(StoreItem item, bool decision)
        {
            PurchasedItem = item;
            Decision = decision;
        }

        public bool Decision { get; private set; }
        public StoreItem PurchasedItem { get; private set; }
    }
}
