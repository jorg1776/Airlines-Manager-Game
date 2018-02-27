using System.Collections.ObjectModel;

namespace AirlinesManagerGame.Models
{
    public class User
    {
        public ObservableCollection<Airplane> OwnedAirplanes { get; private set; }

        public User()
        {
            Money = 10000;
            Level = 1;
            AvailableAirplaneSlots = 4;
            Experience = 0;
            OwnedAirplanes = new ObservableCollection<Airplane>();
        }

        public int Experience { get; set; }

        public int Level { get; set; }

        public int Money { get; set; }

        public int AvailableAirplaneSlots { get; set; }
    }
}
