using BuildTelegramBot.Models;
using BuildTelegramBot.MySQL;
using BuildTelegramBot.User;
using System.Collections.Generic;
using System.IO;
using Telegram.Bot;
using Telegram.Bot.Args;

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
                        string message = "\n\nІніціали працівника : " + iter.user.Surname + " " + iter.user.Name +
                            "\nДата народження : " + iter.user.Birthday +
                            "\nКонтакти : " + iter.user.Phone + " " + iter.user.Email +
                            "\nПосада - " + iter.Position;
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
