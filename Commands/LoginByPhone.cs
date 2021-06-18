using BuildTelegramBot.MySQL;
using BuildTelegramBot.User;
using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;

namespace BuildTelegramBot.Commands
{
    class LoginByPhone : Command
    {
        public override string Name => "Номер телефону";

        public override void ExecuteAsync(MessageEventArgs e, TelegramBotClient client)
        {
            var chatId = e?.Message.Chat.Id;
            var messageId = e.Message.MessageId;

            KeyboardButton button = KeyboardButton.WithRequestContact("Відправити контакт ☎️");
            ReplyKeyboardMarkup keyboard = new ReplyKeyboardMarkup(button);
            client.SendTextMessageAsync(e.Message.Chat, "Відправте свій контакт! ", replyMarkup: keyboard);
            ListUsers.Get_instance().ChangeStatus(e.Message.Chat.Id.ToString(), Status.WaitInputPhone);
        }
        public static void GetPhone(MessageEventArgs e, TelegramBotClient client)
        {
            string phone = null;
            var app = client.GetUpdatesAsync().Result;
            foreach (var item in app)
            {
                if(item.Message.Contact != null)
                {
                    phone = item.Message.Contact.PhoneNumber;
                }
            }
            if(phone != null)
            {
                if (SqlQuery.LoginByPhone(phone, e.Message.Chat.Id.ToString()))
                {
                    client.SendTextMessageAsync(e.Message.Chat, "✔️ Ви успішно увійшли в свій акаунт! 🔓", replyMarkup: Buttons.GetMainButtons());
                    ListUsers.Get_instance().ChangeStatus(e.Message.Chat.Id.ToString(), Status.Loginned);
                }
                else
                {
                    client.SendTextMessageAsync(e.Message.Chat, "✖️ Не знайдено користувача \nз номером - " + phone, replyMarkup: Buttons.GetLoginButtons());
                    ListUsers.Get_instance().ChangeStatus(e.Message.Chat.Id.ToString(), Status.Default);
                }
            }
            else
            {
                client.SendTextMessageAsync(e.Message.Chat, "✖️ Не вдалося отримати номер телефону", replyMarkup: Buttons.GetLoginButtons());
                ListUsers.Get_instance().ChangeStatus(e.Message.Chat.Id.ToString(), Status.Default);
            }
        }
    }
}
