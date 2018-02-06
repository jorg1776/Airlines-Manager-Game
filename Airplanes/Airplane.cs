using AirlinesManagerGame.Airports;
using AirlinesManagerGame.CargoType;
using System;
using System.Collections.Generic;

namespace AirlinesManagerGame.Airplanes
{
    public abstract class Airplane
    {
        public string Name { get; protected set; }
        public int Price { get; protected set; }
        public int LevelToUnlockPlane { get; protected set; }
        public int Range { get; protected set; }
        public int Speed { get; protected set; }
        public int Capacity { get; protected set; }
        public double Weight { get; protected set; }
        protected LoadTypes loadType;
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
                    loadType = LoadTypes.PassengerOnly;
                    break;
                case 2:
                    loadType = LoadTypes.CargoOnly;
                    break;
                case 3:
                    loadType = LoadTypes.Mixed;
                    break;
            }
        }

        protected string GetLoadType() { return loadType.ToString(); }

        protected void SetCargoAndPassengerCapacities()
        {
            switch (loadType.ToString())
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
        PassengerOnly = 1,
        CargoOnly = 2,
        Mixed = 3
    }
}
