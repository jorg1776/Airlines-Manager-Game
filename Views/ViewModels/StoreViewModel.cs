using AirlinesManagerGame.Airplanes;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;

namespace AirlinesManagerGame.Views.ViewModels
{
    public class StoreViewModel : ViewModelBase
    {
        public ObservableCollection<Airplane> AvailableAirplanesList { get { return Store.Store.AvailableAirplanes; } }

        public RelayCommand GoBackViewCommand { get; private set; }
        public RelayCommand PurchaseAirplaneCommand { get; private set; }
        private PurchaseVerificationViewModel purchaseVerificationViewModel = new PurchaseVerificationViewModel();

        public StoreViewModel()
        {
            GoBackViewCommand = new RelayCommand(() => SendSwitchViewMessage("AirplanesStatusView"));
            PurchaseAirplaneCommand = new RelayCommand(() => VerifyPurchase(SelectedAirplane));
            purchaseVerificationViewModel.OnDecisionVerified += new PurchaseVerificationViewModel.VerificationEventHandler(PurchaseAirplane);
        }

        private Airplane _selectedAirplane;
        public Airplane SelectedAirplane
        {
            get { return _selectedAirplane; }
            set {  _selectedAirplane = value; }
        }

        private void VerifyPurchase(Airplane airplaneForPurchase)
        {
            if(airplaneForPurchase == null)
            {
                System.Console.WriteLine("null");
            }
            else if (airplaneForPurchase != null)
            {
                purchaseVerificationViewModel.ValidatePurchase(airplaneForPurchase);
            }
        }

        private void PurchaseAirplane(object sender, VerificationEventArgs e)
        {
            if (e.Decision == true)
            {
                Store.Store.TryPurchasingAirplane(SelectedAirplane);
            }
        }
    }
}
