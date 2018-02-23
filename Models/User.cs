using System.Collections.ObjectModel;

namespace AirlinesManagerGame.Models
{
    public sealed class User
    {
        private static readonly User user = new User();
        public static User Instance { get { return user; } }

        public static ObservableCollection<Airplane> OwnedAirplanes { get; private set; }

        private User()
        {
            Money = 10000;
            Level = 1;
            AvailableAirplaneSlots = 4;
            Experience = 0;
            OwnedAirplanes = new ObservableCollection<Airplane>();
        }

        public static int Experience { get; set; }

        public static int Level { get; set; }

        public static int Money { get; set; }

        public static int AvailableAirplaneSlots { get; set; }
    }
}
