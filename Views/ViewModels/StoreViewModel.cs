using AirlinesManagerGame.Airplanes;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;

namespace AirlinesManagerGame.Views.ViewModels
{
    public class StoreViewModel : ViewModelBase
    {
        public ObservableCollection<Airplanes.Airplane> AvailableAirplanesList => Store.Store.AvailableAirplanes;

        public RelayCommand GoBackViewCommand { get; private set; }
        public RelayCommand PurchaseAirplaneCommand { get; private set; }

        public StoreViewModel()
        {
            GoBackViewCommand = new RelayCommand(() => SendSwitchViewMessage("AirplanesStatusView"));
            PurchaseAirplaneCommand = new RelayCommand(() => Store.Store.TryPurchasingAirplane(SelectedAirplane));
        }

        public Airplane SelectedAirplane
        {
            get;
            set;
        }
    }
}
