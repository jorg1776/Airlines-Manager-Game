using System;
using AirlinesManagerGame.Models;

namespace AirlinesManagerGame.Services.Mediators
{
    public class AirplanePurchaseMediator
    {
        public delegate void AirplanePurchasedEventHandler(object sender, AirplanePurchasedEventArgs e);
        public static event AirplanePurchasedEventHandler OnAirplanePurchased;

        public static void AddAirplane(object sender, Airplane airplane)
        {
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
