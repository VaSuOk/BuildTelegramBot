using System;
using System.Collections.Generic;
using System.Text;

namespace BuildTelegramBot.User
{
    public class User
    {
        public int ID { get; set; }
        public int ID_Brigade { get; set; }
        public int ID_Task { get; set; }
        public string chatID { get; set; }
        public Status status { get; set; }

        public User(string chatID, Status status)
        {
            this.chatID = chatID;
            this.status = status;
        }
    }

    public enum Status
    {
        Default = 0,
        WaitInputLoginAndPassword = 1,
        WaitInputPhone = 2,
        Loginned = 3,
        ChangeDataLogin = 4
    }
}
