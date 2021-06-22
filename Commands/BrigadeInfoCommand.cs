using BuildTelegramBot.Models;
using BuildTelegramBot.MySQL;
using BuildTelegramBot.User;
using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace BuildTelegramBot.Commands
{
    class BrigadeInfoCommand : Command
    {
        public override string Name => "Дані бригади";

        public override void ExecuteAsync(MessageEventArgs e, TelegramBotClient client)
        {
            var chatId = e?.Message.Chat.Id;
            var messageId = e.Message.MessageId;
            Brigade brigade = SqlQuery.GetBrigade(ListUsers.Get_instance().GetID(e.Message.Chat.Id.ToString()));
            if(brigade != null)
            {
                string message = "Назва бригади : " + brigade.Name +
                    "\nКількість виділено місць - " + brigade.Amount +
                    "\nРегіон роботи - " + brigade.WorkRegion + "\nЕтап будівництва - " + brigade.WorkStage;
                client.SendTextMessageAsync(chatId, message);
            }
            else
            {
                client.SendTextMessageAsync(chatId, "Ви не знаходитесь в бригаді!");
            }
            
        }
    }
}
