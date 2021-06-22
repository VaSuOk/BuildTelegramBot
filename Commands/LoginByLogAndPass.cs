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
    class LoginByLogAndPass : Command
    {
        public override string Name => "Логін та пароль";

        public override void ExecuteAsync(MessageEventArgs e, TelegramBotClient client)
        {
            var chatId = e?.Message.Chat.Id;
            var messageId = e.Message.MessageId;

            client.SendTextMessageAsync(e.Message.Chat, "Введіть логін та пароль 🔑", replyMarkup: new ReplyKeyboardRemove());
            ListUsers.Get_instance().ChangeStatus(e.Message.Chat.Id.ToString(), Status.WaitInputLoginAndPassword);
        }
        public static void GetLoginData(MessageEventArgs e, TelegramBotClient client)
        {
            string[] arr = e.Message.Text.Split(' ');
            if(arr.Length == 2)
            {
                if(SqlQuery.LoginByLogAndPass(arr[0], arr[1], e.Message.Chat.Id.ToString()))
                {
                    client.SendTextMessageAsync(e.Message.Chat, "✔️ Ви успішно увійшли в свій акаунт! 🔓", replyMarkup: Buttons.GetMainButtons());
                    ListUsers.Get_instance().ChangeStatus(e.Message.Chat.Id.ToString(), Status.Loginned);
                }
                else
                {
                    client.SendTextMessageAsync(e.Message.Chat, "✖️ Не знайдено користувача \nз даними - " + e.Message.Text, replyMarkup: Buttons.GetLoginButtons());
                    ListUsers.Get_instance().ChangeStatus(e.Message.Chat.Id.ToString(), Status.Default);
                }
            }
            else
            {
                client.SendTextMessageAsync(e.Message.Chat, "✖️ Невірно введені дані!\nСпробуйте ще раз ", replyMarkup: Buttons.GetLoginButtons());
            }
        }
    }
}
