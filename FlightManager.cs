using AirlinesManagerGame.Airplanes;
using AirlinesManagerGame.Airports;

namespace AirlinesManagerGame
{
    public class FlightManager
    {
        public static void FlyPlane(Airplane plane, Airport destination)
        {
            plane.Location.SendPlane(plane);
            destination.LandPlane(plane);
            plane.Location = destination;
        }
    }
}
