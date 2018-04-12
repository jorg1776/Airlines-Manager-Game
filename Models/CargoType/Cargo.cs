using System;

namespace AirlinesManagerGame.Models
{
    public class Cargo : ICargoType
    {
        public Cargo(Airport _location) : base(_location)
        {
            Name = GetRandomName();
        }

        protected override string GetRandomName()
        {
            Random random = new Random();
            int index = random.Next(CargoNames.Length);

            return CargoNames[index];
        }

        private string[] CargoNames =
        {
            "Q_Tips",
            "Cucumbers",
            "Towels",
            "Cameras",
            "Rolls of Duct Tape",
            "Wine Glasses",
            "Dominoes",
            "Mirrors",
            "Sponges",
            "Rings",
            "Blowdryers",
            "Jars of Jam",
            "Bags of Cotton Balls",
            "Decks of Cards",
            "Statuette",
            "Toy Soldiers",
            "Bottles of Ink",
            "Limes",
            "Candlesticks",
            "Needles",
            "Cans of Whipped Cream",
            "Saws",
            "Spools of String",
            "Hair Ribbons",
            "Pencils",
            "Books",
            "Jars of Pickles",
            "Necklaces",
            "Bottles of Perfume",
            "Lamps",
            "Paperclips",
            "Rocks",
            "Cups",
            "Game Systems",
            "Ladles",
            "Stamps",
            "Salt Shakers",
            "Screwdrivers",
            "Cans of Peas",
            "Cookie Tins",
            "Water Goggles",
            "Bottles of Pills",
            "Plush Octopuses",
            "Nails",
            "Backpacks",
            "Blankets",
            "Socks",
            "Tostitos",
            "Potatoes",
            "Monkeys"
            //^50 names^
        };
    }
}
