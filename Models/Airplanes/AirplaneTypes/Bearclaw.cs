using System;

namespace AirlinesManagerGame.Models
{
    public class Bearclaw : Airplane
    {
        public Bearclaw()
        {
            Name = "Bearclaw";
            Price = 7000;
            LevelToUnlock = 1;
            Class = 1;
            Range = 500;
            Speed = 126;
            Weight = 1;
            Capacity = 1;
            SetCargoAndPassengerCapacities();
        }

        protected override void SetMixedCapacities()
        {
            //Capacity is 1, so it can't be mixed so LoadType must be changed
            int randomAssigning = new Random().Next(2);

            switch(randomAssigning)
            {
                case 0:
                    LoadType = LoadTypes.Passenger;
                    PassengerCapacity = 1;
                    break;
                case 1:
                    LoadType = LoadTypes.Cargo;
                    CargoCapacity = 1;
                    break;
            }
        }
    }
}
