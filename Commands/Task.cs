using BuildTelegramBot.MySQL;
using BuildTelegramBot.User;
using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace BuildTelegramBot.Commands
{
    class Task : Command
    {
        public override string Name => "Завдання";

        public override void ExecuteAsync(MessageEventArgs e, TelegramBotClient client)
        {
            var chatId = e?.Message.Chat.Id;
            var messageId = e.Message.MessageId;
            bool tmp;
           // if (SqlQuery.GetUserWIByID(ListUsers.Get_instance().GetID(e.Message.Chat.Id.ToString())).Stage == "Архітектування")
           // {
                tmp = true;
          //  }
           // else
              //  tmp = false;
            client.SendTextMessageAsync(e.Message.Chat, "🛠", replyMarkup: Buttons.GetTaskButtons(tmp));
        }
    }
}
