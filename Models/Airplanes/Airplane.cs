using AirlinesManagerGame.ViewModels;
using System;
using System.Collections.Generic;

namespace AirlinesManagerGame.Models
{
    public abstract class Airplane : StoreItem
    {
        public int LevelToUnlock { get; protected set; }
        public int Class { get; protected set; }
        public int Range { get; protected set; }
        public int Speed { get; protected set; }
        public double Weight { get; protected set; }
        public int Capacity { get; protected set; }

        private static ViewModelBase viewModelBase = new ViewModelBase();
        private LoadTypes _loadTypes;
        public LoadTypes LoadType
        {
            get { return _loadTypes; }
            set { _loadTypes = value; LoadTypeAsString = _loadTypes.ToString(); }
        }
        public string LoadTypeAsString
        {
            get { return LoadType.ToString(); }
            set { viewModelBase.OnPropertyChanged(nameof(LoadTypeAsString)); }
        }

        public int CargoCapacity { get; protected set; }
        public int PassengerCapacity { get; protected set; }

        public List<Passenger> Passengers { get; }
        public List<Cargo> Cargo { get; }
        public Airport Location { get; set; }
        public Airport Destination { get; set; }

        public Airplane()
        {
            SetLoadType();
        }

        public void RefreshLoadType()
        {
            SetLoadType();
            SetCargoAndPassengerCapacities();
        }

        private void SetLoadType()
        {
            int loadTypeDecider = new Random().Next(1, 4);
            switch (loadTypeDecider)
            {
                case 1:
                    LoadType = LoadTypes.Passenger;
                    break;
                case 2:
                    LoadType = LoadTypes.Cargo;
                    break;
                case 3:
                    LoadType = LoadTypes.Mixed;
                    break;
            }
        }

        protected void SetCargoAndPassengerCapacities()
        {
            switch (LoadType.ToString())
            {
                case "PassengerOnly":
                    PassengerCapacity = Capacity;
                    break;
                case "CargoOnly":
                    CargoCapacity = Capacity;
                    break;
                case "Mixed":
                    SetMixedCapacities();
                    break;
            }
        }

        protected abstract void SetMixedCapacities();
    }

    public enum LoadTypes
    {
        Passenger = 1,
        Cargo = 2,
        Mixed = 3
    }
}
