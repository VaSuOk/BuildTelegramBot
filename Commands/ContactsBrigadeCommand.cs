using BuildTelegramBot.Models;
using BuildTelegramBot.MySQL;
using BuildTelegramBot.User;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.InputFiles;

namespace BuildTelegramBot.Commands
{
    class ContactsBrigadeCommand : Command
    {
        public override string Name => "Контакти працівників бригади";

        public override void ExecuteAsync(MessageEventArgs e, TelegramBotClient client)
        {
            var chatId = e?.Message.Chat.Id;
            var messageId = e.Message.MessageId;
       
            List<UserWorkInformation> users = SqlQuery.GetUsers(SqlQuery.GetBrigade(ListUsers.Get_instance().GetID(e.Message.Chat.Id.ToString())));
            if (users != null)
            {
                foreach (var iter in users)
                {
                    if (iter != null)
                    {
                        string message = "Ініціали працівника : " + iter.user.Surname + " " + iter.user.Name +
                            "\nКонтакти : "+ iter.user.Phone;
                        MemoryStream imageFile = new MemoryStream(iter.user.UserImage);
                        client.SendPhotoAsync(chatId, photo: imageFile, caption: message);

                    }
                    
                }
            }
            else
            {
                client.SendTextMessageAsync(e.Message.Chat, "Ви не являєтесь учасником бригади", replyMarkup: Buttons.GetBrigadeButtons());
            }
        }

        
    }
}
