﻿using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;

namespace AirlinesManagerGame.Views.ViewModels
{
    public class AirplanesStatusViewModel : ViewModelBase
    {
        public ObservableCollection<Airplanes.Airplane> AirplanesList { get {  return User.OwnedAirplanes; } }

        public RelayCommand GoToStoreViewCommand { get; private set; }
        public RelayCommand GoToMapViewCommand { get; private set; }

        public AirplanesStatusViewModel()
        {
            GoToStoreViewCommand = new RelayCommand(() => SendSwitchViewMessage("StoreView"));
            GoToMapViewCommand = new RelayCommand(() => SendSwitchViewMessage("MapView"));
        }
    }
}
