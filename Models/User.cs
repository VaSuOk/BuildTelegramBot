using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BuildTelegramBot.Models
{
    public class User
    {
        #region Data fields
        public uint id { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Region { get; set; }
        public string Sity { get; set; }
        public byte[] UserImage { get; set; }
        public string Birthday { get; set; }

        public string login { get; set; }
        public string password { get; set; }
        #endregion

    }
}
