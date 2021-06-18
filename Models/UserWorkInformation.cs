using System;
using System.Collections.Generic;
using System.Text;

namespace BuildTelegramBot.Models
{
    public class UserWorkInformation
    {
        public uint ID { get; set; }
        public User user { get; set; }
        public string Stage { get; set; }
        public string Position { get; set; }
        public string WorkRegion { get; set; }
        public string Salary { get; set; }
    }
}
