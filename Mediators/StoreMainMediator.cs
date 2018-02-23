using System;
using AirlinesManagerGame.Airplanes;

namespace AirlinesManagerGame.Mediators
{
    public class StoreMainMediator
    {
        public delegate void AirplanePurchasedEventHandler(object sender, AirplanePurchasedEventArgs e);
        public static event AirplanePurchasedEventHandler OnAirplanePurchased;

        public static void AddAirplane(object sender, Airplane airplane)
        {
            Console.WriteLine(OnAirplanePurchased == null);
            OnAirplanePurchased?.Invoke(sender, new AirplanePurchasedEventArgs(airplane));
        }

        public class AirplanePurchasedEventArgs : EventArgs
        {
            public Airplane PurchasedAirplane { get; private set; }

            public AirplanePurchasedEventArgs(Airplane _purchasedAirplane)
            {
                PurchasedAirplane = _purchasedAirplane;
            }
        }
    }
}
