using System;

namespace AirlinesManagerGame.Models
{
    public class StoreItem
    {
        public string Name { get; protected set; }
        public int Price { get; protected set; }
        public string PriceAsString { get { return String.Format("${0:n0}", Price); } }
    }
}
