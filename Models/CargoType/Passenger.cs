
using System;

namespace AirlinesManagerGame.Models
{
    public class Passenger : ICargoType
    {
        public Passenger(Airport _location) : base(_location)
        {
            Name = GetRandomName();
        }

        protected override string GetRandomName()
        {
            Random random = new Random();
            int index = random.Next(PassengerNames.Length);

            return PassengerNames[index];
        }

        private string[] PassengerNames =
        {
            "Roseanne Bachman",
            "Neva Seidel",
            "Gaylord Mcmorran",
            "Alfred Lundholm",
            "Bee Dumire",
            "Jeanetta Boll",
            "Roni Poynor",
            "Latisha Womble",
            "Terrance Matinez",
            "Guy Thrush",
            "Carolee Roby",
            "Alvaro Milburn",
            "Carri Ramsier",
            "Fran Buettner",
            "Shyla Schank",
            "Jadwiga Marcell",
            "Rolf Corrigan",
            "Dusti Beno",
            "Abby Barbara",
            "Joann Mixson",
            "Wes Klopfer",
            "Elinore Crisci",
            "Tania Baccus",
            "Ardelia Gold",
            "Temple Bylsma",
            "Janee Wessels",
            "Eldon Dosch",
            "Clarita Mulloy",
            "Li Laird",
            "Lynsey Dey",
            "Elliott Lowman",
            "Marlena Zobel",
            "Deloras Caples",
            "Samantha Mcgonagle",
            "Otha Crandall",
            "Adriane Tansey",
            "Melody Yarrington",
            "Temeka Grise",
            "Mui Lombard",
            "Kanesha Lair",
            "Troy Wisecup",
            "Tamesha Cimino",
            "King Thibault",
            "Crissy Dragon",
            "Shantelle Mears",
            "Norene Heinemann",
            "Afton Silber",
            "Elia Cowart",
            "Kiersten Cullinan",
            "Bertha Dickie"
            //^50 names^
        };
    }
}
