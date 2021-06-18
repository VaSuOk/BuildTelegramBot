using System;
using System.Collections.Generic;
using System.Text;

namespace BuildTelegramBot.User
{
    public class ListUsers
    {
        public List<User> users;
        private static ListUsers Instance;
        public static ListUsers Get_instance()
        {
            return Instance == null ? Instance = new ListUsers() : Instance;
        }
        private ListUsers()
        {
            users = new List<User>();
        }

        public void ChangeStatus(string chatID, Status status)
        {
            bool is_ = false;
            foreach (var user in users)
            {
                if (chatID == user.chatID)
                {
                    is_ = true;
                    user.status = status;
                }
            }
            if (is_) { return; }
            else
            {
                users.Add(new User(chatID, status));
            }
        }
        public bool IsStatusTrue(string chatID, Status status)
        {
            foreach (var user in users)
            {
                if (chatID == user.chatID && user.status == status)
                {
                    return true;
                }
            }
            return false;
        }
        public void SetID(string chatID, int ID)
        {
            foreach (var user in users)
            {
                if (chatID == user.chatID)
                {
                    user.ID = ID;
                    return;
                }
            }
        }
        public int GetID(string chatID)
        {
            foreach (var user in users)
            {
                if (chatID == user.chatID)
                {
                    return user.ID;
                }
            }
            return 0;
        }
    }
}
