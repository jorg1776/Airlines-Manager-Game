using AirlinesManagerGame.Airplanes;
using System;
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

        public static void TryPurchasingAirplane(Airplane airplane)
        {
            if (CanUserPurchaseAirplane(airplane))
            {
                var purchasedAirplane = CreateNewAirplane(airplane.GetType().Name);
                PurchaseAirplane(purchasedAirplane);
            }
            else
            {
                Console.WriteLine("Can't purchase");
            }
        }

        private static Airplane CreateNewAirplane(string name)
        {
            switch(name)
            {
                case "Bearclaw":
                    return new Bearclaw();
                case "Wallaby":
                    return new Wallaby();
                default:
                    throw new Exception();
            }
        }

        public static bool CanUserPurchaseAirplane(Airplane airplane)
        {
            return IsUserHighEnoughLevel(airplane)
                    && DoesUserHaveEnoughMoney(airplane)
                    && DoesUserHaveTheCapacity();
        }

        private static bool IsUserHighEnoughLevel(Airplane airplane) { return User.Level >= airplane.LevelToUnlockAirplane; }
        
        private static bool DoesUserHaveEnoughMoney(Airplane airplane) { return User.Money >= airplane.Price; }

        private static bool DoesUserHaveTheCapacity() { return User.AvailableAirplaneSlots > 0; }

        private static void PurchaseAirplane(Airplane airplane) { User.AddPurchasedAirplane(airplane); }
    }
}
