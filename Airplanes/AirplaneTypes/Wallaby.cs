namespace AirlinesManagerGame.Airplanes
{
    public class Wallaby : Airplane
    {
        private string _name = "Wallaby";
        private int _price = 10000;
        private int _range = 700;
        private int _speed = 143;
        private int _capacity = 2;
        private double _weight = 2.2;
        private int _levelToUnlockPlane = 3;

        public Wallaby()
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
            PassengerCapacity = 1;
            CargoCapacity = 0;
        }
    }
}
