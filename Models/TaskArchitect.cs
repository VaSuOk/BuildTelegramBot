using System;
using System.Collections.Generic;
using System.Text;

namespace BuildTelegramBot.Models
{
    public class TaskArchitect
    {
        public int ID { get; set; }
        public UserWorkInformation Architect { get; set; }
        public ConstructionObject constructionObject { get; set; }
        public string DateCreation { get; set; }
        public string DateEnd { get; set; }
        public string Status { get; set; }
        public byte[] BuildPlan { get; set; }
    }
}
