using System;
using System.Collections.Generic;
using System.Text;

namespace BuildTelegramBot.Models
{
    public class ConstructionObject
    {
        public int ID { get; set; }
        public Customer customer { get; set; }
        public string Region { get; set; }
        public string Sity { get; set; }
        public string Street { get; set; }

        public string TypeBuilding { get; set; }
        public string TypeRoof { get; set; }
        public string RoofMaterial { get; set; }
        public string WallMaterial { get; set; }

        public string DataCreate { get; set; }
        public byte[] Image { get; set; }

        public int Stage { get; set; }
    }
}
