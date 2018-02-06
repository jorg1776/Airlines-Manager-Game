using AirlinesManagerGame.Airplanes;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace AirlinesManagerGame
{
    public sealed class User : INotifyCollectionChanged
    {
        private static readonly User user = new User();

        private static int _experience = 0;
        public static int Level { get; private set; }
        public static int Money { get; private set; }
        public static int AvailableAirplaneSlots { get; private set; }

        public static ObservableCollection<Airplane> OwnedAirplanes { get; private set; }
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        private User()
        {
            Level = 1;
            Money = 10000;
            AvailableAirplaneSlots = 4;
            OwnedAirplanes = new ObservableCollection<Airplane>();
        }

        public static User Instance { get { return user; } }

        public static void AddPurchasedAirplane(Airplane purchasedAirplane)
        {
            OwnedAirplanes.Add(purchasedAirplane);
            user.OnAirlaneAdded(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, purchasedAirplane));

            AvailableAirplaneSlots--;
            Money -= purchasedAirplane.Price;
        }

        //Notifies PlaneStatusViewModel.PlanesList that a plane has been added so it can be added to the View
        private void OnAirlaneAdded(NotifyCollectionChangedEventArgs e) => CollectionChanged?.Invoke(OwnedAirplanes, e);
    }
}
