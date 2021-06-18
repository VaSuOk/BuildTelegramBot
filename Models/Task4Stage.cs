using System;
using System.Collections.Generic;
using System.Text;

namespace BuildTelegramBot.Models
{
    public class Task4Stage
    {
        public int ID { get; set; }
        public ConstructionObject constructionObject { get; set; }
        public Brigade brigade { get; set; }
        public byte[] Image1 { get; set; }
        public byte[] Image2 { get; set; }
        public string Description { get; set; }
        public string DataCreate { get; set; }
        public string DataEnd { get; set; }
    }
}
