﻿namespace AirlinesManagerGame.Airplanes
{
    public class Wallaby : Airplane
    {
        public Wallaby()
        {
            Name = "Wallaby";
            Price = 10000;
            LevelToUnlockPlane = 3;
            Class = 1;
            Range = 700;
            Speed = 143;
            Weight = 2.2;
            Capacity = 2;
            SetCargoAndPassengerCapacities();
        }

        protected override void SetMixedCapacities()
        {
            PassengerCapacity = 1;
            CargoCapacity = 0;
        }
    }
}
