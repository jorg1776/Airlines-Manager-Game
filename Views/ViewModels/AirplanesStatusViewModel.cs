using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;

namespace AirlinesManagerGame.Views.ViewModels
{
    public class AirplanesStatusViewModel : ViewModelBase
    {
        public ObservableCollection<Airplanes.Airplane> AirplanesList => User.OwnedAirplanes;

        public RelayCommand GoToStoreViewCommand { get; private set; }
        
        public AirplanesStatusViewModel()
        {
            GoToStoreViewCommand = new RelayCommand(() => SendSwitchViewMessage("StoreView"));
        }
    }
}
