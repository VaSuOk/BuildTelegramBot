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
    class ChangeLoginAndPassword : Command
    {
        public override string Name => "Змінити логін та пароль";

        public override void ExecuteAsync(MessageEventArgs e, TelegramBotClient client)
        {
            var chatId = e?.Message.Chat.Id;
            var messageId = e.Message.MessageId;

            client.SendTextMessageAsync(e.Message.Chat, "Введіть новий логін та пароль 🔑", replyMarkup: new ReplyKeyboardRemove());
            ListUsers.Get_instance().ChangeStatus(e.Message.Chat.Id.ToString(), Status.ChangeDataLogin);
        }

        public static void SetNewLoginData(MessageEventArgs e, TelegramBotClient client)
        {
            string[] arr = e.Message.Text.Split(' ');
            if (arr.Length == 2)
            {
                if(SqlQuery.ChangeLogAndPass(arr[0], arr[1], e.Message.Chat.Id.ToString()))
                {
                    client.SendTextMessageAsync(e.Message.Chat, "Пароль та логін успішно змінено!", replyMarkup: Buttons.GetMainButtons());
                    ListUsers.Get_instance().ChangeStatus(e.Message.Chat.Id.ToString(), Status.Loginned);
                }
                else
                {
                    client.SendTextMessageAsync(e.Message.Chat, "Щось пішло не так, спробуйте пізніше!", replyMarkup: Buttons.GetMainButtons());
                }
            }
            else
            {
                client.SendTextMessageAsync(e.Message.Chat, "✖️ Невірний формат введених даних!\nСпробуйте ще раз ");
            }
        }
    }
}
