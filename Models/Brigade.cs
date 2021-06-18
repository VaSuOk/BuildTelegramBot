using System;
using System.Collections.Generic;
using System.Text;

namespace BuildTelegramBot.Models
{
    public class Brigade
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string WorkRegion { get; set; }
        public string WorkStage { get; set; }
        public int Amount { get; set; }

        public int ID_user1 { get; set; }
        public int ID_user2 { get; set; }
        public int ID_user3 { get; set; }
        public int ID_user4 { get; set; }
        public int ID_user5 { get; set; }
        public int ID_user6 { get; set; }
        public int ID_user7 { get; set; }
        public int ID_user8 { get; set; }

        public int TaskID { get; set; }
    }
}
