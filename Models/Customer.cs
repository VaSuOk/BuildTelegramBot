using System;
using System.Collections.Generic;
using System.Text;

namespace BuildTelegramBot.Models
{
    public class Customer
    {
        public int ID { get; set; }
        public string PIB { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
