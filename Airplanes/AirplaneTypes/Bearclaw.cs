namespace AirlinesManagerGame.Airplanes
{
    public class Bearclaw : Airplane
    {
        public Bearclaw()
        {
            Name = "Bearclaw";
            Price = 5000;
            LevelToUnlockAirplane = 1;
            Class = 1;
            Range = 500;
            Speed = 126;
            Weight = 1;
            Capacity = 1;
            SetCargoAndPassengerCapacities();
        }

        protected override void SetMixedCapacities()
        {
            CargoCapacity = 1;
            PassengerCapacity = 1;
        }
    }
}
