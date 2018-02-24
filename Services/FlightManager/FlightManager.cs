using AirlinesManagerGame.Models;

namespace AirlinesManagerGame.Sevices
{
    public class FlightManager
    {
        public static void FlyPlane (Airplane airplane, Airport destination)
        {
            SendPlane(airplane, airplane.Location, destination);
            Landplane(airplane, destination);
        }

        private static void SendPlane(Airplane airplane, Airport origin, Airport destination)
        {
            origin.DockedAirplanes.Remove(airplane);
            airplane.Destination = destination;
        }

        private static void Landplane(Airplane airplane, Airport destination)
        {
            destination.DockedAirplanes.Add(airplane);
        }
    }
}
