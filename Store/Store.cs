using AirlinesManagerGame.Airplanes;
using System.Collections.ObjectModel;
using System.Linq;

namespace AirlinesManagerGame.Store
{
    public sealed class Store
    {
        private static readonly Store store = new Store();
        public static ObservableCollection<Airplane> AvailableAirplanes { get; private set; }

        private Store()
        {
            AvailableAirplanes = new ObservableCollection<Airplane>();
            PopulateListOfAirplanes();
        }

        public static Store Instance { get { return store; } }

        private static void PopulateListOfAirplanes()
        {
            AvailableAirplanes.Add(new Bearclaw());
            AvailableAirplanes.Add(new Wallaby());
        }

        public static bool CanUserPurchaseAirplane(int planeIndex)
        {
            Airplane airplaneToPurchase = AvailableAirplanes.ElementAt(planeIndex);

            return IsUserHighEnoughLevel(airplaneToPurchase)
                    && DoesUserHaveEnoughMoney(airplaneToPurchase)
                    && DoesUserHaveTheCapacity();
        }

        private static bool IsUserHighEnoughLevel(Airplane airplane) { return User.Level >= airplane.LevelToUnlockPlane; }
        
        private static bool DoesUserHaveEnoughMoney(Airplane airplane) { return User.Money >= airplane.Price; }

        private static bool DoesUserHaveTheCapacity() { return User.AvailableAirplaneSlots > 0; }

        private static void PurchaseAirplane(int airplaneIndex)
        {
            User.AddPurchasedAirplane(AvailableAirplanes.ElementAt(airplaneIndex));
        }
    }
}
