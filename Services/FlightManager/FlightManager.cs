using AirlinesManagerGame.Models;

namespace AirlinesManagerGame.Sevices
{
    public class FlightManager
    {
        public static void FlyPlane (Airplane airplane, Airport destination)
        {
            SendPlane(airplane, airplane.Location, destination);
            LandPlane(airplane, destination);
        }

        private static void SendPlane(Airplane airplane, Airport origin, Airport destination)
        {
            origin.DockedAirplanes.Remove(airplane);
            airplane.Destination = destination;
        }

        private static void LandPlane(Airplane airplane, Airport destination)
        {
            destination.DockedAirplanes.Add(airplane);
            airplane.Location = destination;
            airplane.Destination = null;
        }
    }
}
