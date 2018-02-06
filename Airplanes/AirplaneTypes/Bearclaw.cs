namespace AirlinesManagerGame.Airplanes
{
    public class Bearclaw : Airplane
    {
        private string _name = "Bearclaw";
        private int _price = 5000;
        private int _range = 500;
        private int _speed = 126;
        private int _capacity = 1;
        private double _weight = 1;
        private int _levelToUnlockPlane = 1;

        public Bearclaw()
        {
            Name = _name;
            Price = _price;
            Range = _range;
            Speed = _speed;
            Capacity = _capacity;
            SetCargoAndPassengerCapacities();
            Weight = _weight;
            LevelToUnlockPlane = _levelToUnlockPlane;
        }

        protected override void SetMixedCapacities()
        {
            CargoCapacity = 1;
            PassengerCapacity = 1;
        }
    }
}
