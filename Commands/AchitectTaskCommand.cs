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
    class AchitectTaskCommand : Command
    {
        public override string Name => "Проектування будинку";

        public override void ExecuteAsync(MessageEventArgs e, TelegramBotClient client)
        {
            try
            {
                var chatId = e?.Message.Chat.Id;
                var messageId = e.Message.MessageId;
                TaskArchitect TArchitect = SqlQuery.GetTaskByIDWorker((int)SqlQuery.GetUserWIByIDUser(ListUsers.Get_instance().GetID(chatId.ToString())).ID);
                if (TArchitect != null)
                {
                    string message = "     Завдання\n\n" +
                        "Замовник - " + TArchitect.constructionObject.customer.PIB + "\n" +
                        "Номер телефону - " + TArchitect.constructionObject.customer.Phone + "\n" +
                        "Електронна пошта - " + TArchitect.constructionObject.customer.Email + "\n\n" +
                        "Створити план [" + TArchitect.constructionObject.TypeBuilding + "]" +
                        "Обрані параметри замовником : \n" +
                        "Тип даху - " + TArchitect.constructionObject.TypeRoof + "\n" +
                        "Матеріал даху - " + TArchitect.constructionObject.RoofMaterial + "\n" +
                        "Матервал стін - " + TArchitect.constructionObject.WallMaterial + "\n\n" +
                        "Дата створення завдання - " + TArchitect.DateCreation + "\n" +
                        "Дата завершення виконання - " + TArchitect.DateEnd + " ";
                    client.SendTextMessageAsync(e.Message.Chat, message, replyMarkup: Buttons.GetTaskButtons(true));
                }
                else
                {
                    client.SendTextMessageAsync(e.Message.Chat, "У вас відсутнє завдання!", replyMarkup: Buttons.GetTaskButtons(true));
                }
            }
            catch { }
        }
    }
}
