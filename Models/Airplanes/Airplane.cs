﻿using System;
using System.Collections.Generic;

namespace AirlinesManagerGame.Models
{
    public abstract class Airplane
    {
        public string Name { get; protected set; }
        public int Price { get; protected set; }
        public string PriceAsString { get { return String.Format("${0:n0}", Price); } }
        public int LevelToUnlockAirplane { get; protected set; }
        public int Class { get; protected set; }
        public int Range { get; protected set; }
        public int Speed { get; protected set; }
        public double Weight { get; protected set; }
        public int Capacity { get; protected set; }
        private LoadTypes _loadType;
        public string LoadType { get { return _loadType.ToString(); } }
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

        private void SetLoadType()
        {
            Random random = new Random();
            int loadTypeDecider = random.Next(1, 4);
            switch (loadTypeDecider)
            {
                case 1:
                    _loadType = LoadTypes.Passenger;
                    break;
                case 2:
                    _loadType = LoadTypes.Cargo;
                    break;
                case 3:
                    _loadType = LoadTypes.Mixed;
                    break;
            }
        }

        protected void SetCargoAndPassengerCapacities()
        {
            switch (_loadType.ToString())
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