using AirlinesManagerGame.Airplanes;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace AirlinesManagerGame
{
    public sealed class User : INotifyCollectionChanged, INotifyPropertyChanged
    {
        private static readonly User user = new User();
        public static User Instance { get { return user; } }

        private static int _experience = 0;
        public static int _level = 1;
        public static int _money = 10000;
        public static int _availableAirplaneSlots = 4;

        public static ObservableCollection<Airplane> OwnedAirplanes { get; private set; }
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        private User()
        {
            OwnedAirplanes = new ObservableCollection<Airplane>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public static int Experience
        {
            get { return _experience; }
            private set
            {
                _experience = value;
                user.OnPropertyChanged("Experience");
            }
        }

        public static int Level
        {
            get { return _level; }
            private set
            {
                _level = value;
                user.OnPropertyChanged("Level");
            }
        }

        public static int Money
        {
            get { return _money; }
            private set
            {
                _money = value;
                user.OnPropertyChanged("Money");
            }
        }

        public static int AvailableAirplaneSlots
        {
            get { return _availableAirplaneSlots; }
            private set
            {
                _availableAirplaneSlots = value;
                user.OnPropertyChanged("AvailableAirplaneSlots");
            }
        }

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public static void AddPurchasedAirplane(Airplane purchasedAirplane)
        {
            OwnedAirplanes.Add(purchasedAirplane);
            user.OnAirplaneAddedEvent(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, purchasedAirplane));

            AvailableAirplaneSlots--;
            Money -= purchasedAirplane.Price;
        }

        //Notifies PlaneStatusViewModel.PlanesList that a plane has been added so it can be added to the View
        private void OnAirplaneAddedEvent(NotifyCollectionChangedEventArgs e) => CollectionChanged?.Invoke(this, e);
    }
}
